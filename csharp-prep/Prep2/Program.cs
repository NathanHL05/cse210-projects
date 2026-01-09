using System;

class Program
{
    static void Main(string[] args)
    {   
        String letter = "";
        String passFail = "";
        Console.Write("What is your percent in the class? ");
        String scoreStr = Console.ReadLine();
        int score = int.Parse(scoreStr);
        if (score >= 90)
        {
            letter = "A";
            passFail = "Passed";
        }
        else if (score >= 80)
        {
            letter = "B";
            passFail = "Passed";
        }
        else if (score >= 70)
        {
            letter = "C";
            passFail = "Passed";
        }
        else if (score >= 60)
        {
            letter = "D";
            passFail = "Failed";
        }
        else
        {
            letter = "F";
            passFail = "Failed";
        }
        Console.WriteLine($"Based on your score, you have received and {letter} in your class.");
        Console.WriteLine($"You {passFail} your class.");
    }
}