using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Boolean ongoing = true;

        string[] lines = System.IO.File.ReadAllLines("scriptures.txt");
        List<string> scriptures = new List<string>();
        List<string> references = new List<string>();
        // Split into list of references and scriptures, 
        foreach (string line in lines)
        {
            string[] splitLines = line.Split("|");
            references.Add(splitLines[0]);
            scriptures.Add(splitLines[1]); 
        }
        Random rnd = new Random();
        // Creating a Random() object, to select a random scripture from my text file list
        // and to be used later to decide the amount of words to be hidden.
        int r = rnd.Next(scriptures.Count);
        Scripture memorizedScripture = new Scripture(references[r], scriptures[r]);
        // Scripture memorizedScripture = new Scripture("Ella 4:6-4", "I can't do this anymore.");
        Console.Clear();
        // While loop that runs the program
        while (ongoing)
        {       
            Console.WriteLine(memorizedScripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press enter to continue, or type 'quit' to stop.");
            string input = Console.ReadLine();
            // If statments
            if (input == "quit" || input == "Quit") 
            {
                ongoing = false;
            }
            else if (memorizedScripture.IsCompletelyHidden())
            {
                ongoing = false;
            }
            else
            {
                Console.Clear();
                int i = rnd.Next(1,5);
                memorizedScripture.HideRandomWords(i);
            }
        }
        // Finished program farewell message
        Console.WriteLine("See you next time!");
    }
}