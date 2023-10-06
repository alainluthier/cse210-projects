public class BreathingActivity:Activity {
    public BreathingActivity(){
        _name = "Breathing Activity";
        _description = "This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.";
        _duration= 30;
    }
    public void Run(){
        Console.Clear();
        DisplayStartingMessage();
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(4);
        DateTime startTime = DateTime.Now;
        DateTime futureTime = startTime.AddSeconds(_duration);
        DateTime currentTime = DateTime.Now;
        Console.WriteLine("");
        while (currentTime < futureTime)
        {
            Console.Write("\nBreathe in...");
            ShowCountDown(4);
            Console.Write("\nNow breathe out...");
            ShowCountDown(6);    
            Console.WriteLine("");
            currentTime = DateTime.Now;
        }
        Console.WriteLine("\nWell done!!");
        ShowSpinner(4);
        DisplayEndingMessage();
        ShowSpinner(4);
    }
}