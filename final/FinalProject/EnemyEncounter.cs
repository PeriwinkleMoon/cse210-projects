using System;

public class EnemyEncounter : Encounter
{
    private Player _player = new Player();
    private Random rnd = new Random();
    private string _name;
    private string _art;
    public EnemyEncounter(Player pc)
    {
        _player = pc;
    }
    public override bool Start()
    {
        bool alive = true;
        Console.Clear();
        Enemy enemy = GetEnemy();
        Console.WriteLine($"A {_name} appears!\n");
        Thread.Sleep(600);
        bool battle = true;
        while (battle)
        {
            Console.Clear();
            Console.WriteLine($"A {_name} appears!\n");
            if (_player.GetHealth() <= 0)
            {
                Console.WriteLine(_art);
                Console.WriteLine($"Your Health: {_player.GetHealth()}   {_name}'s Health: {enemy.GetHealth()}");
                Console.WriteLine("+++++++++++++++++++++++++++++++++");
                Console.WriteLine($"OOF! Looks like {_name} has the last laugh. The lights are going out...\n");
                battle = false;
                alive = false;
            }
            else if (enemy.GetHealth() <= 0)
            {
                Console.WriteLine(_art);
                Console.WriteLine($"Your Health: {_player.GetHealth()}   {_name}'s Health: {enemy.GetHealth()}");
                Console.WriteLine("+++++++++++++++++++++++++++++++++");
                DefeatEnemy(enemy);
                battle = false;
            }
            else 
            {
                Console.WriteLine(_art);
                Console.WriteLine($"Your Health: {_player.GetHealth()}   {_name}'s Health: {enemy.GetHealth()}");
                Console.WriteLine("+++++++++++++++++++++++++++++++++");
                Console.WriteLine("1. Attack    2. Inventory\n3. Flee      4. Do Nothing");
                Console.Write(">");
                string x = Console.ReadLine();
                if (x == "")
                {
                    x = "0";
                }
                int input = Int32.Parse(x);

                if (input == 1) // FIGHT
                {
                    Console.WriteLine("\nTime to fight!");
                    Spinner();
                    if (_player.Attack(enemy))
                    {
                        Console.WriteLine("BAM! You hit!");
                        if (enemy.GetHealth() <= 0)
                        {
                            DefeatEnemy(enemy);
                            battle = false;
                            Console.Write("Enter to continue >");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Oops! You whiffed it!");
                    }
                    Thread.Sleep(600);
                    Console.WriteLine($"\nLooks like the {_name} is going to try and fight back!");
                    int dmg = enemy.Attack(_player);
                    Spinner();
                    if (dmg != 0)
                    {
                        Console.WriteLine($"Ouch! You take {dmg} damage.\n");
                        if (_player.GetHealth() <= 0)
                        {
                            Console.WriteLine($"OOF! Looks like {_name} has the last laugh. The lights are going out...\n");
                            battle = false;
                            alive = false;
                        }
                    }
                    else
                    {
                        Console.WriteLine("A miss! You're safe this time.\n");
                    }
                }
                else if (input == 2) // ITEM
                {
                    bool query = true;
                    while (query)
                    {
                        Console.Clear();
                        Console.WriteLine($"A {_name} appears!\n");
                        Console.WriteLine(_art);
                        Console.WriteLine($"Your Health: {_player.GetHealth()}   {_name}'s Health: {enemy.GetHealth()}");
                        Console.WriteLine("+++++++++++++++++++++++++++++++++");
                        List<Item> inventory = _player.GetInventory();
                        if (inventory.Count != 0)
                        {
                            int y = 0;
                            bool q = true;
                            while (q)
                            {
                                Console.Clear();
                                Console.WriteLine($"A {_name} appears!\n");
                                Console.WriteLine(_art);
                                Console.WriteLine($"Your Health: {_player.GetHealth()}   {_name}'s Health: {enemy.GetHealth()}");
                                Console.WriteLine("+++++++++++++++++++++++++++++++++");
                                foreach (Item i in inventory)
                                {
                                    y += 1;
                                    Console.WriteLine($"{y}. {i.GetName()} -- {i.GetDescription()}");
                                }
                                Console.WriteLine("\nWhich item do you want to use?");
                                Console.Write(">");
                                string z = Console.ReadLine();
                                if (z == "")
                                {
                                    z = "0";
                                }
                                int choice = Int32.Parse(z);
                                choice -= 1;
                                if (choice <= inventory.Count)
                                {
                                    inventory[choice].Use(_player, enemy);
                                    _player.UseItem(choice);
                                    q = false;
                                    query = false;
                                }
                            }
                            
                        }
                        else
                        {
                            Console.WriteLine("Your inventory is empty!\n");
                            Thread.Sleep(600);
                            query = false;
                        }
                    }
                }
                else if (input == 3) // FLEE
                {
                    Console.WriteLine($"'Not today!' You cry, and dodge around the {_name} as it lunges at you.\n");
                    int flee = rnd.Next(1,10);
                    Thread.Sleep(600);
                    if (flee <= 3)
                    {
                        Console.Write($"But you couldn't escape! The {_name} ");
                        if (_name == "Skeleton")
                        {
                            Console.Write("punches you in the shoulder with its boney hand and blocks the door!\n");
                        }
                        else if (_name == "Goblin")
                        {
                            Console.Write("whacks you in the gut with its stick-like club and lands you on your butt!\n");
                        }
                        else if (_name == "Slime")
                        {
                            Console.Write("attaches its sticky self to your legs! You can't move!\n");
                        }
                        int atk = enemy.Attack(_player);
                        Console.WriteLine($"You take {atk} damage.\n");
                        battle = true;
                    }
                    else if (flee <= 5)
                    {
                        Console.WriteLine($"It narrowly misses you! But you make it to the door, leaving the {_name} behind!");
                        battle = false;
                    }
                    else
                    {
                        Console.WriteLine($"You make it to the door with ease, leaving the {_name} in the dust!");
                        battle = false;
                    }
                }
                else // DO NOTHING
                {
                    int chance = rnd.Next(1,10);
                    Console.Write("You just stand there, ");
                    if (chance <= 5)
                    {
                        Console.Write($"but the {_name} doesn't! It strikes!\n\n");
                        int atk = enemy.Attack(_player);
                        Console.WriteLine($"You take {atk} damage.\n");
                        if (_player.GetHealth() <= 0)
                        {
                            Console.WriteLine($"OOF! Looks like {_name} has the last laugh. The lights are going out...\n");
                            battle = false;
                            alive = false;
                        }
                    }
                    else if (chance <= 9)
                    {
                        Console.Write($"and the {_name} does too.\nI guess this is just a staring contest now...\n");
                    }
                    else
                    {
                        Console.Write($"and sensing no aggression the {_name} gets bored and decides to leave.\n");
                        Console.WriteLine("I guess you win!\n");
                        battle = false;
                        Console.Write("Enter to continue >");
                        Console.ReadLine();
                    }
                }
            }
            Console.Write("Enter to continue >");
            Console.ReadLine();
            Console.Clear();
        }
        if (alive)
        {
            Console.WriteLine("\nA battle behind you, you press on.\n");
            Console.Clear();
            Console.WriteLine("A battle behind you, you press on.");
        }
        else
        {
            Console.WriteLine("You died! Better luck next time!\n");
            Console.Write("\nEnter to continue >");
            Console.ReadLine();
            Console.Clear();
        }
        return alive;
    }
    public Enemy GetEnemy()
    {
        int enemy = RandomNumber(1,4);
        if (enemy == 1)
        {
            SkeletonEnemy skeleton = new SkeletonEnemy(RandomNumber(7,10),RandomNumber(3,8),RandomNumber(0,5));
            _name = "Skeleton";
            _art = "      .-.\n     (o.o)\n      |=|\n     __|__\n   //.=|=.\\\n  // .=|=. \\\n  \\  .=|=. //\n    \\(_=_)//\n    (:| |:)\n     || ||\n     () ()\n     || ||\n     || ||\n    ==' '==\n";
            return skeleton;
        }
        else if (enemy == 2)
        {
            GoblinEnemy goblin = new GoblinEnemy(RandomNumber(8,15),RandomNumber(2,5),RandomNumber(0,5));
            _name = "Goblin";
            _art = "       ..-..\n    ^\\( ~ ~ )/^\n    ; \\ 0 0 / ;\n      [__^__]\n       \\V V/\n     +--/ \\--+\n   { /  | |  \\ }\n   | |  | |  | |\n   ( ===000=== )\n   | /  | |  \\ |\n   | ++++ ++++ |\n  ( /   ___   \\ )\n   (   /   \\   )\n   \\___\\   /___/\n  (_____|  |_____)\n";
            return goblin;
        }
        else
        {
            SlimeEnemy slime = new SlimeEnemy(RandomNumber(10,20),RandomNumber(1,7),RandomNumber(4,8));
            _name = "Slime";
            _art = "    _+####+_\n  {#+      +#}\n {#+  0 . 0 +#}\n{#  ~       ~  #}\n#+##+#====#+##+#\n";
            return slime;
        }
        
    }
    private void DefeatEnemy(Enemy enemy)
    {
        Console.WriteLine($"\nThe {_name} falls to your {_player.GetWeapon()}!");
        int cash = enemy.Drops();
        Console.WriteLine($"You gain {cash} gold!");
        _player.AddWallet(cash);
        Console.WriteLine("You win!\n");

    }
}