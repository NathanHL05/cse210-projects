using System;

class Program
{
    static void Main(string[] args)
    {
        List<Goal> goals = new List<Goal>();
        int totalPoints = 0;
        while (true)
        {
            int input=0;
            while(input < 1 || input >6)
            {
                Console.WriteLine("Menu Options:\n");
                Console.WriteLine("\t1. Create New Goal\n");
                Console.WriteLine("\t2. List Goals\n");
                Console.WriteLine("\t3. Save Goals\n");
                Console.WriteLine("\t4. Load Goals\n");
                Console.WriteLine("\t5. Record Event\n");
                Console.WriteLine("\t6. Quit\n");
                Console.WriteLine("Select a choice from the menu:");
                input = getInput(6, getIntInput());
            }
            if(input == 6)
            {
                break;
            }
            if(input == 1)
            {
                int goalType = 0;
                while(goalType < 1 || goalType >3){
                Console.WriteLine("The types of Goals are:\n");
                Console.WriteLine("\t1. Simple Goal\n");
                Console.WriteLine("\t2. Eternal Goal\n");
                Console.WriteLine("\t3. Checklist Goal\n");
                Console.WriteLine("\t4. Exit \"goals\"\n");
                Console.WriteLine("Select a type of goal:");
                goalType = getInput(3, getIntInput());
                }
                if(goalType == 1)
                {
                    Console.WriteLine("Please a name for your goal: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Please describe your goal: ");
                    string description = Console.ReadLine();
                    Console.WriteLine("How many points is this goal worth: ");
                    int points = getIntInput();
                    
                    goals.Add(new Simple(description, points, name));
                }
                else if(goalType == 2)
                {
                    Console.WriteLine("Please a name for your goal: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Please describe your goal: ");
                    string description = Console.ReadLine();
                    Console.WriteLine("How many points is this goal worth each time: ");
                    int points = getIntInput();
                    goals.Add(new Eternal(description, points, name, false));
                }
                else if(goalType == 3)
                {
                    Console.WriteLine("Please a name for your goal: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Please describe your goal: ");
                    string description = Console.ReadLine();
                    Console.WriteLine("How many times will you repeat this goal: ");
                    int reps = getIntInput();
                    Console.WriteLine("How many points is this goal worth on completion: ");
                    int points = getIntInput();
                    Console.WriteLine("How many points is this goal worth each time: ");
                    int reward = getIntInput();
                    goals.Add(new Checklist(reward, reps, description, points, name));
                }
            }
            if(input == 2)
            {
                Console.WriteLine($"Total Points: {totalPoints}");
                printGoals(goals, totalPoints);
            }
            if(input == 3)
            {
                
            }
            if(input == 4)
            {
                
            }
            if(input == 5)
            {
                printGoals( goals, totalPoints);
                Console.WriteLine("What goal would you like to record progess on?");
                while (true)
                {
                    bool notDone = true;
                    Console.WriteLine("Please enter the goal name exactly as written, or the number before it.");
                    string goal = Console.ReadLine();
                    foreach(Goal g in goals)
                    {
                        if(goal == g.GetName())
                        {
                            g.AddProgress();
                            totalPoints += g.Points();
                            notDone = false;
                        }
                    }   
                    if(notDone)
                    {
                      try
                        {
                            int i = int.Parse(goal);
                            if(i > 0 && i <= goals.Count)
                            {
                                goals[i-1].AddProgress();
                                totalPoints += goals[i-1].Points();
                                notDone = false;
                            }

                        }
                        catch
                        {
                            Console.WriteLine("Please give a input a valid goal\n");
                        }
                    }
                    if (!notDone)
                    {
                        break;
                    }
                }
            }
        }
    }
    public static int getInput(int range, int input)
    {
        if(input < 1 || input > range)
        {
            Console.WriteLine("Enter one of the menu options.\n");
            return 0;
        }
        return input;
    }

    public static int getIntInput()
    {
        int input;
        try
        {
            input = int.Parse(Console.ReadLine());
            return input;
        }
        catch
        {
            Console.WriteLine("Enter a valid integer.");
            return -1;
        }
    }

    static void printGoals(List<Goal> goals, int totalPoints)
    {
        int i = 1;
            foreach(Goal g in goals)
            {
                Console.Write($"{i}: ");
                g.DisplayGoal();
                Console.WriteLine("\n");
                i++;
            }
    }
}