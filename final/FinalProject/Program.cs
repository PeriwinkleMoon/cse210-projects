using System;

class Program
{
    static void Main(string[] args)
    {
        Random rnd = new Random();
        /*
        Introductory text
        Set random player 
        // */
        // Console.Clear();
        Player pc = new Player();
        Console.WriteLine("Welcome to C# Dungeon Divers!\n\nHere's your starting gear:\n");
        pc.RollPC();
        Console.ReadLine();
        Run run = new Run(pc);
        run.Start();
    }
}