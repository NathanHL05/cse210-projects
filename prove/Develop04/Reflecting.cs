class Reflecting : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };
    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public Reflecting(string description, string name) : base(description, name)
    {
    }

    public void RunReflecting()
    {
        WelcomeMessage();
        Console.WriteLine("\nConsider the following prompt: \n");
        GetPrompt(_prompts);
        Console.WriteLine("When you have something in mind press enter to continue.\n");
        Console.ReadLine();
        int timer = 0;
        int duration = GetDuration();
        while(timer < duration)
        {
            GetPrompt(_questions);
            Spinner(10);
            timer+=10;
        }
        DisplayEnd();
    }

}