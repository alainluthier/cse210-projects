public class GoalManager{
    private List<Goal> _goals;
    private int _score;
    public GoalManager(){
        _goals=new List<Goal>();
        _score=0;
    }
    public void Start(){
        int option=0;
        do{
        Console.WriteLine($"\nYou have {_score} points.\n");
        Console.WriteLine("\t1. Create New Goal");
        Console.WriteLine("\t2. List Goals");
        Console.WriteLine("\t3. Save Goals");
        Console.WriteLine("\t4. Load Goals");
        Console.WriteLine("\t5. Record Event");
        Console.WriteLine("\t6. Quit");
        Console.Write("Select a choice from the menu: ");
        option = int.Parse(Console.ReadLine());
        switch(option){
            case 1:
                CreateGoal();
                break;
            case 2:
                ListGoalDetails();
                break;
            case 3:
                SaveGoals();
                break;
            case 4:
                LoadGoals();
                break;
            case 5:
                RecordEvent();
                break;
            }
        }while(option!=6);
    }
    public void DisplayPlayerInfo(){
        
    }
    public void ListGoalNames(){
        int i=0;
        if (_goals.Count>0){
            Console.WriteLine("The goals are:");
            foreach (Goal goal in _goals)
            {
                i=i+1;
                Console.WriteLine($"{i}. {goal.getShortName()}");
            }
        }else{
            Console.WriteLine("No goals yet");
        }
    }
    public void ListGoalDetails(){
        int i=0;
        if (_goals.Count>0){
            Console.WriteLine("The goals are:");
            foreach (Goal goal in _goals)
            {
                i=i+1;
                Console.WriteLine($"{i}. {goal.GetDetailsString()}");
            }
        }else{
            Console.WriteLine("No goals yet");
        }
    }
    public void CreateGoal(){
        int option=0;

        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("What type of goal would you like to create? ");
        option = int.Parse(Console.ReadLine());
        switch(option){
            case 1:
                Console.Write("What is the name of your goal? ");
                string name = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                string description = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                int points = int.Parse(Console.ReadLine());
                SimpleGoal simpleGoal = new SimpleGoal(name,description,points);
                _goals.Add(simpleGoal);
                break;
            case 2:
                Console.Write("What is the name of your goal? ");
                name = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                description = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                points = int.Parse(Console.ReadLine());
                
                EternalGoal eternalGoal = new EternalGoal(name,description,points);
                _goals.Add(eternalGoal);
                break;
            case 3:
                Console.Write("What is the name of your goal? ");
                name = Console.ReadLine();
                Console.Write("What is a short description of it? ");
                description = Console.ReadLine();
                Console.Write("What is the amount of points associated with this goal? ");
                points = int.Parse(Console.ReadLine());
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int times = int.Parse(Console.ReadLine());
                Console.Write("Whay is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());

                ChecklistGoal checklistGoal = new ChecklistGoal(name,description,points,times,bonus);
                _goals.Add(checklistGoal);
                break;
            default:
                Console.WriteLine("Select a valid goal");
                option=0;
                break;
            }
    }
    public void RecordEvent(){
        int option=0;
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        option = int.Parse(Console.ReadLine());
        if(option >0 && option<=_goals.Count){
            _score=_score+_goals[option-1].RecordEvent();
            Console.WriteLine($"You now have {_score} popints.");
        }else{
            option=0;
            Console.WriteLine("Invalid goal.");
        }
    }
    public void SaveGoals(){
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();
        if(fileName.Contains(".txt"))
        {
            string txt = _score+"\n";
            foreach (Goal goal in _goals)
            {
                string newLine=$"{goal.GetStringRepresentation()}\n";
                txt+=newLine;    
            }
            File.WriteAllText(fileName,txt.ToString());
        }
        else{
            Console.WriteLine("Wrong extention file it must be .txt");
        }
    }
    public void LoadGoals(){
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();
        if(fileName.Contains(".txt")){
            _goals = new List<Goal>();
            string[] lines = System.IO.File.ReadAllLines(fileName);
            int i=0;
            foreach (string line in lines)
            {
                if (i==0){
                    _score = int.Parse(line);
                    i=i+1;
                }else{
                    string[] values = line.Split(":");
                    string[] array = values[1].Split(",");
                    switch(values[0]){
                        case "SimpleGoal":
                            SimpleGoal simpleGoal = new SimpleGoal(array[0],array[1],int.Parse(array[2]),bool.Parse(array[3]));
                            _goals.Add(simpleGoal);
                            break;
                        case "EternalGoal":
                            EternalGoal eternalGoal = new EternalGoal(array[0],array[1],int.Parse(array[2]));
                            _goals.Add(eternalGoal);
                            break;                            
                        case "ChecklistGoal":
                            ChecklistGoal checklistGoal = new ChecklistGoal(array[0],array[1],int.Parse(array[2]),int.Parse(array[3]),int.Parse(array[4]),int.Parse(array[5]));
                            _goals.Add(checklistGoal);
                            break;
                    }
                }
            }
        }else{
            Console.WriteLine("Wrong extention file it must be .txt");
        }
    }
}