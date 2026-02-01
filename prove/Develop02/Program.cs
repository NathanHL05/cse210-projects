using System;
using Microsoft.VisualBasic;

class Program
{
    static void Main(string[] args)
    {
        bool running = true;
        Journal MyJournal = new Journal();
        while (running == true)
        {
            int option =0;
            bool i;
            int streak = getStreak();
            Console.WriteLine($"Your current writing streak is {streak} days\n1. Write new entry\n2. Display joural\n3. Save journal\n4. Load journal\n5. Close program\nWhich do you want to do? ");
            do
            {
                i = true;
                string input = Console.ReadLine();
                try
                {
                    option = int.Parse(input);
                    if (option == 1 || option == 2 || option == 3 || option == 4 || option == 5){
                        i = false;
                    }
                    else
                    {
                        Console.WriteLine("Please enter one of the options as 1,2,3,4, or 5");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter one of the options as 1,2,3,4, or 5");
                }
            } while(i == true);

            if (option == 1)
            {
                MyJournal.makeEntry();
                streakCounter();
            }
            else if(option == 2)
            {
                MyJournal.display();
            }
            else if(option == 3)
            {
                Console.WriteLine("How do you want to save your journal? ex: MyJournal.txt ");
                string path = Console.ReadLine();
                MyJournal.saveFile(path);
            }
            else if(option == 4)
            {
                Console.WriteLine("Which journal do you want to load? ex: MyJournal.txt ");
                string path = Console.ReadLine();
                MyJournal.loadFile(path);
            } 
            else if (option == 5)
            {
                running = false;
            }
        }
    }

    static int getStreak()
    {
        if (!File.Exists("streakCounter.txt"))
        {
            var now = DateTime.Now;
            File.WriteAllText("streakCounter.txt", $"{now}|0");
            return 0;
        }
        else
        {
            string contents = File.ReadAllText("streakCounter.txt");
            string[] streakInfo = contents.Split(new string[] {"|"}, StringSplitOptions.None);
            int streak = int.Parse(streakInfo[1]);
            return streak;
        }
        
    }
    static void streakCounter()
    {
        string contents = File.ReadAllText("streakCounter.txt");
        string[] streakInfo = contents.Split(new string[] {"|"}, StringSplitOptions.None);
        var now = DateTime.Now;
        int streak = int.Parse(streakInfo[1]);
        var last = DateTime.Parse(streakInfo[0]);
        TimeSpan difference = now.Date - last.Date;
        if (difference.TotalDays == 1)
        {
            streak++;
        }
        else if (difference.TotalDays == 0)
        {
        }
        else
        {
            streak = 1;
        }
        if (streak == 0)
        {
            streak = 1;
        }
        File.WriteAllText("streakCounter.txt", $"{now}|{streak}");
    }
}