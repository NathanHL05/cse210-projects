using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int inputNumber = 0;
        int total = 0;
        float avg = 0;
        int inputs = 0;
        int greatest = 0;
        int least = 999999999;
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        while(true)
        {
            Console.Write("Enter a number: ");
            inputNumber = int.Parse(Console.ReadLine());
            if(inputNumber == 0)
            {
                break;
            }
            numbers.Add(inputNumber);
        }  
        numbers.Sort();

        foreach (int number in numbers)
        {
            if(number > greatest)
            {
                greatest = number;
            }
            total = total + number;
            inputs++;
            if (number > 0 && number < least)
            {
                least = number;
            }
        }
        
        avg = (float)total / (float)inputs;
        Console.WriteLine($"The sum is: {total}");
        Console.WriteLine($"The average is: {avg}");
        Console.WriteLine($"The largest number is: {greatest}");
        Console.WriteLine($"The smallest positive number is: {least}");
        Console.WriteLine("The sorted list is: ");
        foreach (int x in numbers)
        {
            Console.WriteLine(x);
        }


    }
}