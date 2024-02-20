using System;

public abstract class Enemy
{
    int _health;
    int _attack;
    int _defense;

    public Enemy(int hp, int atk, int def)
    {
        _health = hp;
        _attack = atk;
        _defense = def;
    }
    public abstract void Attack();
    public abstract void Defend();
    public abstract void Drops();
}