public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    private int _target;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) 
        : base(name, description, points)
    {
        _timesCompleted = 0;
        _target = target;
        _bonus = bonus;
    }

    public override void RecordEvent()
    {
        _timesCompleted++;
        if (_timesCompleted == _target)
        {
            Console.WriteLine($"{_name} completed! You earned {_points} points plus a bonus of {_bonus} points.");
            _points += _bonus; // Add bonus to points
        }
        else
        {
            Console.WriteLine($"{_name} recorded! You earned {_points} points.");
        }
    }

    public override bool IsComplete()
    {
        return _timesCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        return $"Goal: {_name}, Description: {_description}, Points: {_points}, Completed: {_timesCompleted}/{_target}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_name},{_description},{_points},{_timesCompleted},{_target},{_bonus}";
    }

    public void SetTimesCompleted(int timesCompleted)
    {
        _timesCompleted = timesCompleted;
    }

}
