using System;

public class BreathingActivity : Activity
{
    private int _inhaleSeconds;
    private int _exhaleSeconds;

    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
        _inhaleSeconds = 4;
        _exhaleSeconds = 4;
    }

    // Lets the user choose how long to breathe in and out.
    private void ChoosePattern()
    {
        Console.WriteLine();
        Console.WriteLine("Choose a breathing pattern:");
        Console.WriteLine("1. Balanced (4 seconds in, 4 seconds out)");
        Console.WriteLine("2. Relaxation (4 seconds in, 6 seconds out)");
        Console.WriteLine("3. Custom breathing pattern");
        Console.WriteLine();

        int choice;

        while (true)
        {
            choice = ReadPositiveInt("Select a pattern (1-3): ");

            if (choice >= 1 && choice <= 3)
            {
                break;
            }

            Console.WriteLine("Please select 1, 2, or 3.");
        }

        switch (choice)
        {
            case 1:
                _inhaleSeconds = 4;
                _exhaleSeconds = 4;
                break;

            case 2:
                _inhaleSeconds = 4;
                _exhaleSeconds = 6;
                break;

            case 3:
                Console.WriteLine();
                Console.WriteLine("Create your own breathing pattern.");

                _inhaleSeconds = ReadPositiveInt(
                    "How many seconds would you like to breathe in? "
                );

                _exhaleSeconds = ReadPositiveInt(
                    "How many seconds would you like to breathe out? "
                );

                break;
        }

        Console.WriteLine();
        Console.WriteLine(
            $"Your breathing pattern is {_inhaleSeconds} seconds in and {_exhaleSeconds} seconds out."
        );
    }

    public void Run()
    {
        DisplayStartingMessage();

        ChoosePattern();

        DisplayGetReady();

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            Console.WriteLine();
            Console.Write("Breathe in... ");

            int secondsLeft = (int)Math.Ceiling(
                (endTime - DateTime.Now).TotalSeconds
            );

            int inhaleTime = Math.Min(
                _inhaleSeconds,
                secondsLeft
            );

            ShowCountDown(inhaleTime);

            if (DateTime.Now >= endTime)
            {
                break;
            }

            Console.WriteLine();
            Console.Write("Now breathe out... ");

            secondsLeft = (int)Math.Ceiling(
                (endTime - DateTime.Now).TotalSeconds
            );

            int exhaleTime = Math.Min(
                _exhaleSeconds,
                secondsLeft
            );

            ShowCountDown(exhaleTime);
        }

        DisplayEndingMessage();
    }
}