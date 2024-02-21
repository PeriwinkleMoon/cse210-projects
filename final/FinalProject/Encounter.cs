using System;

public abstract class Encounter
{
    private Random rnd = new Random();
    public abstract bool Start();
    
    public int RandomNumber(int lowerBound, int upperBound)
    {
        int rNum = rnd.Next(lowerBound, upperBound);
        return rNum;
    }
    public void Spinner()
    {
        string[] anim = {"|","/","=","\\","|","/","=","\\"};
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(2);
        while (DateTime.Now < endTime)
        {
            foreach (string a in anim)
            {    
                Console.Write(a);
                Thread.Sleep(100);
                Console.Write("\b \b");
            }
        }
    }
}