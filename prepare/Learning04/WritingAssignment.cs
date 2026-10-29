using System;

// Derived class representing a writing assignment
public class WritingAssignment : Assignment
{
    // Store the title specific to writing assignments
    private string _title;

    // Constructor initializes the writing assignment
    // The base constructor handles the student name and topic
    public WritingAssignment(string studentName, string topic, string title)
        : base(studentName, topic)
    {
        _title = title;
    }

    // Return the writing assignment title and student's name
    // GetStudentName() is inherited from the Assignment class
    public string GetWritingInformation()
    {
        return $"{_title} by {GetStudentName()}";
    }
}