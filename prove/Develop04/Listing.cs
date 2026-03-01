using System.Threading.Tasks.Dataflow;

class Listing: Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };
    

    public Listing(string description, string name) : base( description, name)
    {
    }

    

    public void RunListing()
    {
        WelcomeMessage();
        int timer = 0;
        int duration = GetDuration();

        Console.WriteLine("List as many responces as you can to the following prompt.");
        GetPrompt(_prompts);
        Console.Write("You may begin in: ");
        Loading(5);
        int input=0;
        while(timer < duration*1000)
        {
            if (Console.KeyAvailable)
            {
                Console.ReadLine();
                input ++;
            }
            Thread.Sleep(100);
            timer += 100;
        }
        Console.WriteLine($"You listed {input} items!\n\n");
        DisplayEnd();
    }
}