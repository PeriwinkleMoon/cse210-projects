using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Learning02 World!");

        //  JOB CLASS TESTING
        Job job1 = new Job();

        job1._jobTitle = "President & COO";
        job1._company = "Mattel inc.";
        job1._startYear = 2014;
        job1._endYear = 2023;

        job1.Display();

        // Job 2
        Job job2 = new Job();

        job2._jobTitle = "Chief Executive Officer";
        job2._company = "Gap inc.";
        job2._startYear = 2023;
        job2._endYear = 2024;

        job2.Display();

        //  RESUME CLASS TESTING
        Resume resume1 = new Resume();
        
        resume1._name = "Richard Dickson";
        resume1._jobs.Add(job1);
        resume1._jobs.Add(job2);

        resume1.DisplayResume();
    }
}