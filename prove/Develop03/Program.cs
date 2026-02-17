using System;

class Program
{
    static void Main(string[] args)
    {   
        bool running = true;
        while(running){
            int option = 0;
            while(option != 1 && option != 2){
                Console.WriteLine("1. Learn default scripture, John3:16");
                Console.WriteLine("2. Learn custom sripture\n");
                option = int.Parse(Console.ReadLine());
                if(option != 1&& option != 2)
                {
                    Console.WriteLine("Please choose one of the given options (1 or 2)");
                }
            }
            if(option == 1)
            {
                Scripture myScripture = new Scripture();
                Memorize(myScripture);
            }
            else if(option == 2)
            {
                Console.WriteLine("Write the scripture reference (ex: John 3:16): ");
                string reference = Console.ReadLine();
                while(true){
                    Console.WriteLine("How many verses is this scripture: ");
                    int amount = int.Parse(Console.ReadLine());
                    if(amount == 1)
                    {
                        Console.WriteLine("What is the verse number: ");
                        int number = int.Parse(Console.ReadLine());
                        Console.WriteLine("Type out the verse: ");
                        string verse = Console.ReadLine();
                        Scripture myScripture = new Scripture(reference, amount, number, verse);
                        Memorize(myScripture);
                        break;
                    }
                    else if(amount > 1)
                    {
                        List<int> numbers = new List<int>();
                        List<string> verses = new List<string>();
                        for(int i = 0; i < amount; i++)
                        {
                            Console.WriteLine("Type out one verse: ");
                            verses.Add(Console.ReadLine());
                            Console.WriteLine("What is the verse number: ");
                            numbers.Add(int.Parse(Console.ReadLine()));
                        }
                        Scripture myScripture = new Scripture(reference, amount, numbers, verses);
                        Memorize(myScripture);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please give a valid number of verses.");
                    }
                }
            }
            Console.WriteLine("Do you want to do another? (Y/N)");
            string cont = Console.ReadLine();
            if(cont == "y" || cont == "Y")
            {
            }
            else
            {
                running = false;
            }
        }
    }
    static void Memorize(Scripture myScripture)
    {
        bool loop = true;
                while(loop){
                    Console.Clear();
                    myScripture.Display();
                    Console.WriteLine("\nPress -Enter- to hide words, or type -Quit- to exit");
                    string going = Console.ReadLine();
                    if(going == "")
                    {
                        myScripture.Reduce();
                    }
                    else if(going == "Quit" || going == "quit")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please give a valid input.");
                    }
                }
    }
}