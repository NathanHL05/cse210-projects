using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction fraction = new Fraction();
        Random random = new Random();
        for (int i = 0; i < 20; i++)
        {
            fraction.SetTop(random.Next(20));
            fraction.SetBottom(random.Next(1,20));
            Console.WriteLine(fraction.GetFractionString());
            Console.WriteLine(fraction.GetDecimalValue());
            Console.WriteLine("\n");
        }
    }
}