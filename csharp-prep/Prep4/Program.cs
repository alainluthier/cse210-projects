using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Prep4 World!");
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int input=0;
        List<int> list = new List<int>();
        do{
            Console.Write("Enter number: ");
            input = int.Parse(Console.ReadLine());
            if (input!=0){
                list.Add(input);
            }
        }while(input!=0);
        int sum=0;
        float average=0;
        int largest=0;
        int smallest=0;
        foreach (int x in list)
        {
            sum=sum+x;
            if(x>largest)
                largest=x;
            if(x>0 && x<smallest)
                smallest=x;
        }
        average=(float)sum/list.Count;
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {smallest}");
        list.Sort();
        foreach(int x in list){
            Console.WriteLine(x);
        }
    }
}