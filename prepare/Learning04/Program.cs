using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a math assignment with student and homework information
        MathAssignment math = new MathAssignment(
            "Roberto Rodriguez",
            "Fractions",
            "7.3",
            "8-19"
        );

        // Display the inherited summary and math-specific homework list
        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());

        Console.WriteLine();

        // Create a writing assignment with student and title information
        WritingAssignment writing = new WritingAssignment(
            "Mary Waters",
            "European History",
            "The Causes of World War II"
        );

        // Display the inherited summary and writing-specific information
        Console.WriteLine(writing.GetSummary());
        Console.WriteLine(writing.GetWritingInformation());
    }
}