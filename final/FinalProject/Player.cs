public class Player:User{
    private string _nickName;
    private int _bestScore;
    public Player(string username,string password, string name,string nickName,int bestScore):base(username, password,name){
        _nickName=nickName;
        _bestScore=bestScore;
    }
    public override bool Login(string username,string password){
        if (_password==password)
            return true;
        else
            return false;
    }
    public override bool ChangePassword(string password,string newPassword){
        if (_password==password)
        {
            _password=newPassword;
            return true;
        }
        else{
            return false;
        }
    }
    public int getBestScore(){
        return _bestScore;
    }
    public void setBestScore(int bestScore){
        _bestScore=bestScore;
    }
    public string getNickName(){
        return _nickName;
    }
    public string GetStringRepresentation(){
        return $"Username: {_username}, Name:{_name}, NickName:{_nickName}";
    }
    public string GetCompleteStringRepresentation(){
        return $"{_username};{_password};{_name};{_nickName};{_bestScore}";
    }
}