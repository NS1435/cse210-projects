using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";

        while (playAgain == "yes")
        {
            // Generate a random magic number from 1 to 100
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = 0;
            int guessCount = 0;

            // Keep asking until the user guesses correctly
            while (guess != magicNumber)
            {
                Console.Write("Please guess a number: ");
                guess = int.Parse(Console.ReadLine());

                // Add one every time the user guesses
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            // Tell the user how many guesses they made
            Console.WriteLine($"It took you {guessCount} guesses.");

            // Ask if they want another game
            Console.Write("Do you want to play again? ");
            playAgain = Console.ReadLine();
        }
    }
}