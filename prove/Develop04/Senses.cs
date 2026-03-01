
class Senses : Activity
{
    List<string> _prompts = new List<string>
    {
      "List some things that you see",
      "List some things that you can feel",
      "List some things you can hear",
      "List some things you can smell",
      "List some things you can taste (or something you like the taste of)"
    };
    public Senses(string description, string name) : base( description, name)
    {
    }

    public void RunSenses()
    {
        WelcomeMessage();
        int timer = 0;
        int duration = GetDuration();
        for (int i = 0; i < 5; i++)
        {
            timer = 0;
            Console.WriteLine($"\n{_prompts[i]}: \n");
            while(timer < duration *1000 / 5)
            {
                if (Console.KeyAvailable)
            {
                Console.ReadLine();
            }
            Thread.Sleep(100);
            timer += 100;
            }

        }
        DisplayEnd();
    }
}
