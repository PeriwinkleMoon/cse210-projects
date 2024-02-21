using System;

public class SkeletonEnemy : Enemy
{
    public SkeletonEnemy(int hp, int atk, int def) : base(hp, atk, def)
    {

    }
    public override int Drops() // How many coins it drops.
    {
        return rnd.Next(1,6);
    }
}