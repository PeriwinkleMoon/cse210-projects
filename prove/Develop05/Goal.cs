using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected string _points;
// CONSTRUCTOR
    public Goal()
    {
    }
    public Goal(string name, string desc, string points)
    {
        _shortName = name;
        _description = desc;
        _points = points;
    }
// GETTERS
    public string GetName()
    {
        return _shortName;
    }
    public string GetDescription()
    {
        return _description;
    }
    public string GetPoints()
    {
        return _points;
    }
// METHODS
    public abstract int RecordEvent();

    public abstract bool IsComplete();

    public virtual string GetDetailsString()
    {
        return "";
    }
 
    public abstract string GetStringRepresentation();
}