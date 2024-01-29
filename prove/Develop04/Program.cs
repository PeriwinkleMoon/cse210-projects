using System;

class Program
{
    static void Main(string[] args)
    {
        bool ongoing = true;
        
        while (ongoing)
        {   
            Console.Clear();
            Console.WriteLine("Menu Selections:");
            Console.WriteLine("1. Start breathing activity\n2. Start reflecting activity\n3. Start listing activity\n4. Quit");
            Console.WriteLine("Enter a number to select your choice.");
            string input = Console.ReadLine();
        // MENU OPTIONS OUTCOME
            // 1. Breathing Activity
            if (input == "1") 
            {
                Console.Clear();
                BreathingActivity breathingAct = new BreathingActivity("Breathing", 
                "We can be mindful by taking the time to breathe. In this activity we will breathe in and out slowly, holding each breath. Try to relax and clear your mind.");

                breathingAct.Run();
            }
            // 2. Reflecting Activity
            else if (input == "2")
            {
                Console.Clear();
                ReflectingActivity reflectingAct = new ReflectingActivity("Reflecting", 
                "We can be mindful by taking the time to reflect. In this activity we will ponder some thoughtful prompts and questions. Take your time, and listen to the promptings of your own body and spirit.");

                reflectingAct.Run();
            }
            // 3. Listing Activity
            else if (input == "3")
            {
                Console.Clear();
                ListingActivity listingAct = new ListingActivity("Listing", 
                "We can be mindful by taking the time to be grateful. In this activity you'll be given a graditude prompt, afterward you will list as many things as you can pertaining to the prompt.");

                listingAct.Run();
            }
            // 4. Quit
            else if (input == "4")
            {
                Console.Clear();
                Console.WriteLine("Thanks for being mindful, see you next time!");
                Thread.Sleep(2000);
                ongoing = false;
            }
        }
        
    }
}