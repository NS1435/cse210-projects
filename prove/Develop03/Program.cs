// EXCEEDING REQUIREMENTS
// - Scripture library: the program picks a random scripture from a library
//   (Philippians 4:13, John 3:16, Proverbs 3:5-6).
// - Difficulty levels (Easy, Medium, Hard): each hides a percentage of the words
//   per round, and each round hides slightly fewer words than the last.
// - Hints: type "hint" to reveal one letter of a hidden word, alternating
//   between a first letter and a last letter.
// - Recall test: when every word is hidden, the user types the scripture from
//   memory and the program scores the accuracy.
// - Scoring and progress: score uses a difficulty multiplier, a hint penalty,
//   and a streak bonus. Sessions are saved to a text file, which tracks
//   consecutive practice days.
// - Hidden words are never picked again (the stretch challenge).


using System;

class Program
{
    static void Main(string[] args)
    {
        // Create the library and pick a random scripture from it
        ScriptureLibrary library = new ScriptureLibrary();
        Scripture scripture = library.GetRandomScripture();

        // Create a Difficulty object
        Difficulty difficulty = new Difficulty();

        // Ask the user to choose a difficulty level
        difficulty.ChooseDifficulty();

        // Counts how many times the user has pressed Enter to hide words
        int round = 0;

        // A short message shown under the scripture (used for hint feedback)
        string message = "";

        // Continue until the user quits or all words are hidden
        while (true)
        {
            // Clear the console
            Console.Clear();

            // Display the scripture
            Console.WriteLine(scripture.GetDisplayText());

            // Check whether all words are hidden
            if (scripture.IsCompletelyHidden())
            {
                // Recall round: the user types the verse from memory
                Console.WriteLine();
                Console.WriteLine("All words are hidden. Now type the verse from memory:");
                Console.WriteLine();

                string attempt = Console.ReadLine() ?? "";

                // Compare the attempt to the original text
                RecallChecker checker = new RecallChecker();
                double accuracy = checker.GetAccuracy(scripture.GetOriginalText(), attempt);

                // Load saved progress and get the streak the user came in with
                ProgressTracker tracker = new ProgressTracker();
                int streakDays = tracker.GetStreakBeforeToday();

                // Turn the accuracy into a score
                ScoreCalculator calculator = new ScoreCalculator();
                int hintsUsed = scripture.GetHintsUsed();
                int score = calculator.CalculateScore(accuracy, hintsUsed, difficulty.GetMultiplier(), streakDays);

                // Save this session
                SessionRecord record = new SessionRecord(
                    DateTime.Today,
                    scripture.GetReferenceText(),
                    difficulty.GetName(),
                    round,
                    hintsUsed,
                    (int)Math.Round(accuracy),
                    score
                );
                tracker.AddSession(record);

                Console.WriteLine();
                Console.WriteLine($"Accuracy: {accuracy:F0}%");
                Console.WriteLine($"Hints used: {hintsUsed}");
                Console.WriteLine($"Difficulty multiplier: x{difficulty.GetMultiplier():F1}");
                Console.WriteLine($"Score: {score}");
                Console.WriteLine($"Current streak: {tracker.GetCurrentStreak()} day(s)");
                Console.WriteLine();
                Console.WriteLine("The original text:");
                Console.WriteLine(scripture.GetOriginalText());
                break;
            }

            // Show any message from the last action, then clear it
            if (message != "")
            {
                Console.WriteLine();
                Console.WriteLine(message);
                message = "";
            }

            // Ask the user what to do next
            Console.WriteLine();
            Console.Write("Press Enter to hide words, type 'hint' for a hint, or 'quit' to exit: ");

            string input = (Console.ReadLine() ?? "").Trim().ToLower();

            // Exit if the user types quit
            if (input == "quit")
            {
                break;
            }

            // Give a hint without hiding more words or advancing the round
            if (input == "hint")
            {
                bool gaveHint = scripture.GiveHint();

                if (!gaveHint)
                {
                    message = "No more hints available.";
                }

                continue;
            }

            // Hide random words, fewer each round
            int numberToHide = difficulty.GetWordsToHide(scripture.GetWordCount(), round);
            scripture.HideRandomWords(numberToHide);
            round++;
        }
    }
}