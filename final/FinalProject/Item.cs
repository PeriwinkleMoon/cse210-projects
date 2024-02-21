using System;

public class Item
{
// ATTRIBUTES
    private string _name;
    private int _price;
    private string _description;
    private int _heal = 0;
    private int _defense = 0;
    private int _damage = 0;
    private string _action;
// CONSTRUCTOR
    public Item (string name, int price, string desc)
    {
        _name = name;
        _price = price;
        _description = desc;
    }
    
    public Item (string name, int price, string desc, string act)
    {
        _name = name;
        _price = price;
        _description = desc;
        _action = act;
    }
// GETTER
    public void GetInfo(int i)
    {
        Console.WriteLine($"{i}. {_name} - {_price} Coins\n     {_description}\n");
    }
    public void GetStats()
    {
        Console.WriteLine($"{_name} - Does {_damage} damage\n   {_description}");
    }
    public int GetPrice()
    {
        return _price;
    }
    public string GetName()
    {
        return _name;
    }
    public string GetDescription()
    {
        return _description;
    }
/*
    I was going to have 3 different derived classes, but was having difficultly with using a list of Items including
    those derived classes as objects in the list. So to save time I'm using a probably less elegant method and just
    storing all of that into one class and just using Getters/Setters as a substitute for derived classes.
*/
    // Healing item
    public void Use(Player pc, Enemy enemy)
    {
        if (_heal != 0)
        {
            pc.AddHealth(_heal);
        }
        else if (_damage != 0)
        {
            Console.WriteLine(_action);
            enemy.Defend(_damage);
        }
        else 
        {
            Console.WriteLine(_action);
        }
    }
    public void SetHeal(int x)
    {
        _heal = x;
    }
    // Weapon
    public void SetDmg(int i)
    {
        _damage = i;
    }
    public int Attack()
    {
        return _damage;
    }
    public bool CheckWeapon() // Checking if the item is a weapon.
    {
        if (_damage != 0)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
    // Equpiment
    public void SetDefense(int i)
    {
        _defense = i;
    }
    public bool CheckEquip() // Checking if the item is Equipment.
    {
        if (_defense != 0)
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
}