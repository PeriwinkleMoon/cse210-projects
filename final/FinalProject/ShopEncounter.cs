using System;

public class ShopEncounter : Encounter
{
    List<Item> _merchandise = new List<Item>();
    List<Item> _stock = new List<Item>();
    Random rnd = new Random();
    Player _player = new Player();

    public ShopEncounter(Player pc, List<Item> stock)
    {
        _player = pc;
        _stock = stock;
    }
    public override void Start()
    {
        // Console.Clear();
        Console.WriteLine("You enter a small but well lit room and see a nice looking man sitting\nwith a handful of items laid neatly on the floor in front of him.\nHe waves to you with a smile.\n");
        Thread.Sleep(1000);
        Console.WriteLine("HERMAN: Welcome adventurer! Care to browse my wares?\n");
        Thread.Sleep(2000);
        this.SetMerch();
        bool shop = true;
        while (shop) 
        {
            Console.WriteLine("######### HERMAN'S BAAZAR #########\n");
            int i = 1;
            foreach (Item item in _merchandise)
            {
                Thread.Sleep(600);
                item.GetInfo(i);
                i += 1;
            }
            Console.WriteLine("+++++++++++++++++++++++++++++++++");
            Console.WriteLine("1. BUY?      2. LEAVE?");
            string x = Console.ReadLine();
            int input = Int32.Parse(x);

            if (input == 1)
            {
                Console.WriteLine("Which item would you like to buy?");
                x = Console.ReadLine();
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
        }
        Console.WriteLine("HERMAN: Leaving so soon? Well, good luck adventurer!");
    }
    private void Purchase(Item merch, int i)
    {
        if (_player.CheckWallet(merch.GetPrice()))
        {
            if (merch.CheckWeapon())
            {
                Console.WriteLine("Buying this will replace your current weapon. Are you sure? [Y/N]");
                string response = Console.ReadLine();
                if (response == "Y")
                {
                    _player.Purchase(_merchandise[i]);
                    //_merchandise.RemoveAt[i];
                    Console.WriteLine("\nHERMAN: Thank your for you purchase!\n");
                }
                else 
                {
                    return;
                }
            }
            else if (merch.CheckEquip())
            {
                Console.WriteLine("Buying this will replace your current equipment. Are you sure? [Y/N]");
                string response = Console.ReadLine();
                if (response == "Y")
                {
                    _player.Purchase(_merchandise[i]);
                    //_merchandise.RemoveAt[i];
                    Console.WriteLine("\nHERMAN: Thank your for you purchase!\n");
                }
                else 
                {
                    return;
                }
            }
            else
            {
                _player.Purchase(_merchandise[i]);
            }
        }
        else 
        {
            Console.WriteLine("HERMAN: Well it doesn't look like you have enough for that one, Champ.");
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