public class NegativeGoal:Goal{
    public NegativeGoal(string name,string description,int points):base(name,description,points) {

    }
    public override int RecordEvent(){
        Console.WriteLine($"Sorry! you have lost {_points} points!");
        return _points*-1;
    }
    public override bool IsComplete(){
        return false;
    }
    public override string GetDetailsString(){
        return $"[ ] {_shortName} ({_description})";    
    }
    public override string GetStringRepresentation(){
        return $"NegativeGoal:{_shortName},{_description},{_points}";
    }
}