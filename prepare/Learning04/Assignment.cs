using System;

public class Assigment
{
    protected string _studentName = "";
    private string _topic = "";

    public Assigment()
    {
        _studentName = "Anonymous";
        _topic = "Unknown";
    }
    public Assigment(string name, string topic)
    {
        _studentName = name;
        _topic = topic;
    }

    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }
}