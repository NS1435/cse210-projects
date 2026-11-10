using System;

class Program
{
    static void Main(string[] args)
    {
        // Creativity:
        // 1. Added three breathing patterns, including a custom option.
        // 2. Reflection questions don't repeat until all have been used.
        // 3. Tracks completed activities and total session time.

        int activitiesCompleted = 0;
        int totalSeconds = 0;

        BreathingActivity breathing = new BreathingActivity();
        ReflectionActivity reflection = new ReflectionActivity();
        ListingActivity listing = new ListingActivity();

        bool running = true;

        while (running)
        {
            Console.Clear();

            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.WriteLine();

            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine() ?? "";

            switch (choice)
            {
                case "1":
                    breathing.Run();

                    activitiesCompleted++;
                    totalSeconds += breathing.GetDuration();

                    break;

                case "2":
                    reflection.Run();

                    activitiesCompleted++;
                    totalSeconds += reflection.GetDuration();

                    break;

                case "3":
                    listing.Run();

                    activitiesCompleted++;
                    totalSeconds += listing.GetDuration();

                    break;

                case "4":
                    running = false;
                    break;

                default:
                    Console.WriteLine();
                    Console.WriteLine("Invalid choice. Please select 1-4.");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }

            if (running && (choice == "1" || choice == "2" || choice == "3"))
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to return to the menu...");
                Console.ReadLine();
            }
        }

        Console.Clear();

        Console.WriteLine("Thank you for using the Mindfulness Program!");
        Console.WriteLine();

        Console.WriteLine("Session Statistics:");
        Console.WriteLine($"Activities completed: {activitiesCompleted}");
        Console.WriteLine($"Total requested activity time: {totalSeconds} seconds");

        Console.WriteLine();
        Console.WriteLine("Goodbye!");
    }
}