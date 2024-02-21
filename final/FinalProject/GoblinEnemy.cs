using System;

public class GoblinEnemy : Enemy
{
    public GoblinEnemy(int hp, int atk, int def) : base(hp, atk, def)
    {

    }
    public override int Drops() // How many coins it drops.
    {
        return rnd.Next(3,8);
    }
}