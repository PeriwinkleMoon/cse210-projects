using System;

class Program
{
    static void Main(string[] args)
    {
        string answer = "no";
        do {
            // Getting random number
            Random randomGeneration = new Random();
            int magicNumber = randomGeneration.Next(1, 21);
            Console.WriteLine("Can you guess the magic number?");
            // declaring "guess" variable so the do-while loop will run
            int guess = 0;
            // declaring "attempts" variable before keeping track of attempts
            int attempts = 0;
            do 
            {
                Console.Write("What is your guess? ");
                string guessInput = Console.ReadLine();
                guess = int.Parse(guessInput);
                if (guess > magicNumber)
                {
                    Console.WriteLine("Lower.");
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher.");
                }
                attempts++;
            } while (guess != magicNumber);
            
            Console.WriteLine("You guessed it right!");
            Console.WriteLine($"It took you {attempts} tries.");
            Console.Write("Do you want to play again? ");
            answer = Console.ReadLine();
            } while (answer == "yes");
            Console.WriteLine("Thanks for playing!");
    }
}