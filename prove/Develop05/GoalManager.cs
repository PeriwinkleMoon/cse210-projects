using System;
using System.IO;
using System.Runtime.CompilerServices;

public class GoalManager
{
// ATTRIBUTES
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
// CONSTRUCTOR
    public GoalManager()
    {

    }
// METHODS
    public void Start() // Main program
    {
        bool ongoing = true; // Starting Menu loop until "Quit" is selected.
        while (ongoing)
        {
            Console.Clear();
            this.DisplayPlayerInfo(); // Clearing console and displaying point total.
        // MAIN MENU
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal\n2. List Goals\n3. Save Goals\n4. Load Goals\n5. Record Event\n6. Quit");
            Console.Write("\nSelect a choice from the menu: ");
            string input = Console.ReadLine();
            Thread.Sleep(10);
            Console.Clear();
        // MENU OUTPUTS
            if (input == "1") // CREATE NEW GOAL
            {
                this.CreateGoal();
                Console.Write("\nNew Goal Set!\n\nPress enter to continue. ");
                Console.ReadLine();
            }
            else if (input == "2") // LIST GOALS
            {
                this.ListGoalDetails();
                Console.Write("\nHit enter to continue. ");
                Console.ReadLine();
            }
            else if (input == "3") // SAVE TO FILE
            {
                this.SaveGoals();
                Console.Write("\nHit enter to continue. ");
                Console.ReadLine();
            }
            else if (input == "4") // LOAD FROM FILE
            {
                this.LoadGoals();
                Console.Write("\nHit enter to continue. ");
                Console.ReadLine();
            }
            else if (input == "5") // RECORD GOAL EVENT
            {
                this.RecordEvent();
                Console.Write("\nHit enter to continue. ");
                Console.ReadLine();
            }
            else if (input == "6") // QUIT MENU LOOP
            {
                ongoing = false;
            }
        }
    }
    public void DisplayPlayerInfo() // DISPLAYS TOTAL POINTS
    {
        Console.WriteLine($"You have {_score} points.");
    }
    public void ListGoalNames() // LISTS GOAL NAMES FOR THE PURPOSE OF SELECTING THEM IN RecordEvent()
    {
        int x = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{x}. {goal.GetName()}");
            x += 1;
        }
    }
    public void ListGoalDetails() // LISTS GOAL DESCRIPTIONS AND COMPLETION FOR "List Goals" MENU OPTION
    {
        this.DisplayPlayerInfo();
        Console.WriteLine(); // Clearing console and displaying point total.

        if (_goals.Count() > 0) // Checking to make sure there are goals set.
        {
            Console.WriteLine("Your Current Goals:\n");
            int x = 1;
            foreach (Goal goal in _goals)
            {
                Console.Write($"{x}. ");
                Console.WriteLine(goal.GetStringRepresentation());
                x += 1;
            }
        }
        else
        {
            Console.WriteLine("You don't have any goals yet!");
        }
    }
    public void CreateGoal() // CREATING GOALS
    {
        bool menu1 = true;
        while (menu1) // MENU LOOP
        {
            this.DisplayPlayerInfo();
            Console.WriteLine(); // Clearing console and displaying point total.
        // MENU
            Console.WriteLine("Goal Menu:");
            Console.WriteLine("1. Simple Goal\n2. Eternal Goal\n3. Checklist Goal\n");
            Console.Write("What type of Goal do you want to create? ");
            string goal = Console.ReadLine();
            
            if (goal == "1") // SIMPLE GOAL
            {
                Console.Write("\nWhat is the name of your goal?\n>");
                string name = Console.ReadLine();
                Console.Write("Please write a short description of your goal.\n>");
                string description = Console.ReadLine();
                Console.Write("How many points is your goal worth?\n>");
                string points = Console.ReadLine();
                SimpleGoal simpleGoal = new SimpleGoal(name, description, points);

                _goals.Add(simpleGoal); // Adding goal to _goals list.

                menu1 = false;
            }
            else if (goal == "2") // ETERNAL GOAL
            {
                Console.Write("\nWhat is the name of your goal?\n>");
                string name = Console.ReadLine();
                Console.Write("Please write a short description of your goal.\n>");
                string description = Console.ReadLine();
                Console.Write("How many points is your goal worth?\n>");
                string points = Console.ReadLine();
                EternalGoal eternalGoal = new EternalGoal(name, description, points);

                _goals.Add(eternalGoal); // Adding goal to _goals list.

                menu1 = false;
            }
            else if (goal == "3") // CHECKLIST GOAL
            {
                Console.Write("\nWhat is the name of your goal?\n>");
                string name = Console.ReadLine();
                Console.Write("Please write a short description of your goal.\n>");
                string description = Console.ReadLine();
                Console.Write("How many points is your goal worth?\n>");
                string points = Console.ReadLine();
                Console.Write("How many times do you need to reach this goal to get a bonus?\n>");
                string x = Console.ReadLine();
                int target = Int32.Parse(x);
                Console.WriteLine("Your bonus will be worth twice as much as your points.");
                // I couldn't figure out how to store the bonus in a way that I could load it later :( So I just simplified it to make it work.
                int bonus = target * 2; 
                ChecklistGoal checkGoal = new ChecklistGoal(name, description, points, target, bonus);

                _goals.Add(checkGoal); // Adding goal to _goals list.

                menu1 = false;
            }
        }
    }
    public void RecordEvent() // RECORDING GOAL COMPLETION
    {
        if (_goals.Count != 0) // Checking if there are goals to record.
        {
            Console.Clear();
            this.DisplayPlayerInfo();
            Console.WriteLine(); // Clearing console and displaying point total.

            this.ListGoalNames();
            Console.Write("\nWhat Goal would you like to record? ");
            string x = Console.ReadLine();
            Console.WriteLine();
            int i = Int32.Parse(x); 
            i += -1;
            _score += _goals[i].RecordEvent();
        }
        else // No goals to record.
        {
            Console.WriteLine("You don't have any goals to record!");
        }
    }
    public void SaveGoals() // SAVING GOALS TO FILE
    {
        Console.Clear();
        this.DisplayPlayerInfo();
        Console.WriteLine(); // Clearing console and displaying point total.

        Console.Write("What would you like to name your file? (noSpaces.txt): ");
        string fileName = Console.ReadLine();

        if (fileName != "") // Making sure a filename was entered.
        {
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                outputFile.WriteLine(_score); // Recording total points

                foreach (Goal goal in _goals)
                {
                    if (goal is SimpleGoal) // Saving SimpleGoal
                    {
                        outputFile.WriteLine($"Simple|{goal.GetName()}|{goal.GetDescription()}|{goal.GetPoints()}|{goal.IsComplete()}");
                    }
                    else if (goal is EternalGoal) // Saving EternalGoal
                    {
                        outputFile.WriteLine($"Eternal|{goal.GetName()}|{goal.GetDescription()}|{goal.GetPoints()}");
                    }
                    else if (goal is ChecklistGoal) // Saving ChecklistGoal
                    {
                        outputFile.WriteLine($"Checklist|{goal.GetName()}|{goal.GetDescription()}|{goal.GetPoints()}|{goal.GetDetailsString()}");
                    }
                }  
            }
            Console.WriteLine("\nGoals Saved!");
        }
        
    }
    public void LoadGoals() // LOADING GOALS FROM FILE
    {
        Console.Clear();
        this.DisplayPlayerInfo();
        Console.WriteLine(); // Clearing console and displaying point total.

        Console.Write("What is the name of the file? (noSpaces.txt): ");
        string fileName = Console.ReadLine();

        if (fileName != "") // Making sure a filename was entered.
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            _score = Int32.Parse(lines[0]); // Recording total points.

            lines = lines.Skip(1).ToArray(); // Skipping first line.
            foreach (string line in lines)
            {
                string[] parts = line.Split("|");
                if (parts[0] == "Simple") // SIMPLE GOAL
                {
                    string name = parts[1];
                    string desc = parts[2];
                    string points = parts[3];
                    string x = parts[4];
                    SimpleGoal goal = new SimpleGoal(name, desc, points);
                    if (x == "true")
                    {
                        goal.RecordEvent();
                    }
                    _goals.Add(goal); // Adding goal to _goals list.
                }
                else if (parts[0] == "Eternal") // ETERNAL GOAL
                {
                    string name = parts[1];
                    string desc = parts[2];
                    string points = parts[3];

                    EternalGoal goal = new EternalGoal(name, desc, points);
                    _goals.Add(goal);// Adding goal to _goals list.
                }
                else if (parts[0] == "Checklist")// CHECKLIST GOAL
                {
                    string name = parts[1];
                    string desc = parts[2];
                    string points = parts[3];
                    string detail = parts[4];

                    string[] details = detail.Split("/");
                    int amountComplete = Int32.Parse(details[0]);
                    int target = Int32.Parse(details[1]);
                    int x = Int32.Parse(points);
                    int bonus =  x * 2;

                    ChecklistGoal goal = new ChecklistGoal(name, desc, points, target, bonus);

                    if (amountComplete != 0)
                    {
                        for (int i = 0; i < amountComplete; i++)
                        {
                            goal.RecordEvent();
                        }
                    }
                    _goals.Add(goal);// Adding goal to _goals list.
                }
            }
            Console.Write("\nGoals Loaded!");
        }
    }
}