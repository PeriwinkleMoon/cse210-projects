using System;

public class ChecklistGoal : Goal
{
// ATTRIBUTES
    private int _amountCompleted = 0;
    private int _target;
    public int _bonus;
// CONSTRUCTOR
    public ChecklistGoal(string name, string desc, string points, int target, int bonus) : base(name, desc, points)
    {
        _target = target;
        _bonus = bonus;
    }
// METHODS
    public override int RecordEvent()
    {
        _amountCompleted += 1;
        
        if (_amountCompleted < _target)
        {
            Console.WriteLine($"Event Recorded! You earned {this._points} points!");
            int x = Int32.Parse(_points);
            return x;
        }
        else if (IsComplete())
        {
            Console.WriteLine($"Event Recorded! You earned {this._points} points!");
            Console.WriteLine();
            Console.WriteLine($"WOW! Good job meeting your goal! You get a {_bonus} point bonus!");
            int x = Int32.Parse(_points);
            return _bonus + x;
        }
        else
        {
            return 0;
        }
    }
    public override bool IsComplete()
    {
        if (_amountCompleted >= _target)
        {
            return true;
        }
        else
        {
            return false;            
        }
    }
    public override string GetDetailsString()
    {
        return $"{_amountCompleted}/{_target}";
    }
    public override string GetStringRepresentation()
    {
        string times = this.GetDetailsString();
        if (IsComplete())
        {
            return $"[ X ] {this._description} -- Completed {times} times.";
        }
        else
        {
            return $"[   ] {this._description} -- Completed {times} times.";
        }

    }
}