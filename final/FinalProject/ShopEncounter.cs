using System;

public class ShopEncounter : Encounter
{
    private List<Item> _merchandise = new List<Item>();
    private List<Item> _stock = new List<Item>();
    private Random rnd = new Random();
    private Player _player = new Player();
    private string _message = "Welcome adventurer! Care to browse my wares?";

    public ShopEncounter(Player pc, List<Item> stock)
    {
        _player = pc;
        _stock = stock;
    }
    public override bool Start()
    {
        Console.Clear();
        Console.WriteLine("You enter a small but well lit room and see a nice looking man sitting\nwith a handful of items laid neatly on the floor in front of him.\nHe waves to you with a smile.\n");
        Thread.Sleep(1000);
        Console.WriteLine("HERMAN: Welcome adventurer! Care to browse my wares?\n");
        Thread.Sleep(1500);
        this.SetMerch();
        bool shop = true;
        while (shop) 
        {
            Console.Clear();
            Console.WriteLine("You enter a small but well lit room and see a nice looking man sitting\nwith a handful of items laid neatly on the floor in front of him.\nHe waves to you with a smile.\n");
            Console.WriteLine($"HERMAN: {_message}\n");
            Console.WriteLine("######### HERMAN'S BAAZAR #########\n");
            int i = 1;
            Console.WriteLine($"Your Wallet: {_player.GetWallet()}\n");
            foreach (Item item in _merchandise)
            {
                Thread.Sleep(300);
                item.GetInfo(i);
                i += 1;
            }
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            Console.WriteLine("1. BUY?      2. LEAVE?");
            string x = Console.ReadLine();
            if (x == "")
            {
                x = "0";
            }
            int input = Int32.Parse(x);

            if (input == 1)
            {
                Console.WriteLine("Which item would you like to buy?");
                x = Console.ReadLine();
                if (x == "")
                {
                    x = "0";
                }
                int choice = Int32.Parse(x);

                if (choice == 1)
                {
                    Purchase(_merchandise[0], 0);
                }
                else if (choice == 2)
                {
                    Purchase(_merchandise[1], 1);
                }
                else if (choice == 3)
                {
                    Purchase(_merchandise[2], 2);
                }
                else if (choice == 4)
                {
                    Purchase(_merchandise[3], 3);
                }
            }
            else if (input == 2)
            {
                shop = false;
            }
            else 
            {
                shop = true;
            }
        }
        Console.WriteLine("HERMAN: Leaving so soon? Well, good luck adventurer!\n");
        Console.Write("Enter to continue >");
        Console.ReadLine();
        Console.WriteLine("\nThat was nice! But it's time to dive back into the dungeon.");
        Console.Clear();
        Console.WriteLine("That was nice! But it's time to dive back into the dungeon.");
        return true;
    }
    private void Purchase(Item merch, int i)
    {
        if (_player.CheckWallet(merch.GetPrice()))
        {
            if (merch.CheckWeapon() && merch.GetName() != "Jagged Pebble")
            {
                Console.WriteLine("Buying this will replace your current weapon. Are you sure? [Y/N]");
                string response = Console.ReadLine();
                if (response == "Y" || response == "y")
                {
                    _player.Purchase(_merchandise[i]);
                    _merchandise.RemoveAt(i);
                    _message = "Thank you for your purchase! Care for anything else?";
                }
                else 
                {
                    _message = "Change your mind? That's alright. Anythin' else catch your interest?";
                    return;
                }
            }
            else if (merch.CheckEquip())
            {
                Console.WriteLine("Buying this will replace your current equipment. Are you sure? [Y/N]");
                string response = Console.ReadLine();
                if (response == "Y"|| response == "y")
                {
                    _player.Purchase(_merchandise[i]);
                    _merchandise.RemoveAt(i);
                    _message = "Thank you for your purchase! Care for anything else?";
                }
                else 
                {
                    _message = "Change your mind? That's alright. Anythin' else catch your interest?";
                    return;
                }
            }
            else
            {
                _player.Purchase(_merchandise[i]);
                _merchandise.RemoveAt(i);
                _message = "Thank you for your purchase! Care for anything else?";
            }
        }
        else 
        {
            _message = "Well it doesn't look like you have enough for that one, Champ.\nAnything else you've got your eye on?";
            return;
        }
    }
    private void SetMerch()
    {
        int lowerBound = 2;
        int upperBound = 4;
        int rNum = rnd.Next(lowerBound, upperBound);
        for (int i = 0; i < rNum; i++)
        {
            int x = rnd.Next(_stock.Count);
            _merchandise.Add(_stock[x]);
        }

    }
    
}