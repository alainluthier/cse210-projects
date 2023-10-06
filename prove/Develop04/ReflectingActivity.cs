public class ReflectingActivity:Activity{
    private List<string> _prompts = new List<string>();
    private List<string> _questions= new List<string>();
    public ReflectingActivity(){
        _name = "Reflecting Activity";
        _description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        _duration= 30;
        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time when you helped someone in need.");
        _prompts.Add("Think of a time when you did something truly selfless.");
        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");
    }
    public void Run(){
        Console.Clear();
        DisplayStartingMessage();
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(4);
        DisplayPrompt();
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);
        DateTime currentTime = DateTime.Now;
        while (currentTime < futureTime)
        {
            DisplayQuestion();
            currentTime = DateTime.Now;
        }
        Console.WriteLine("");
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
    public string GetRandomQuestion(){
        Random randomGenerator=new Random();
        int number = randomGenerator.Next(0, _questions.Count);
        string question = _questions[number];
        _questions.RemoveAt(number);
        return question;
    }
    public void DisplayPrompt(){
        Console.WriteLine("\nConsider de following prompt:");
        Console.WriteLine($"\n--- {GetRandomPrompt()} ---");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        string read = Console.ReadLine();
        Console.WriteLine("\nNow ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();
    }
    public void DisplayQuestion(){
        Console.Write($"\n> {GetRandomQuestion()}");
        ShowSpinner(10);
    }
}