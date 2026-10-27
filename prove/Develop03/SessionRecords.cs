using System;

public class SessionRecord
{
    // Private attributes
    private DateTime _date;
    private string _reference;
    private string _difficulty;
    private int _rounds;
    private int _hintsUsed;
    private int _accuracy;
    private int _score;

    // Constructor for a brand-new session
    public SessionRecord(DateTime date, string reference, string difficulty, int rounds, int hintsUsed, int accuracy, int score)
    {
        _date = date;
        _reference = reference;
        _difficulty = difficulty;
        _rounds = rounds;
        _hintsUsed = hintsUsed;
        _accuracy = accuracy;
        _score = score;
    }

    // Constructor that rebuilds a record from a line saved in the file
    public SessionRecord(string line)
    {
        string[] parts = line.Split('|');

        _date = DateTime.Parse(parts[0]);
        _reference = parts[1];
        _difficulty = parts[2];
        _rounds = int.Parse(parts[3]);
        _hintsUsed = int.Parse(parts[4]);
        _accuracy = int.Parse(parts[5]);
        _score = int.Parse(parts[6]);
    }

    // Returns the date this session was completed
    public DateTime GetDate()
    {
        return _date;
    }

    // Turns the record into one line of text for the file
    public string ToLine()
    {
        return $"{_date:yyyy-MM-dd}|{_reference}|{_difficulty}|{_rounds}|{_hintsUsed}|{_accuracy}|{_score}";
    }
}