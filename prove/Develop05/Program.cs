/*
CREATIVITY AND EXCEEDING REQUIREMENTS:

I added a leveling system to make the Eternal Quest program
more engaging and rewarding.

Every 500 points earned increases the user's level.

The program displays the user's current level in the main menu
and shows a special congratulatory message whenever the user
reaches a new level.

The level is calculated automatically from the total points,
so it is also preserved when goals are saved and loaded.
*/

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    private static List<Goal> _goals = new List<Goal>();
    private static int _totalPoints = 0;

    static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine();
            Console.WriteLine($"You have {_totalPoints} points.");
            Console.WriteLine($"Current Level: {GetLevel()}");
            Console.WriteLine();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGoal();
                    break;

                case "2":
                    ListGoals();
                    break;

                case "3":
                    SaveGoals();
                    break;

                case "4":
                    LoadGoals();
                    break;

                case "5":
                    RecordEvent();
                    break;

                case "6":
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");
        string type = Console.ReadLine();

        if (type != "1" && type != "2" && type != "3")
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        Console.Write("What is the name of your goal? ");
        string title = Console.ReadLine();

        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();

        Console.Write("How many points is this goal worth? ");
        int points = ReadNonNegativeInt();

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(title, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(title, description, points));
        }
        else if (type == "3")
        {
            Console.Write("How many times must this goal be accomplished? ");
            int repeatGoal = ReadPositiveInt();

            Console.Write("What is the bonus for accomplishing it? ");
            int bonus = ReadNonNegativeInt();

            _goals.Add(new ChecklistGoal(title, description, points, repeatGoal, bonus));
        }

        Console.WriteLine("Goal created successfully!");
    }

    static void ListGoals()
    {
        Console.WriteLine();
        Console.WriteLine("The goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals have been created.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.Write($"{i + 1}. ");
            _goals[i].Display();
        }
    }

    static void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("You don't have any goals to record.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetTitle()}");
        }

        Console.Write("Which goal did you accomplish? ");
        int selection = ReadPositiveInt();

        if (selection < 1 || selection > _goals.Count)
        {
            Console.WriteLine("Invalid goal selection.");
            return;
        }

        // Remember the user's level before earning points
        int oldLevel = GetLevel();

        // Record the event and award points
        int earnedPoints = _goals[selection - 1].RecordEvent();

        _totalPoints += earnedPoints;

        if (earnedPoints > 0)
        {
            Console.WriteLine($"Congratulations! You have earned {earnedPoints} points!");
        }
        else
        {
            Console.WriteLine("This goal has already been completed or awarded no points.");
        }

        // Check whether the user leveled up
        int newLevel = GetLevel();

        if (newLevel > oldLevel)
        {
            Console.WriteLine();
            Console.WriteLine("******************************");
            Console.WriteLine($"   LEVEL UP! LEVEL {newLevel}!");
            Console.WriteLine("******************************");
        }
    }

    static void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_totalPoints);

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.Save());
                }
            }

            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving goals: {ex.Message}");
        }
    }

    static void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);

            if (lines.Length == 0)
            {
                Console.WriteLine("The file is empty.");
                return;
            }

            int loadedPoints = int.Parse(lines[0]);
            List<Goal> loadedGoals = new List<Goal>();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] goalParts = lines[i].Split(':', 2);

                if (goalParts.Length != 2)
                {
                    throw new FormatException("Invalid goal format.");
                }

                string goalType = goalParts[0];
                string[] data = goalParts[1].Split(',');

                if (data.Length < 3)
                {
                    throw new FormatException("Missing goal information.");
                }

                string title = data[0];
                string description = data[1];
                int points = int.Parse(data[2]);

                if (goalType == "SimpleGoal")
                {
                    bool complete = bool.Parse(data[3]);

                    loadedGoals.Add(new SimpleGoal(
                        title,
                        description,
                        points,
                        complete
                    ));
                }
                else if (goalType == "EternalGoal")
                {
                    loadedGoals.Add(new EternalGoal(
                        title,
                        description,
                        points
                    ));
                }
                else if (goalType == "ChecklistGoal")
                {
                    int repeatGoal = int.Parse(data[3]);
                    int bonus = int.Parse(data[4]);
                    int currentlyCompleted = int.Parse(data[5]);

                    loadedGoals.Add(new ChecklistGoal(
                        title,
                        description,
                        points,
                        repeatGoal,
                        bonus,
                        currentlyCompleted
                    ));
                }
                else
                {
                    throw new FormatException("Unknown goal type.");
                }
            }

            _goals = loadedGoals;
            _totalPoints = loadedPoints;

            Console.WriteLine("Goals loaded successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading goals: {ex.Message}");
        }
    }

    // Creativity feature: calculate the user's level
    static int GetLevel()
    {
        return (_totalPoints / 500) + 1;
    }

    // Validate that the user enters a non-negative integer
    static int ReadNonNegativeInt()
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number) && number >= 0)
            {
                return number;
            }

            Console.Write("Please enter a non-negative whole number: ");
        }
    }

    // Validate that the user enters a positive integer
    static int ReadPositiveInt()
    {
        while (true)
        {
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number) && number > 0)
            {
                return number;
            }

            Console.Write("Please enter a positive whole number: ");
        }
    }
}