using System;

public class SpecialEncounter : Encounter
{
    private Random rnd = new Random();
    private Player _player = new Player();
    public SpecialEncounter(Player pc)
    {
        _player = pc;
    }
    public override bool Start()
    {
        Console.WriteLine("As you enter the next room the usual gloom of the dungeon dissipates.\n");
        Thread.Sleep(2000);
        Console.WriteLine("Golden beams of sunlight stream down from a break in the cieling and");
        Console.WriteLine("shower over you. Bathing you in warmth and making you feel relaxed.\n");
        Thread.Sleep(2000);
        Console.WriteLine("Standing in the center of the light is a brilliant unicorn.");
        Thread.Sleep(2000);
        Console.WriteLine("It turns it's head to you and meets your eyes. Then... winks.\n");
        Thread.Sleep(2000);
        Console.WriteLine("Immediately you feel a rush of joy fill you up like a sweet, warm cup\nof hot chocolate. And just like that - the unicorn vanishes.\n");

        Thread.Sleep(200);
        int rNum = rnd.Next(2, 8);
        _player.AddHealth(rNum);

        Console.Write("\nEnter to continue >");
        Console.ReadLine();
        Console.WriteLine("\nYou pause for a long moment, then stumble on with awe. -- Keep your wits about you! You're still in a dungeon!");
        Console.Clear();
        Console.WriteLine("You pause for a long moment, then stumble on with awe. -- Keep your wits about you! You're still in a dungeon!");
        return true;
    }

}