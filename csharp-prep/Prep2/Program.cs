using System;

class Program
{
    static void Main(string[] args)
    {
        // Declaring grade numbers
        int A = 93;
        int aMinus = 90;
        int bPlus = 87;
        int B = 83;
        int bMinus = 80;
        int cPlus = 77;
        int C = 73;
        int cMinus = 70;
        int dPlus = 67;
        int D = 63;
        int dMinus = 60;

        // Begin user interaction
        Console.Write("What is your grade percentage? (as an intger) "); 
        string userInput = Console.ReadLine();
        int userGrade = int.Parse(userInput);
        
        if (userGrade >= A)
        {
            Console.WriteLine($"{userGrade}% is an A. You passed!");
        }
        else if (userGrade >= aMinus)
        {
            Console.WriteLine($"{userGrade}% is an A-. You passed!");
        }
        else if (userGrade >= bPlus)
        {
            Console.WriteLine($"{userGrade}% is an B+. You passed!");
        }
        else if (userGrade >= B)
        {
            Console.WriteLine($"{userGrade}% is an B. You passed!");
        }
        else if (userGrade >= bMinus)
        {
            Console.WriteLine($"{userGrade}% is an B-. You passed!");
        }
        else if (userGrade >= cPlus)
        {
            Console.WriteLine($"{userGrade}% is an C+. You passed!");
        }
        else if (userGrade >= C)
        {
            Console.WriteLine($"{userGrade}% is an C. You passed!");
        }
        else if (userGrade >= cMinus)
        {
            Console.WriteLine($"{userGrade}% is an C-. You passed!");
        }
         else if (userGrade >= dPlus)
        {
            Console.WriteLine($"{userGrade}% is an D+. You did not pass.");
        }
        else if (userGrade >= D)
        {
            Console.WriteLine($"{userGrade}% is an D. You did not pass.");
        }
         else if (userGrade >= dMinus)
        {
            Console.WriteLine($"{userGrade}% is an D-. You did not pass.");
        }
        else
        {
            Console.WriteLine($"{userGrade}% is an F. You did not pass.");
        }

    }
}