using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            int input=0;
            while(input < 1 || input >5){
                Console.WriteLine("Menu Options:\n");
                Console.WriteLine("\t1. Start Breathing Activity\n");
                Console.WriteLine("\t2. Start Reflecting Activity\n");
                Console.WriteLine("\t3. Start Listing Activity\n");
                Console.WriteLine("\t4. Start Senses Activity\n");
                Console.WriteLine("\t5. Quit\n");
                Console.WriteLine("Select a choise from the menu:");
                try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Enter a valid integer.");
                }
                if(input < 1 || input > 5)
                {
                    Console.WriteLine("Enter one of the menu options.\n");
                }
            }
            if(input == 5)
            {
                break;
            }
            else if(input == 1)
            {
                Breathing breathing = new Breathing("This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.", "Breathing Activity");
                breathing.RunBreathing();
            }
            else if (input == 2)
            {
                Reflecting reflecting = new Reflecting("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", "Reflecting Activity");
                reflecting.RunReflecting();
            }
            else if (input == 3)
            {
                Listing listing = new Listing("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", "Listing Activity");
                listing.RunListing();
            }
            else if (input == 4)
            {
                Senses senses = new Senses("This activity will help you relax by focusing on your environment. It will guide you to notice things around you using your five senses to ground you in the present moment.", "Senses Activity");
                senses.RunSenses();
            }

        }
    }
}