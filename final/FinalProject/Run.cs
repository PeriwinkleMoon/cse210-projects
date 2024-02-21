using System;

public class Run
{
    private Player _pc = new Player();
    private List<Item> _stock = new List<Item>();
    private Random rnd = new Random();
    private bool alive;

    public Run(Player pc)
    {
        _pc = pc;
    }

    public bool Start()
    {
        BackStock();
        bool playing = true;
        int runs = 0;
        Console.Clear();
        Console.WriteLine("The C# Dungeon Labyrinth is a mysterious place...");
        Thread.Sleep(1700);
        Console.WriteLine("You'll find something new every time you enter.");
        Thread.Sleep(1500);
        Console.WriteLine("Will you fall to the monsters, or will you come out with treasure?\n");
        Thread.Sleep(1700);
        Console.WriteLine("You gulp and descend the winding, dilapidated staircase leading\ninto the depths below. You enter the first room.");
        Thread.Sleep(2000);
        Console.Write("\nEnter to continue >");
        Console.ReadLine();
        
        while (playing)
        {
            runs += 1;
            if (runs >= 3)
            {
                bool query = true;
                runs = 0;
                while (query)
                {
                    Console.WriteLine("\nAs you peak around a new corner you're met with sunlight flowing down a set of stairs!");
                    Thread.Sleep(600);
                    Console.WriteLine("Would you like to proceed through the dungeon, or take a pit-stop at the surface?");
                    Console.Write("1. PROCEED   2. LEAVE >");
                    string x = Console.ReadLine();
                    if (x == "")
                    {
                        x = "0";
                    }
                    int input = Int32.Parse(x);
                    if (input == 1)
                    {
                        Console.WriteLine("\nNo rest for the adventurer! On through the dungeons!\n");
                        Thread.Sleep(600);
                        Console.Write("Enter to continue >");
                        Console.ReadLine();
                        query = false;
                        alive = true;
                    }
                    else if (input == 2)
                    {
                        Console.WriteLine("\nTime for a break! To the surface we go!\n");
                        Thread.Sleep(600);
                        Console.Write("Enter to continue >");
                        Console.ReadLine();
                        query = false;
                        playing = false;
                        alive = true;
                        break;
                    }
                }  
            }
            
            int chance = rnd.Next(1,20);
            if (runs == 1)
            {
                if (chance <= 5)
                {
                    ShopEncounter shop = new ShopEncounter(_pc, _stock);
                    shop.Spinner();
                    shop.Start();
                    shop.Spinner();
                    Transition();
                }
                else 
                {
                    EnemyEncounter enemyEncounter = new EnemyEncounter(_pc);
                    enemyEncounter.Spinner();
                    playing = enemyEncounter.Start();
                    enemyEncounter.Spinner();
                    if (!playing)
                    {
                        alive = false;
                        break;
                    }
                    Transition();
                }
            }
            else
            {
                if (chance <= 2)
                {
                    SpecialEncounter specialEncounter = new SpecialEncounter(_pc);
                    specialEncounter.Start();
                    specialEncounter.Spinner();
                    Transition();
                }
                else if (chance <= 6)
                {
                    ShopEncounter shop = new ShopEncounter(_pc, _stock);
                    shop.Start();
                    shop.Spinner();
                    Transition();
                }
                else 
                {
                    EnemyEncounter enemyEncounter = new EnemyEncounter(_pc);
                    playing = enemyEncounter.Start();
                    enemyEncounter.Spinner();
                    if (!playing)
                    {
                        alive = false;
                        break;
                    }
                    Transition();
                }
            }

        }
        return playing;
    }
    public bool End()
    {
        return alive;
    }   
    private void Transition()
    {
        int n = rnd.Next(1,5);
        if (n == 1)
        {
            
            Console.WriteLine("\nYou move on through the dungeon. Turning a corner you find a spiral staircase,\nleading deeper into the depths...");
            Thread.Sleep(3000);
        }
        else if (n == 2)
        {
            Console.WriteLine("\nLeaving the room, you pass through a long hallway.\nWater drips from the cieling, and you catch a faint whiff of... Laundry detergent? Oh well! Moving on.");
            Thread.Sleep(8000);
        }
        else if (n == 3)
        {
            Console.WriteLine("\nYou come to a cross roads. Two identical doorways stand before you.");
            Console.Write("Do you enter the Left (1) or the Right (2)? > ");
            Console.ReadLine();
            Console.WriteLine("You enter.");
            Thread.Sleep(4000);
        }
        else if (n == 4)
        {
            Console.WriteLine("\nAs you walk your foot catches on the floor! You stagger to the side and run right into the wall.\nOnly... There isn't a wall! You fall through a mass of vines into the next room.");
            Thread.Sleep(8000);
        }
        else
        {
            Console.WriteLine("\nWhistling as you go, you turn the corner.");
            Thread.Sleep(8000);
        }
        
    }
    private void BackStock()
    {
        Item healthPotion = new Item("Health Potion", 5, "A small, clean vial filled with a sweet looking red potion.", 
        "You down the health potion. It feels warm and fizzy in your throat, and tates like cherries!");
        healthPotion.SetHeal(5);
        _stock.Add(healthPotion);
        Item teddyBear = new Item("Teddy Bear", 2, "An abandoned teddy bear. It seems to look at you with its lonely plastic eyes.",
        "You hold up the bear, but your opponent doesn't seem impressed.");
        _stock.Add(teddyBear);
        Item pebble = new Item("Jagged Pebble", 1, "A large pebble. Maybe you could throw it?",
        "You throw the pebble with all your might at your opponent!");
        pebble.SetDmg(2);
        _stock.Add(pebble);

        Item chestplate = new Item("Leather Chestplate", 10, "A simple leather chestplate. Good for blocking attacks!");
        chestplate.SetDefense(5);
        _stock.Add(chestplate);
        Item buckler = new Item("Buckler Shield", 9, "A handy shield!");
        buckler.SetDefense(4);
        _stock.Add(buckler);

        Item quarterStaff = new Item("Quarter Staff", 7, "A sturdy, well made quarterstaff. Deadly in the right hands.");
        quarterStaff.SetDmg(4);
        _stock.Add(quarterStaff);
        Item simpleSword = new Item("Simple Sword", 10, "A simple iron sword. It's a little dull, but still cuts deep.");
        simpleSword.SetDmg(8);
        _stock.Add(simpleSword);
    }
}