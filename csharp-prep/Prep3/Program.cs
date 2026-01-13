using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";
        while (playAgain == "yes")
        {
            bool correct = false;
            Random randomGenerator = new Random();
            int keyNumber = randomGenerator.Next(0, 50);

            do
            {
                Console.WriteLine("Guess a number from 0-50: ");
                int guess = int.Parse(Console.ReadLine());

                if (guess == keyNumber)
                {
                    Console.WriteLine("You guessed it!\n");
                    correct = true;
                }
                else if (guess < keyNumber)
                {
                    Console.WriteLine("Higher\n");
                }
                else if (guess > keyNumber)
                {
                    Console.WriteLine("Lower\n");
                }
            } while (correct == false);
            Console.Write("Do you want to play again? (yes/no)");
            playAgain = Console.ReadLine();
        }
    }
}