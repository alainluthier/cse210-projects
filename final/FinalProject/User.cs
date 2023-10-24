public abstract class User{
    protected string _username;
    protected string _password; 
    protected string _name;
    public User(string username,string password,string name){
        _username=username;
        _password=password;
        _name=name;
        
    }
    public abstract bool Login(string username,string password);
    public abstract bool ChangePassword(string password,string newPassword);
    
    public string getUserName(){
        return _username;
    }
}