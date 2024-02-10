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
    public void Start()
    {
        bool ongoing = true;
        while (ongoing)
        {
            Console.Clear();

            this.DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal\n2. List Goals\n3. Save Goals\n4. Load Goals\n5. Record Event\n6. Quit");
            Console.Write("\nSelect a choice from the menu: ");
            string input = Console.ReadLine();
            Thread.Sleep(10);
            Console.Clear();

            if (input == "1")
            {
                this.CreateGoal();
                Console.Write("\nNew Goal Set!\n\nPress enter to continue. ");
                Console.ReadLine();
            }
            else if (input == "2")
            {
                this.ListGoalDetails();
                Console.Write("\nHit enter to continue. ");
                Console.ReadLine();
            }
            else if (input == "3")
            {
                this.SaveGoals();
                Console.Write("\nHit enter to continue. ");
                Console.ReadLine();
            }
            else if (input == "4")
            {
                this.LoadGoals();
                Console.Write("\nHit enter to continue. ");
                Console.ReadLine();
            }
            else if (input == "5")
            {
                this.RecordEvent();
                Console.Write("\nHit enter to continue. ");
                Console.ReadLine();
            }
            else if (input == "6")
            {
                ongoing = false;
            }
        }
    }
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }
    public void ListGoalNames()
    {
        int x = 1;
        foreach (Goal goal in _goals)
        {
            Console.WriteLine($"{x}. {goal.GetName()}");
            x += 1;
        }
    }
    public void ListGoalDetails()
    {
        this.DisplayPlayerInfo();
        Console.WriteLine();
        if (_goals.Count() > 0)
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
    public void CreateGoal()
    {
        bool menu1 = true;
        while (menu1)
        {
            this.DisplayPlayerInfo();
            Console.WriteLine();

            Console.WriteLine("Goal Menu:");
            Console.WriteLine("1. Simple Goal\n2. Eternal Goal\n3. Checklist Goal\n");
            Console.Write("What type of Goal do you want to create? ");
            string goal = Console.ReadLine();
            
            if (goal == "1")
            {
                Console.Write("\nWhat is the name of your goal?\n>");
                string name = Console.ReadLine();
                Console.Write("Please write a short description of your goal.\n>");
                string description = Console.ReadLine();
                Console.Write("How many points is your goal worth?\n>");
                string points = Console.ReadLine();
                SimpleGoal simpleGoal = new SimpleGoal(name, description, points);
                _goals.Add(simpleGoal);

                menu1 = false;
            }
            else if (goal == "2")
            {
                Console.Write("\nWhat is the name of your goal?\n>");
                string name = Console.ReadLine();
                Console.Write("Please write a short description of your goal.\n>");
                string description = Console.ReadLine();
                Console.Write("How many points is your goal worth?\n>");
                string points = Console.ReadLine();
                EternalGoal eternalGoal = new EternalGoal(name, description, points);
                _goals.Add(eternalGoal);

                menu1 = false;
            }
            else if (goal == "3")
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
                int bonus = target * 2;
                ChecklistGoal checkGoal = new ChecklistGoal(name, description, points, target, bonus);
                _goals.Add(checkGoal);

                menu1 = false;
            }
        }
    }
    public void RecordEvent()
    {
        if (_goals.Count != 0)
        {
            Console.Clear();
            this.DisplayPlayerInfo();
            Console.WriteLine();

            this.ListGoalNames();
            Console.Write("\nWhat Goal would you like to record? ");
            string x = Console.ReadLine();
            Console.WriteLine();
            int i = Int32.Parse(x); 
            i += -1;
            _score += _goals[i].RecordEvent();
        }
        else
        {
            Console.WriteLine("You don't have any goals to record!");
        }
    }
    public void SaveGoals()
    {
        Console.Clear();
        this.DisplayPlayerInfo();
        Console.WriteLine();

        Console.Write("What would you like to name your file? (noSpaces.txt): ");
        string fileName = Console.ReadLine();
        if (fileName != "")
        {
            using (StreamWriter outputFile = new StreamWriter(fileName))
            {
                outputFile.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    if (goal is SimpleGoal)
                    {
                        outputFile.WriteLine($"Simple|{goal.GetName()}|{goal.GetDescription()}|{goal.GetPoints()}|{goal.IsComplete()}");
                    }
                    else if (goal is EternalGoal)
                    {
                        outputFile.WriteLine($"Eternal|{goal.GetName()}|{goal.GetDescription()}|{goal.GetPoints()}");
                    }
                    else if (goal is ChecklistGoal)
                    {
                        outputFile.WriteLine($"Checklist|{goal.GetName()}|{goal.GetDescription()}|{goal.GetPoints()}|{goal.GetDetailsString()}");
                    }
                }  
            }
            Console.WriteLine("\nGoals Saved!");
        }
        
    }
    public void LoadGoals()
    {
        Console.Clear();
        this.DisplayPlayerInfo();
        Console.WriteLine();

        Console.Write("What is the name of the file? (noSpaces.txt): ");
        string fileName = Console.ReadLine();

        if (fileName != "")
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            _score = Int32.Parse(lines[0]);

            lines = lines.Skip(1).ToArray();
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
                    _goals.Add(goal);
                }
                else if (parts[0] == "Eternal") // ETERNAL GOAL
                {
                    string name = parts[1];
                    string desc = parts[2];
                    string points = parts[3];

                    EternalGoal goal = new EternalGoal(name, desc, points);
                    _goals.Add(goal);
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
                    _goals.Add(goal);
                }
            }
            Console.Write("\nGoals Loaded!");
        }
    }
}