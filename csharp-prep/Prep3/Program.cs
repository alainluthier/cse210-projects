using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Prep3 World!");
        Random randomGenerator = new Random();
        int input = 0;
        int guesses = 0;
        int number=0;
        string response ="";
        do{
            input=0;
            guesses=0;
            response ="";
            number = randomGenerator.Next(1, 100);
            Console.WriteLine($"What is the magic number? {number}");
        do{
            Console.Write("What is your guess? ");
            input = int.Parse(Console.ReadLine());
            if(number>input)
                Console.WriteLine("Higher");
            else
                if(number<input)
                    Console.WriteLine("Lower");
                else
                    Console.WriteLine("You guessed it!");
            guesses++;
        }while(input!=number);
        Console.WriteLine($"Total guesses {guesses}");
        Console.WriteLine($"Do you want to play again? yes/no");
        response=Console.ReadLine();
        }while(response=="yes");
        
    }
}