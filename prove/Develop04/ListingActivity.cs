using System;

public class ListingActivity : Activity
{
// ATTRIBUTES
    private int _count; // I don't know why these two attributes have yellow underlines
    private List<string> _prompts = new List<string>(File.ReadAllLines("list-prompts.txt"));

// CONSTRUCTOR
    public ListingActivity(string name, string desc) : base(name, desc)
    {

    }
// METHODS
    public void Run()
    {
        // STARTING MESSAGE(S)
        this.DisplayStartingMessage();
        Console.WriteLine("List as many responses as you can to the following prompt:\n");
        GetRandomPrompt();
        Console.Write("\nYou can begin in: ");
        this.ShowCountDown(5);
        Console.WriteLine();
        // LIST INPUT
        GetListFromUser();
        Console.WriteLine($"You listed {_count} items!\n");
        // END MESSAGE
        Console.WriteLine("Well done!");
        this.DisplayEndingMessage();
    }
    // GETTERS
    private void GetRandomPrompt()
    {
        Random random = new Random();
        int i = random.Next(_prompts.Count); // Choosing random prompt

        Console.Write($"---{_prompts[i]}---\n");
    }
    
    public List<string> GetListFromUser()
    {
        List<string> responses = new List<string>();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration); // Setting variable so while loop with run for _duration

        while (DateTime.Now < endTime) // While loop for user entries
        {
            Console.Write("> ");
            responses.Add(Console.ReadLine());  
        }
        _count = responses.Count; // set _count to the amount of responses
        return responses;
    }
}