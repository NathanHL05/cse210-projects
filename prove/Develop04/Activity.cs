class Activity
{
    private int _duration;
    private string _description;
    private string _name;

    public Activity(string description,string name)
    {
        _description = description;
        _name = name;
    }
    protected int GetDuration()
    {
        return _duration;
    }

    public void GetPrompt(List<string> list)
    {
        int length = list.Count;
        Random random = new Random();
        Console.WriteLine(list[random.Next(length)]);
    }

    protected void SetDuration()
    {
        while (true)
        {
            int duration = 0;
            Console.WriteLine("How long, in seconds, would you like for your session? ");
            try
            {
                duration = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Please enter a valid number.");
            }
            if(duration > 0)
            {
                _duration = duration;
                break;
            }
            else
            {
                Console.WriteLine("Enter a number greater than 0.");
            }
        }
    }

    protected void WelcomeMessage()
    {
        Console.WriteLine($"Welcome to the {_name}\n");
        Console.WriteLine(_description);
        SetDuration();
        Console.Write("Get Ready... ");
        Spinner(2);
    }

    protected void Spinner(int rotations)
    {
        for(int i = 0; i < rotations; i++)
        {   
            Console.Write($"\b-");
            Thread.Sleep(250);
            Console.Write($"\b\\");
            Thread.Sleep(250);
            Console.Write($"\b|");
            Thread.Sleep(250);
            Console.Write($"\b/");
            Thread.Sleep(250);
        }
        Console.Write($"\b");
    }
    protected void DisplayEnd()
    {
        Console.WriteLine("\nWell Done!\n");
        Spinner(2);
        Console.WriteLine($"You have completed another {_duration} second {_name}");
        Spinner(3); 
    }

    protected void Loading(int timer)
    {
        for(int i = 0; i < timer; i++)
        {   
            Console.Write($"\b{timer - i}");
            Thread.Sleep(1000);
        }
        Console.Write($"\b");
    }
}