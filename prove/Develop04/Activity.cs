using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public int GetDuration()
    {
        return _duration;
    }

    protected void DisplayStartingMessage()
    {
        Console.Clear();

        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();

        Console.WriteLine(_description);
        Console.WriteLine();

        _duration = ReadPositiveInt(
            "How long, in seconds, would you like for your session? "
        );
    }

    protected void DisplayGetReady()
    {
        Console.WriteLine();
        Console.Write("Get ready...");

        ShowSpinner(5);

        Console.WriteLine();
    }

    protected void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");

        ShowSpinner(3);

        Console.WriteLine();
        Console.WriteLine(
            $"You have completed another {_duration} seconds"
        );

        Console.WriteLine($"of the {_name}.");

        ShowSpinner(3);
        Console.WriteLine();
    }

    protected void ShowSpinner(int seconds)
    {
        List<string> frames = new List<string>
        {
            "|", "/", "-", "\\"
        };

        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        int index = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(frames[index]);

            Thread.Sleep(250);

            Console.Write("\b \b");

            index++;

            if (index >= frames.Count)
            {
                index = 0;
            }
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);

            Thread.Sleep(1000);

            int digits = i.ToString().Length;

            for (int j = 0; j < digits; j++)
            {
                Console.Write("\b \b");
            }
        }
    }

    protected int ReadPositiveInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);

            string input = Console.ReadLine() ?? "";

            int number;

            bool worked = int.TryParse(input, out number);

            if (worked && number > 0)
            {
                return number;
            }

            Console.WriteLine(
                "Please enter a whole number greater than zero."
            );
        }
    }
}