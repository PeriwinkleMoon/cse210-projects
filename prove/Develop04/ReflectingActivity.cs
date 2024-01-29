using System;

public class ReflectingActivity : Activity
{
// ATTRIBUTES
    private List<string> _prompts = new List<string>(File.ReadAllLines("ref-prompts.txt"));
    private List<string> _questions = new List<string>(File.ReadAllLines("ref-questions.txt"));
    private List<int> askedQuestions = new List<int>(); // MAKING SURE THERE ARE NO DUPLICATE QUESTIONS
// CONSTRUCTORS
    public ReflectingActivity(string name, string desc) : base(name, desc)
    {

    }
// METHODS
    public void Run()
    {
        this.DisplayStartingMessage();
        Console.Clear();

        Console.WriteLine("Consider the following prompt:\n");
        this.DisplayPrompt();
        Console.WriteLine("\nOnce you have an experience in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now reflect on each of the following questions.");
        Console.Clear();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(_duration); // Setting variable so while loop with run for _duration

        while (DateTime.Now < endTime)
        {
            this.DisplayQuestions();
            Console.WriteLine();
        }

        this.DisplayEndingMessage();
    }
        private void DisplayPrompt()
    {
        Console.WriteLine($"---{GetRandomPrompt()}---");
    }
    private void DisplayQuestions()
    {
        Console.Write($"> {GetRandomQuestion()} ");
        this.ShowSpinner(10);

    }
    // GETTERS
    private string GetRandomPrompt()
    {
        Random random = new Random();
        int i = random.Next(_prompts.Count); // Choosing random prompt

        return _prompts[i];
    }
    private string GetRandomQuestion()
    {
        int i = 0;
        Random random = new Random(); // Choosing random question
        while (askedQuestions.Contains(i)) // While loop to check if question has already been asked
        {
            i = random.Next(_questions.Count);
        }
        askedQuestions.Add(i);

        return _questions[i];
    }
}