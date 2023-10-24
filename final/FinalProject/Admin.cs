public class Admin:User{
    public Admin(string username,string password,string name):base(username, password,name){
        
    }
    public override bool Login(string username,string password){
        if (_username==username &&_password==password)
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
    public string GetCompleteStringRepresentation(){
        return $"{_username};{_password};{_name}";
    }
}