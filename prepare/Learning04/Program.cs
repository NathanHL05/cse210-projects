using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Nathan Larson", "Programming with Classes");
        Console.WriteLine(assignment.GetSummary());
        MathAssignment myMath = new MathAssignment("Nathan L", "Multi-Variable Calculus", "4", "1-8");
        Console.WriteLine(myMath.GetSummary());
        Console.WriteLine(myMath.GetHomeworkList());
        WritingAssignment myWriting = new WritingAssignment("John Doe", "English 150", "Super Cool Stuff");
        Console.WriteLine(myWriting.GetSummary());
        Console.WriteLine(myWriting.GetWritingInformation());
    }
}