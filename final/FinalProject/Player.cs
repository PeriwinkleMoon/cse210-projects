using System;

public class Player
{
// ATTRIBUTES
    private int _health;
    private int _defense;
    private int _wallet;
    private Item _weapon;
    private List<Item> _inventory = new List<Item>();
    private Item _equipment;
    static Random rnd = new Random();

// CONSTRUCTOR
    public Player()
    {

    }
// METHODS
    public void RollPC()
    {
        _weapon = StarterWeapon();
        _wallet = StartWallet();
        _health = rnd.Next(10,20);
        _defense = 0;

        _weapon.GetStats();
        Thread.Sleep(600);
        Console.WriteLine($"Wallet: {_wallet} coins");
        Thread.Sleep(600);
        Console.WriteLine($"Health: {_health}");
        Thread.Sleep(600);
        Console.WriteLine($"Defense: {_defense}");
        Thread.Sleep(600);
    }
    private Item StarterWeapon()
        {
            Item club = new Item("Club", 4, 
            "A simple but heavy weapon. Easy to hit baddies over the head with.");
            club.SetDmg(5);
            Item woodSword = new Item("Wooden Sword", 5, 
            "A makeshift wooden sword. It's not the best around, but it's better than being unarmed.");
            woodSword.SetDmg(4);
            Item rustyDagger = new Item("Rusty Dagger", 7, 
            "A small but useful weapon. This dagger has been worn and rusted from years of use, but it still gets the job done.");
            rustyDagger.SetDmg(6);

            List<Item> starterWeapons = new List<Item>();
            starterWeapons.Add(rustyDagger);
            starterWeapons.Add(club);
            starterWeapons.Add(woodSword);

            int x = rnd.Next(starterWeapons.Count);

            return starterWeapons[x];
        }
    private int StartWallet()
        {
            int lowerBound = 5;
            int upperBound = 15;
            int rNum = rnd.Next(lowerBound, upperBound);
            return rNum;
        }
    public bool CheckWallet(int price)
    {
        if (price <= _wallet)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public int Defend(int atk)
    {
        int dmg = 0;
        if (_defense != 0)
        {
            dmg = atk / _defense;
        }
        else
        {
            dmg = atk;
        }
        _health -= dmg;
        return dmg;
    }
    public bool Attack(Enemy enemy)
    {
        int hit = rnd.Next(1,10);
        if (hit <= 3)
        {
            return false;
        }
        else
        {
            enemy.Defend(_weapon.Attack());
            return true;
        }
    }
    public void UseItem(int i)
    {
        _inventory.RemoveAt(i);
    }
// GETTERS
    public int GetWallet()
    {
        return _wallet;
    }
    public int GetHealth()
    {
        return _health;
    }
    public string GetWeapon()
    {
        return _weapon.GetName();
    }
    public List<Item> GetInventory()
    {
        return _inventory;
    }
// SETTERS
    public void Purchase(Item i)
    {
        int price = i.GetPrice();
        _wallet -= price;

        if (i.CheckWeapon())
        {
            _weapon = i;
        }
        else if (i.CheckEquip())
        {
            _equipment = i;
        }
        else
        {
            _inventory.Add(i);
        }
    }
    public void AddWallet(int i)
    {
        _wallet += i;
    }
    public void AddHealth(int i)
    {
        _health += i;
        Console.WriteLine($"Your health is now {_health}!");
    }
    
}