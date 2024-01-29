using System;

public class Activity
{
// ATTRIBUTES
    private string _name;
    private string _description;
    protected int _duration;
// CONSTRUCTORS
    public Activity()
    {

    }
    public Activity(string name, string desc)
    {
        _name = name;
        _description = desc;
    }
// METHODS
    public void DisplayStartingMessage()
    {
        Console.WriteLine($"Welcome to the {_name} Activity.\n");
        Console.WriteLine($"{_description}\n");
        Console.Write("In seconds, how long would you like your session to be? ");
        _duration = Int32.Parse(Console.ReadLine());
        Console.Clear();
        Console.WriteLine("We're going to start in a few moments...");
        ShowSpinner(2);
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine($"\nThat's all. Thank you for spending {_duration} seconds of mindfullness on our {_name} Activity today!");
        ShowSpinner(2);
    }
    public void ShowSpinner(int seconds)
    {
        string[] anim = {"|","/","=","\\","|","/","=","\\"};
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        while (DateTime.Now < endTime)
        {
            foreach (string a in anim)
            {    
                Console.Write(a);
                Thread.Sleep(500);
                Console.Write("\b \b");
            }
        }
    }
    public void ShowCountDown(int seconds)
    {
        if (seconds < 9)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
        else if (seconds < 99)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b \b");
            }
        }
        else if (seconds < 999)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b \b \b");
            }
        }
    }
}