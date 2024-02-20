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
        Console.WriteLine("As you enter the next room the usual gloom of the dungeon dissipates.\n");
        Thread.Sleep(1500);
        Console.WriteLine("Golden beams of sunlight stream down from a break in the cieling and");
        Console.WriteLine("shower over you. Bathing you in warmth and making you feel relaxed.\n");
        Thread.Sleep(1500);
        Console.WriteLine("Standing in the center of the light is a brilliant unicorn.");
        Thread.Sleep(1500);
        Console.WriteLine("It turns it's head to you and meets your eyes. Then... winks.\n");
        Thread.Sleep(1500);
        Console.WriteLine("Immediately you feel a rush of joy fill you up like a sweet, warm cup\nof hot chocolate. And just like that - the unicorn vanishes.\n");

        Thread.Sleep(1500);
        int lowerBound = 2;
        int upperBound = 8;
        int rNum = rnd.Next(lowerBound, upperBound);
        _player.AddHealth(rNum);
    }

}