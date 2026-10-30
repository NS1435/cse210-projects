using System;

public class Program
{
    public static void Main(string[] args)
    {
        // EXCEEDING REQUIREMENTS:
        // The user can choose from five writing categories
        // or select Surprise Me.
        // These categories were inspired by LearningExpress's
        // 501 Writing Prompts.

        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        string choice = "";

        while (choice != "5")
        {
            Console.WriteLine("\nWelcome to the Journal Program!");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            choice = Console.ReadLine() ?? "";

            if (choice == "1")
            {
                Console.WriteLine("\nChoose a writing category:");
                Console.WriteLine("1. Daily Reflection");
                Console.WriteLine("2. Persuasive Writing");
                Console.WriteLine("3. Expository Writing");
                Console.WriteLine("4. Narrative Writing");
                Console.WriteLine("5. Literary Response");
                Console.WriteLine("6. Surprise Me!");
                Console.Write("Your choice: ");

                string category = Console.ReadLine() ?? "";
                string prompt = "";

                if (category == "1")
                {
                    prompt = promptGenerator.GetRandomPrompt(
                        promptGenerator._dailyPrompts);
                }
                else if (category == "2")
                {
                    prompt = promptGenerator.GetRandomPrompt(
                        promptGenerator._persuasivePrompts);
                }
                else if (category == "3")
                {
                    prompt = promptGenerator.GetRandomPrompt(
                        promptGenerator._expositoryPrompts);
                }
                else if (category == "4")
                {
                    prompt = promptGenerator.GetRandomPrompt(
                        promptGenerator._narrativePrompts);
                }
                else if (category == "5")
                {
                    prompt = promptGenerator.GetRandomPrompt(
                        promptGenerator._literaryPrompts);
                }
                else if (category == "6")
                {
                    prompt = promptGenerator.GetSurprisePrompt();
                }
                else
                {
                    Console.WriteLine("Invalid category.");
                    continue;
                }

                Console.WriteLine($"\n{prompt}");
                Console.Write("> ");

                string response = Console.ReadLine() ?? "";

                Entry entry = new Entry();

                entry._date = DateTime.Now.ToShortDateString();
                entry._promptText = prompt;
                entry._entryText = response;

                journal.AddEntry(entry);

                Console.WriteLine("Entry added to journal!");
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What filename would you like to load? ");
                string filename = Console.ReadLine() ?? "";

                try
                {
                    journal.LoadFromFile(filename);
                    Console.WriteLine("Journal loaded.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        $"Could not load journal: {ex.Message}");
                }
            }
            else if (choice == "4")
            {
                Console.Write("What filename would you like to save to? ");
                string filename = Console.ReadLine() ?? "";

                try
                {
                    journal.SaveToFile(filename);
                    Console.WriteLine("Journal saved.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        $"Could not save journal: {ex.Message}");
                }
            }
            else if (choice == "5")
            {
                Console.WriteLine("Goodbye!");
            }
            else
            {
                Console.WriteLine(
                    "Invalid choice. Please try again.");
            }
        }
    }
}