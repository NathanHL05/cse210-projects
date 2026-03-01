class Breathing : Activity
{
    public Breathing(string description, string name): base(description, name)
    {
    }

    public void RunBreathing()
    {
        WelcomeMessage();

        Loading(3);
        int timer = 0;
        int duration = GetDuration();
        while(timer < duration)
        {
            Console.Write("\n\nBreathe in...");
            Loading(4);
            Console.Write("\nBreath out...");
            Loading(6);
            timer += 10;
        }
        DisplayEnd();
    }
}