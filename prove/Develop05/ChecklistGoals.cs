public class ChecklistGoal : Goal
{
    private int _currentlyCompleted;
    private int _repeatGoal;
    private int _bonus;

    public ChecklistGoal(string title, string description, int points, int repeatGoal, int bonus) : base(title, description, points)
    {
        _currentlyCompleted = 0;
        _repeatGoal = repeatGoal;
        _bonus = bonus;
    }

    public ChecklistGoal(string title, string description, int points, int repeatGoal, int bonus, int currentlyCompleted) : base(title, description, points)
    {
        _currentlyCompleted = currentlyCompleted;
        _repeatGoal = repeatGoal;
        _bonus = bonus;
    }

    public override int RecordEvent()
    {
        if (_currentlyCompleted >= _repeatGoal)
        {
            return 0;
        }

        _currentlyCompleted++;

        if (_currentlyCompleted == _repeatGoal)
        {
            return GetPoints() + _bonus;
        }

        return GetPoints();
    }

    public override bool IsComplete()
    {
        return _currentlyCompleted >= _repeatGoal;
    }

    public override void Display()
    {
        string checkbox = IsComplete() ? "[X]" : "[ ]";

        Console.WriteLine($"{checkbox} {GetTitle()} ({GetDescription()}) -- Completed {_currentlyCompleted}/{_repeatGoal} times");
    }

    public override string Save()
    {
        return $"ChecklistGoal:{GetTitle()},{GetDescription()},{GetPoints()},{_repeatGoal},{_bonus},{_currentlyCompleted}";
    }
}