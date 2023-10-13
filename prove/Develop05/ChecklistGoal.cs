public class ChecklistGoal:Goal{
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    public ChecklistGoal(string name,string description,int points,int target,int bonus):base(name,description,points) {
        _amountCompleted=0;
        _target=target;
        _bonus=bonus;
    }
    public ChecklistGoal(string name,string description,int points,int bonus,int target,int amountCompleted):base(name,description,points) {
        _amountCompleted=amountCompleted;
        _target=target;
        _bonus=bonus;
    }
    public override int RecordEvent(){
        _amountCompleted=_amountCompleted+1;
        if(IsComplete()){
            Console.WriteLine($"Congratulations! you have earned {_points+_bonus} points!");
            return _points+_bonus;
        }else{
            Console.WriteLine($"Congratulations! you have earned {_points} points!");
            return _points;
        }
    }
    public override bool IsComplete(){
        if(_amountCompleted>=_target){
            return true;
        }else{
            return false;
        }
    }
    public override string GetDetailsString(){
        string check;
        if (IsComplete()){
            check="X";
        }else{
            check=" ";
        }
        return $"[{check}] {_shortName} ({_description}) -- Currently completed: {_amountCompleted}/{_target}";
    }
    public override string GetStringRepresentation(){
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_bonus},{_target},{_amountCompleted}";
    }
}