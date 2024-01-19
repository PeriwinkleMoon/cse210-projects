using System;
using System.IO; 

public class Journal
{
    public List<Entry> _entries;
    // Add Entry : void
    public void AddEntry(Entry newEntry)
    { 
        // Getting prompt
        PromptGenerator prompt = new PromptGenerator();
        newEntry._promptText = prompt.GetRandom();
        // Printing prompt
        Console.WriteLine($"Today's journaling prompt: {newEntry._promptText}");
        newEntry._entryText = Console.ReadLine();
        // Saving date
        DateTime theCurrentTime = DateTime.Now;
        newEntry._date = theCurrentTime.ToShortDateString();
        // Adding to entries list
        _entries.Add(newEntry);
    }
    // Display all Entries : void
    public void DisplayAllEntries()
    {
        foreach (Entry e in _entries)
        {
            e.Display();
            Console.WriteLine();
        }
    }
    // Load from a file : string
    public void LoadFile(string fileName)
    {
        string[] lines = System.IO.File.ReadAllLines(fileName);

        foreach (string line in lines)
        {
            Entry newEntry = new Entry();

            string[] parts = line.Split("|");

            newEntry._date = parts[0];
            newEntry._promptText = parts[1];
            newEntry._entryText = parts[2];

            _entries.Add(newEntry);
        }

    }
    // Save file : string
    public void SaveFile(string fileName)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            foreach (Entry e in _entries)
            {
                outputFile.WriteLine($"{e._date}|{e._promptText}|{e._entryText}");
            }  
        }
    }
    
}