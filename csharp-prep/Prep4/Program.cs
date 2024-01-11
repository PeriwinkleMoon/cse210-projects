using System;
using System.Globalization;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Creating list
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a number to be added to the list. When you're done, enter 0.");
        int number = 0;
        // List input loop
        do {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            number = int.Parse(input);
            numbers.Add(number);
        } while( number != 0);
        // Counting Sum
        int sum = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            sum += numbers[i];
        }
        Console.WriteLine($"The sum of your list is: {sum}");
        // Finding the average
        int count = numbers.Count - 1; // Subtracting 1 from the count because it includes 0 in its count
        float average = ((float)sum) / count;
        Console.WriteLine($"The average is: {average}");
        // Finding the highest number
        int max = numbers.Max();
        Console.WriteLine($"The highest number is: {max}");
    }
}