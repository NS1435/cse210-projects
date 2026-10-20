using System;
class Program
{
    static void Main(string[] args)
    {
        // Test the default constructor (1/1)
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());
        Console.WriteLine(f1.GetDecimalValue());

        // Test the one-parameter constructor (5/1)
        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());
        Console.WriteLine(f2.GetDecimalValue());

        // Test the two-parameter constructor (3/4)
        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());
        Console.WriteLine(f3.GetDecimalValue());

        // Test another fraction (1/3)
        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());
        Console.WriteLine(f4.GetDecimalValue());

        // Test the getters
        Console.WriteLine("\nTesting Getters:");
        Console.WriteLine($"Top: {f3.GetTop()}");
        Console.WriteLine($"Bottom: {f3.GetBottom()}");

        // Test the setters
        Console.WriteLine("\nTesting Setters:");
        f3.SetTop(7);
        f3.SetBottom(8);
        Console.WriteLine($"Updated fraction: {f3.GetFractionString()}");
        Console.WriteLine($"Updated top: {f3.GetTop()}");
        Console.WriteLine($"Updated bottom: {f3.GetBottom()}");
        Console.WriteLine($"Decimal value: {f3.GetDecimalValue()}");

        // Test denominator validation
        Console.WriteLine("\nTesting Denominator Validation:");
        f3.SetBottom(0);
        Console.WriteLine($"Fraction after setting bottom to 0: {f3.GetFractionString()}");
        
        // Generate 20 random fractions
        Console.WriteLine("\nRandom Fractions:");
        Random random = new Random();
        Fraction f5 = new Fraction();
        for (int i = 0; i < 20; i++)
        {
            int topValue = random.Next(1, 11);
            int bottomValue = random.Next(1, 11);
            f5.SetTop(topValue);
            f5.SetBottom(bottomValue);
            Console.WriteLine($"Fraction {i + 1}: string: {f5.GetFractionString()} Number: {f5.GetDecimalValue()}");
        }
    }
}