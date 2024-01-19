using System;

class Program
{
    static void Main(string[] args)
    {
        Boolean ongoing = true;
        Console.WriteLine("Welcome to your Journal!");

        Journal myJournal = new Journal();
        myJournal._entries = new List<Entry>();

        Console.WriteLine("What do you want to do?");
        
        while (ongoing)
        {
            Console.WriteLine("1. Write\n2. Display\n3. Load\n4. Save\n5. Quit");
            Console.WriteLine("Enter a number.");
            string input = Console.ReadLine();

            // 1. WRITE
            if (input == "1") 
            {
                Entry newEntry = new Entry();
                myJournal.AddEntry(newEntry);
            }
            // 2. DISPLAY
            else if (input == "2")
            {
                if (myJournal._entries.Count == 0 )
                {
                    Console.WriteLine("There aren't any entries yet!"); 
                }
                else 
                {
                    myJournal.DisplayAllEntries();
                }
            }
            // 3. LOAD FILE
            else if (input == "3")
            {
                Console.WriteLine("What file would you like to load? (file_name_format.txt)");
                string fileName = Console.ReadLine();

                myJournal.LoadFile(fileName);
            }
            // 4. SAVE FILE
            else if (input == "4")
            {
                Console.WriteLine("What is the file name? (file_name_format.txt)");
                string fileName = Console.ReadLine();

                myJournal.SaveFile(fileName);
            }
            // 5. QUIT
            else if (input == "5")
            {
                ongoing = false;
            }
        }
        

        
        
    }
}