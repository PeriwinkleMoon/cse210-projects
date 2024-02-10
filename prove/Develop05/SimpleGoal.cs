using System;

public class SimpleGoal : Goal
{
// ATTRIBUTES
    private bool _isComplete = false;
// CONSTRUCTOR
    public SimpleGoal(string name, string desc, string points) : base(name, desc, points)
    {

    }
// METHODS
    public override int RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Event Recorded! You earned {this._points} points!");
        int x = Int32.Parse(_points);
        return x;
    }
    public override bool IsComplete()
    {
        return _isComplete;
    }
    public override string GetStringRepresentation()
    {
        if (IsComplete())
        {
            return $"[ X ] {this._description}";
        }
        else
        {
            return $"[   ] {this._description}";
        }
    }
}