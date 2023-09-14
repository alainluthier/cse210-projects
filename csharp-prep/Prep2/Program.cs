using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Prep2 World!");
        Console.WriteLine("Please enter your grade percentage:");
        int percentage = int.Parse(Console.ReadLine());
        string letter="";
        if(percentage>=90){
            letter="A";
        }else{
            if(percentage>=80)
                letter="B";
            else
                if(percentage>=70)
                    letter="C";
                else
                    if(percentage>=60)
                        letter="D";
                    else
                        letter="F";

        }
        int lastDigit=percentage%10;
        string sign="";
        if(percentage<100 && percentage>60)
            if(lastDigit>=7)
                sign="+";
            else
                if(lastDigit<3)
                    sign="-";
        Console.WriteLine($"Your grade is {letter}{sign}");
        if(percentage>=70)
            Console.WriteLine("Congratulations!, you passed the course.");
        else
            Console.WriteLine("Sorry, you failed. Try it next time.");
    }
}