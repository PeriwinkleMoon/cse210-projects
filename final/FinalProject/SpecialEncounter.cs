using System;

public class SpecialEncounter : Encounter
{
    // List<int> encounters = new List<int>();
    Random rnd = new Random();
    Player _player = new Player();
    public SpecialEncounter(Player pc)
    {
        _player = pc;
    }
    public override void Start()
    {
        Console.WriteLine("As you enter the next room the usual gloom of the dungeon dissipates.");
        Thread.Sleep(600);
        Console.WriteLine("Golden beams of sunlight stream down from a break in the cieling and");
        Console.WriteLine("shower over you. Bathing you in warmth and making you feel relaxed.");
        Thread.Sleep(600);
        Console.WriteLine("Standing in the center of the light is a brilliant unicorn.");
        Thread.Sleep(600);
        Console.WriteLine("It turns it's head to you and meets your eyes. Then... winks.");
        Thread.Sleep(600);
        Console.WriteLine("Immediately you feel a rush of joy fill you up like a sweet, warm cup\n of hot chocolate. And just like that - the unicorn vanishes.");

        Thread.Sleep(600);
        int lowerBound = 2;
        int upperBound = 8;
        int rNum = rnd.Next(lowerBound, upperBound);
        _player.AddHealth(rNum);
    }

}