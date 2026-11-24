public class EternalGoal : Goal
{
    public EternalGoal(string title, string description, int points) : base(title, description, points)
    {
    }

    public override int RecordEvent()
    {
        return GetPoints();
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string Save()
    {
        return $"EternalGoal:{GetTitle()},{GetDescription()},{GetPoints()}";
    }
}