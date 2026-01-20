using System;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
   
        Job job1 = new Job();

        Console.WriteLine("What was your job title: ");
        job1._jobTitle = Console.ReadLine();

        Console.WriteLine("What company did you work for: ");
        job1._company = Console.ReadLine();

        Console.WriteLine("What year did you start working there: ");
        job1._startYear = int.Parse(Console.ReadLine());

        Console.WriteLine("What year did you stop working there: ");
        job1._endYear = int.Parse(Console.ReadLine());


        Job job2 = new Job();

        Console.WriteLine("What was your job title: ");
        job2._jobTitle = Console.ReadLine();

        Console.WriteLine("What company did you work for: ");
        job2._company = Console.ReadLine();

        Console.WriteLine("What year did you start working there: ");
        job2._startYear = int.Parse(Console.ReadLine());

        Console.WriteLine("What year did you stop working there: ");
        job2._endYear = int.Parse(Console.ReadLine());


        Resume myResume = new Resume();
        Console.WriteLine("What is your name: ");
        myResume._name = Console.ReadLine();
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);
        
        myResume.Display();
    }
}