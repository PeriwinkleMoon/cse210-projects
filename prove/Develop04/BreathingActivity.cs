using System;

public class BreathingActivity : Activity
{
// CONSTRUCTOR
    public BreathingActivity(string name, string desc) : base(name, desc)
    {

    }
// METHOD
    public void Run()
    {
        this.DisplayStartingMessage();
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration); // Setting variable so while loop with run for _duration

        while (DateTime.Now < endTime)
        {
            Console.Write($"\nBreeeathe in through your nose...");
            this.ShowCountDown(5);
            
            Console.Write("\nHold it...");
            this.ShowCountDown(3);
            
            Console.Write("\nBreathe ooout through your mouth...");
            this.ShowCountDown(4);

            Thread.Sleep(1000);
            Console.WriteLine();
        }

        this.DisplayEndingMessage();
    }
}