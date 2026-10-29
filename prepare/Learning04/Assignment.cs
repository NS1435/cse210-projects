using System;

// Base class for all assignment types
public class Assignment
{
    // Store information shared by all assignments
    private string _studentName;
    private string _topic;

    // Constructor initializes the student's name and assignment topic
    public Assignment(string studentName, string topic)
    {
        _studentName = studentName;
        _topic = topic;
    }

    // Return a summary containing the student's name and topic
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // Allow derived classes to access the student's name
    // without directly accessing the private variable
    public string GetStudentName()
    {
        return _studentName;
    }
}