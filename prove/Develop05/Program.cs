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
                input = GetInput(6, GetIntInput());
            }
            if(input == 6)
            {
                break;
            }
            if(input == 1)
            {
                int goalType = 0;
                while(goalType < 1 || goalType >4){
                Console.WriteLine("The types of Goals are:\n");
                Console.WriteLine("\t1. Simple Goal\n");
                Console.WriteLine("\t2. Eternal Goal\n");
                Console.WriteLine("\t3. Checklist Goal\n");
                Console.WriteLine("\t4. Exit \"goals\"\n");
                Console.WriteLine("Select a type of goal:");
                goalType = GetInput(4, GetIntInput());
                }
                if(goalType == 1)
                {
                    Console.WriteLine("Please a name for your goal: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Please describe your goal: ");
                    string description = Console.ReadLine();
                    Console.WriteLine("How many points is this goal worth: ");
                    int points = GetIntInput();
                    
                    goals.Add(new Simple(description, points, name));
                }
                else if(goalType == 2)
                {
                    Console.WriteLine("Please a name for your goal: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Please describe your goal: ");
                    string description = Console.ReadLine();
                    Console.WriteLine("How many points is this goal worth each time: ");
                    int points = GetIntInput();
                    goals.Add(new Eternal(description, points, name, false));
                }
                else if(goalType == 3)
                {
                    Console.WriteLine("Please a name for your goal: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Please describe your goal: ");
                    string description = Console.ReadLine();
                    Console.WriteLine("How many times will you repeat this goal: ");
                    int reps = GetIntInput();
                    Console.WriteLine("How many points is this goal worth on completion: ");
                    int points = GetIntInput();
                    Console.WriteLine("How many points is this goal worth each time: ");
                    int reward = GetIntInput();
                    goals.Add(new Checklist(reward, reps, description, points, name));
                }
            }
            if(input == 2)
            {
                Console.WriteLine($"Total Points: {totalPoints}");
                PrintGoals(goals);
                Console.WriteLine("Press Enter to continue.\n");
                Console.ReadLine();
            }
            if(input == 3)
            {
                var fileInfo = new FileInfo("FileNames.txt");
                if (!fileInfo.Exists || fileInfo.Length == 0)
                {
                    Console.WriteLine("What do you want to name the file? ex: MyGoals");
                    string file = Console.ReadLine();
                    File.AppendAllLines("FileNames.txt", new[] {$"{file}\n"});
                    File.WriteAllText(file, string.Empty);
                    File.AppendAllLines(file, new[] {$"{totalPoints}|"});
                    foreach(Goal g in goals)
                    {
                        g.Save(file);
                    }
                }
                else
                {
                    string contents = File.ReadAllText("FileNames.txt");
                    contents = contents.Replace("\r\n", string.Empty);
                    string[] titles = contents.Split(new string[] {"\n"}, StringSplitOptions.None);
                    for(int i = 1; i < titles.Length; i++)
                    {
                     Console.WriteLine($"{i}: {titles[i-1]}");   
                    }
                    Console.WriteLine($"{titles.Length}: Make New File");
                    int option = 0;
                    while(true)
                    {
                        Console.WriteLine("Choose a file to save to: ");
                        option = GetIntInput();
                        if(option > 0 && option <= titles.Length + 1)
                        {
                            break;
                        }
                        Console.WriteLine("Give a file by number indicated");
                    }
                    File.WriteAllText(titles[option-1], string.Empty);
                    File.AppendAllLines(titles[option-1], new[] {$"{totalPoints}|"});
                    foreach(Goal g in goals)
                    {
                        g.Save(titles[option-1]);
                    }
                }                
            }
            if(input == 4)
            {
                var fileInfo = new FileInfo("FileNames.txt");
                if (!fileInfo.Exists)
                {
                    Console.WriteLine("There is no file to load from.");
                    
                }
                else
                {
                    string titleContents = File.ReadAllText("FileNames.txt");
                    titleContents = titleContents.Replace("\r\n", string.Empty);
                    string[] titles = titleContents.Split(new string[] {"\n"}, StringSplitOptions.RemoveEmptyEntries);
                    for(int i = 1; i <= titles.Length; i++)
                    {
                        Console.WriteLine($"{i}: {titles[i-1]}");   
                    }
                    int option = 0;
                    while(true)
                    {
                        Console.WriteLine("Choose a file to load from: ");
                        option = GetIntInput();
                        if(option > 0 && option <= titles.Length + 1)
                        {
                            break;
                        }
                        Console.WriteLine("Give a file by number indicated");
                    }
                    goals.Clear();
                    string contents = File.ReadAllText(titles[option-1]);
                    contents = contents.Replace("\r\n", string.Empty);
                    string[] entries = contents.Split(new string[] {"|"}, StringSplitOptions.None);
                    bool firstTime = true;
                    foreach (string x in entries)
                    {
                        
                        if(x == "")
                        {
                            break; 
                        }
                        string[] types = x.Split(new string[] {"\n"}, StringSplitOptions.None);
                        if (firstTime)
                        {
                            totalPoints = int.Parse(types[0]);
                            firstTime = false;
                        }
                        else
                        {
                            if(types[0] == "1")
                            {
                                goals.Add(new Simple(types[2], int.Parse(types[4]), types[1], bool.Parse(types[3])));
                            }
                            if(types[0] == "2")
                            {
                                goals.Add(new Eternal(types[2], int.Parse(types[4]),int.Parse(types[5]), types[1], bool.Parse(types[3])));
                            }
                            if(types[0] == "3")
                            {
                                goals.Add(new Checklist(int.Parse(types[7]), int.Parse(types[5]), types[2], int.Parse(types[4]),int.Parse(types[6]), types[1], bool.Parse(types[3])));
                                //(int reward, int reps, string description, int points, int progress, string name, bool complete)
                                //{$"3\n{GetName()}\n{GetDescription()}\n{IsComplete()}\n{GetPoints()}\n{_reps}\n{_progress}\n{_reward}|"}
                                //   0     1                 2                  3              4           5          6          7
                            }
                            Console.WriteLine($"Total Points: {totalPoints}");
                            PrintGoals(goals);
                        }
                    }
                }
            }
            if(input == 5)
            {
                PrintGoals( goals);
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
    public static int GetInput(int range, int input)
    {
        if(input < 1 || input > range)
        {
            Console.WriteLine("Enter one of the menu options.\n");
            return 0;
        }
        return input;
    }

    public static int GetIntInput()
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

    static void PrintGoals(List<Goal> goals)
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