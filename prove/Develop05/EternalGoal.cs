using System;

public class EternalGoal : Goal
{
// CONSTRUCTOR
    public EternalGoal(string name, string desc, string points) : base(name, desc, points)
    {

    }
// METHODS
    public override int RecordEvent()
    {
        Console.WriteLine($"Event Recorded! You earned {this._points} points!");
        int x = Int32.Parse(_points);
        return x;
    }
    public override bool IsComplete()
    {
        return false;
    }
    public override string GetStringRepresentation()
    {
        return $"[   ] {this._description}";
    }
}