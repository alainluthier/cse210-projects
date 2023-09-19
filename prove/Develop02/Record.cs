public class Record{
    public DateTime _date = DateTime.Now;
    public string _prompt;
    public string _response;
    public void Write(DateTime date,string prompt,string response){
        _date=date;
        _prompt=prompt;
        _response=response;
    }
    public void Display(){
        Console.WriteLine($"Date: {_date.ToShortDateString()} -- Prompt: {_prompt}");
        Console.WriteLine(_response);
    }
    public void SetPrompt(){
        List<string> prompts = new List<string>(); 
        prompts.Add("Who was the most interesting person I interacted with today?");
        prompts.Add("What was the best part of my day?");
        prompts.Add("What was the most difficult thing to do on this day?");
        prompts.Add("What would you like to remember from this day?");
        prompts.Add("Did you meet a new person today?");
        prompts.Add("Did you discover something new about yourself this day?");
        prompts.Add("How did I see the hand of the Lord in my life today?");
        prompts.Add("What was the strongest emotion I felt today?");
        prompts.Add("If I had one thing I could do over today, what would it be?");
        Random randomGenerator=new Random();
        int number = randomGenerator.Next(0, prompts.Count-1);
        _prompt=prompts[number];
    }
}
