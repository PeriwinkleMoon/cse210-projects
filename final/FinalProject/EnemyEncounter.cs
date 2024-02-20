using System;

public class EnemyEncounter : Encounter
{
    Player _player = new Player();
    Random rnd = new Random();
    string _name;
    public EnemyEncounter(Player pc)
    {
        _player = pc;
    }
    public override void Start()
    {
        Enemy enemy = GetEnemy();
        Console.WriteLine($"A {_name} appears!");
    }
    public Enemy GetEnemy()
    {
        int enemy = RandomNumber(1,3);
        if (enemy == 1)
        {
            SkeletonEnemy skeleton = new SkeletonEnemy(RandomNumber(7,10),RandomNumber(3,8),RandomNumber(0,5));
            _name = "Skeleton";
            return skeleton;
        }
        else if (enemy == 2)
        {
            GoblinEnemy goblin = new GoblinEnemy(RandomNumber(8,15),RandomNumber(2,5),RandomNumber(0,5));
            _name = "Goblin";
            return goblin;
        }
        else
        {
            SlimeEnemy slime = new SlimeEnemy(RandomNumber(10,20),RandomNumber(1,7),RandomNumber(4,8));
            _name = "Slime";
            return slime;
        }
        
    }
    private int RandomNumber(int lowerBound, int upperBound)
    {
        int rNum = rnd.Next(lowerBound, upperBound);
        return rNum;
    }
}