using System;

public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;

    // Print entry : void
    public void Display()
    {
        Console.WriteLine($"{_date}: {_promptText}");
        Console.WriteLine(_entryText);
    }
}
