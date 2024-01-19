using System;

public class PromptGenerator
{
    // Get random prompt: return string
    public string GetRandom()
    {   // Read a text file line by line. 
        string[] prompts = File.ReadAllLines("journal_prompts.txt");

        Random random = new Random();
        int i = random.Next(prompts.Length);

        return prompts[i];
    }
}