public class SimpleGoal:Goal{
    private bool _isComplete;
    public SimpleGoal(string name,string description,int points):base(name,description,points) {
        _isComplete=false;
    }
    public SimpleGoal(string name,string description,int points,bool isComplete):base(name,description,points) {
        _isComplete=isComplete;

    }
    public override int RecordEvent(){
        _isComplete=true;
        Console.WriteLine($"Congratulations! you have earned {_points} points!");
        return _points;
    }
    public override bool IsComplete(){
        return _isComplete;
    }
    public override string GetDetailsString(){
        string check;
        if (IsComplete()){
            check="X";
        }else{
            check=" ";
        }
        return $"[{check}] {_shortName} ({_description})";
    }
    public override string GetStringRepresentation(){
        return $"SimpleGoal:{_shortName},{_description},{_points},{_isComplete}";
    }
}