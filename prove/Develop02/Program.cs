using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Develop02 World!");
        Console.WriteLine("Welcome to the Journal Program!");
        Journal journal = new Journal();
        int option=5;
        do{
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            option = int.Parse(Console.ReadLine());
            switch(option){
                case 1:
                    Record record = new Record();
                    record.SetPrompt();
                    Console.WriteLine(record._prompt);
                    record._response=Console.ReadLine();
                    journal._records.Add(record);
                    break;
                case 2:
                    journal.Display();
                    break;
                case 3:
                    Console.WriteLine("What is the filename?");
                    journal._fileName=Console.ReadLine();
                    journal.Load();
                    break;
                case 4:
                    Console.WriteLine("What is the filename?");
                    journal._fileName=Console.ReadLine();
                    journal.Save();
                    break;
                case 5:
                    break;
            }
        }while(option!=5);
        
    }
}