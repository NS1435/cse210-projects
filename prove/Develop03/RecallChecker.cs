using System;
using System.Collections.Generic;

public class RecallChecker
{
    // Returns accuracy from 0 to 100: the percent of words typed correctly in the right position
    public double GetAccuracy(string original, string attempt)
    {
        List<string> originalWords = Normalize(original);
        List<string> attemptWords = Normalize(attempt);

        // Avoid dividing by zero
        if (originalWords.Count == 0)
        {
            return 0;
        }

        int correct = 0;

        for (int i = 0; i < originalWords.Count; i++)
        {
            // The attempt might be shorter than the original, so check the position exists
            if (i < attemptWords.Count && originalWords[i] == attemptWords[i])
            {
                correct++;
            }
        }

        return (double)correct / originalWords.Count * 100;
    }

    // Private helper: lowercases the text, removes punctuation, and splits it into words
    private List<string> Normalize(string text)
    {
        string cleaned = "";

        foreach (char c in text.ToLower())
        {
            if (char.IsLetterOrDigit(c) || c == ' ')
            {
                cleaned += c;
            }
        }

        string[] parts = cleaned.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return new List<string>(parts);
    }
}