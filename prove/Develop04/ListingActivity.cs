public class ListingActivity:Activity {
    private List<string> _prompts = new List<string>();
    private List<string> _listFromUser = new List<string>();
    public ListingActivity(){
        _name = "Listing Activity";
        _description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        _duration= 30;
        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week?");
        _prompts.Add("When have you felt the Holy Ghost this month?");
        _prompts.Add("Who are some of your personal heroes?");
    }
    public void Run(){
        Console.Clear();
        DisplayStartingMessage();
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(4);
        GetListFromUser();
        Console.WriteLine($"\nYou listed {_listFromUser.Count} items!");
        Console.WriteLine("\nWell done!!");
        ShowSpinner(4);
        DisplayEndingMessage();
        ShowSpinner(4);
    }
    public string GetRandomPrompt(){
        Random randomGenerator=new Random();
        int number = randomGenerator.Next(0, _prompts.Count);
        string prompt = _prompts[number];
        _prompts.RemoveAt(number);
        return prompt;
    }
    public void GetListFromUser(){
        Console.WriteLine("\nList as many responses you can to the following prompt:");
        Console.WriteLine($"\n--- {GetRandomPrompt()} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine("");
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);
        DateTime currentTime = DateTime.Now;
        while (currentTime < futureTime)
        {
            Console.Write("> ");
            string text = Console.ReadLine();
            _listFromUser.Add(text);
            currentTime = DateTime.Now;
        }
    }
}