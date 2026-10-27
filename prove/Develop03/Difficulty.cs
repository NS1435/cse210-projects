using System;

public class Difficulty
{
    // Private attributes
    private string _name;              // "Easy", "Medium", or "Hard"
    private double _percentToHide;     // fraction of words hidden in the first round (0.10 = 10%)
    private double _decay = 0.85;      // each round hides about 85% as many as the previous one
    private double _multiplier;        // score multiplier for this difficulty

    // Constructor sets the default difficulty to Easy
    public Difficulty()
    {
        _name = "Easy";
        _percentToHide = 0.10;
        _multiplier = 1.0;
    }

    // Asks the user to select a difficulty level, repeating until the choice is valid
    public void ChooseDifficulty()
    {
        Console.WriteLine("Scripture Memorizer");
        Console.WriteLine("Choose a difficulty:");
        Console.WriteLine("1. Easy (starts by hiding 10% of the words)");
        Console.WriteLine("2. Medium (starts by hiding 20% of the words)");
        Console.WriteLine("3. Hard (starts by hiding 35% of the words)");

        bool validChoice = false;

        while (!validChoice)
        {
            Console.Write("Enter your choice (1-3): ");

            string choice = (Console.ReadLine() ?? "").Trim();

            if (choice == "1")
            {
                _name = "Easy";
                _percentToHide = 0.10;
                _multiplier = 1.0;
                validChoice = true;
            }
            else if (choice == "2")
            {
                _name = "Medium";
                _percentToHide = 0.20;
                _multiplier = 1.2;
                validChoice = true;
            }
            else if (choice == "3")
            {
                _name = "Hard";
                _percentToHide = 0.35;
                _multiplier = 1.4;
                validChoice = true;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
            }
        }
    }

    // Returns how many words to hide this round
    public int GetWordsToHide(int totalWords, int round)
    {
        double amount = totalWords * _percentToHide * Math.Pow(_decay, round);

        return Math.Max(1, (int)Math.Ceiling(amount));
    }

    // Returns the score multiplier for the chosen difficulty
    public double GetMultiplier()
    {
        return _multiplier;
    }

    // Returns the name of the chosen difficulty
    public string GetName()
    {
        return _name;
    }
}