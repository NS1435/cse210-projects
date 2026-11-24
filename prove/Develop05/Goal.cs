public class Goal
{
    private string _title;
    private string _description;
    private int _points;

    public Goal(string title, string description, int points)
    {
        _title = title;
        _description = description;
        _points = points;
    }

    public string GetTitle()
    {
        return _title;
    }

    public string GetDescription()
    {
        return _description;
    }

    public int GetPoints()
    {
        return _points;
    }

    public virtual int RecordEvent()
    {
        return 0;
    }

    public virtual bool IsComplete()
    {
        return false;
    }

    public virtual void Display()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";

        Console.WriteLine($"{checkbox} {_title} ({_description})");
    }

    public virtual string Save()
    {
        return $"Goal:{_title},{_description},{_points}";
    }
}