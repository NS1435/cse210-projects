using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();

        int userNumber = -1;

        while (userNumber != 0)
        {
            Console.Write("Enter a number (0 to quit): ");

            string userResponse = Console.ReadLine();
            userNumber = int.Parse(userResponse);

            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        }

        // Make sure the user actually entered some numbers
        if (numbers.Count > 0)
        {
            // Part 1: Compute the sum
            int sum = 0;

            foreach (int number in numbers)
            {
                sum += number;
            }

            Console.WriteLine($"The sum is: {sum}");

            // Part 2: Compute the average
            float average = ((float)sum) / numbers.Count;

            Console.WriteLine($"The average is: {average}");

            // Part 3: Find the largest number
            int max = numbers[0];

            foreach (int number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }

            Console.WriteLine($"The largest number is: {max}");

            // Stretch 1: Find the smallest positive number
            int smallestPositive = 0;

            foreach (int number in numbers)
            {
                if (number > 0)
                {
                    if (smallestPositive == 0 || number < smallestPositive)
                    {
                        smallestPositive = number;
                    }
                }
            }

            if (smallestPositive > 0)
            {
                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
            }
            else
            {
                Console.WriteLine("There were no positive numbers.");
            }

            // Stretch 2: Sort the list
            numbers.Sort();

            Console.WriteLine("The sorted list is:");

            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
        }
        else
        {
            Console.WriteLine("No numbers were entered.");
        }
    }
}