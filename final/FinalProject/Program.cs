using System;
// my throat hurts so bad 
class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
    // Start program
        Console.Clear();
        Console.WriteLine("Welcome to C# Dungeon Divers!\n\nHere's your starting gear:\n\n+++++++++++++++++++++++++++++++++");
    // Create new random player
        Player pc = new Player(); 
        pc.RollPC();
        Console.Write("+++++++++++++++++++++++++++++++++\n\nEnter to continue >");
        Console.ReadLine();
    // New run
        bool ongoing = true;
        while (ongoing)
        {
            Run run = new Run(pc);
            ongoing = run.Start();
            bool query = true;
            if (run.End())
            {
                while (query)
                {
                    Console.WriteLine("Would you like to go for another dive in the dungeon?");
                    Console.Write("1. GO AGAIN!   2. QUIT >");
                    string x = Console.ReadLine();
                    int input = Int32.Parse(x);
                    if (input == 1)
                    {
                        Console.WriteLine("After a nice nap and a hot meal you feel refreshed and ready for another go!");
                        Console.WriteLine("You make your descent once more into the dungeon, excited for another adventure.");
                    }
                    else if (input == 2)
                    {
                        Console.WriteLine("You decide you've had your share of that maze. No more adventuring for you!");
                        Console.WriteLine("It's time to go home and have a bath, and nap, and read a good book!\n");
                    }
                }
            }
        }
        Console.WriteLine("+++++++++++++++++++++++++++++++++");
        Console.WriteLine(" #@----THANKS FOR PLAYING!!----@#");  
        Console.WriteLine("+++++++++++++++++++++++++++++++++");
        Console.ReadLine();
    }
}