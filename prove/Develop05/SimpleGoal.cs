public class SimpleGoal : Goal
{
    private bool _complete;

    public SimpleGoal(string title, string description, int points) : base(title, description, points)
    {
        _complete = false;
    }

    public override int RecordEvent()
    {
        if (!_complete)
        {
            _complete = true;
            return GetPoints();
        }
        return 0;
    }

    public override bool IsComplete()
    {
        return _complete;
    }

    public override string Save()
    {
        return $"SimpleGoal:{GetTitle()},{GetDescription()},{GetPoints()},{_complete}";
    }

    public SimpleGoal(string title, string description, int points, bool complete) : base(title, description, points)
    {
        _complete = complete;
    }
}