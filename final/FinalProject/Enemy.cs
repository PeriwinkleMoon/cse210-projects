using System;

public abstract class Enemy
{
    protected int _health;
    protected int _attack;
    protected int _defense;
    protected Random rnd = new Random();

    public Enemy(int hp, int atk, int def)
    {
        _health = hp;
        _attack = atk;
        _defense = def;
    }
    public int Attack(Player pc)
    {
        int hit = rnd.Next(1,10);
        if (hit <= 3)
        {
            return 0;
        }
        else
        {

            return pc.Defend(_attack);
        }
    }
    public int Defend(int atk)
    {
        int mod = RandomNumber(1,2);
        int dmg = atk / mod;
        _health -= dmg;
        return dmg;
    }
    public abstract int Drops();
    public int GetHealth()
    {
        return _health;
    }
        public int RandomNumber(int lowerBound, int upperBound)
    {
        int rNum = rnd.Next(lowerBound, upperBound);
        return rNum;
    }
}