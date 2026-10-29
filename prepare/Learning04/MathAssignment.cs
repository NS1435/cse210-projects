using System;

// Derived class representing a math assignment
public class MathAssignment : Assignment
{
    // Store information specific to math assignments
    private string _textbookSection;
    private string _problems;

    // Constructor receives all assignment information
    // The base constructor handles the student name and topic
    public MathAssignment(
        string studentName,
        string topic,
        string textbookSection,
        string problems)
        : base(studentName, topic)
    {
        _textbookSection = textbookSection;
        _problems = problems;
    }

    // Return the textbook section and assigned problems
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}