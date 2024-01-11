using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome(); // Welcome message

        string userName = PromptUserName(); // Getting user's name
        int usernumber = PromptUserNumber(); // Getting user's favorite number
        int square = SquareNumber(usernumber); // Calculating square root

        DisplayResult(userName, square); // Printing message
    }
    static void DisplayWelcome() // DISPLAY WELCOME FUNCTION
    {
        Console.WriteLine("Welcome to the program!");
    }
    static string PromptUserName() // USER'S NAME FUNCTION
    {
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();
        return userName;
    }
    static int PromptUserNumber() // USER'S NUMBER FUNCTION
    {
        Console.Write("Enter your favorite number: ");
        string userInput = Console.ReadLine();
        int userNumber = int.Parse(userInput);
        return userNumber;
    }
    static int SquareNumber(int number) // CALCULATE SQUARE ROOT FUNCTION
    {
        int square = number * number;
        return square;
    }
    static void DisplayResult(string name, int number) // FINAL MESSAGE FUNCTION
    {
        Console.WriteLine($"{name}, the square of your number is {number}.");
    }
}   