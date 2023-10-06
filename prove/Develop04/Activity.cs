public class Activity{
    protected string _name;
    protected string _description;
    protected int _duration;
    public Activity(){
        
    }
    public void DisplayStartingMessage(){
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine("");
        Console.WriteLine($"{_description}");
        Console.Write("\nHow long, in seconds, would you like for your session? ");
        _duration=int.Parse(Console.ReadLine());
    }
    public void DisplayEndingMessage(){
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
    }
    public void ShowSpinner(int seconds){
        for(int i=0;i<seconds;i++){
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("\\"); 
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }
    public void ShowCountDown(int seconds){
        for(int i=seconds;i>0;i--){
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}