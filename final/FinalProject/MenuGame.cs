public class MenuGame{
    private List<User> _players = new List<User>();
    private List<MemoryGame> _games = new List<MemoryGame>();
    private Admin _admin;
    private Player _player;
    private string _type;
    public MenuGame(){
        _type="";
        if(File.Exists("users.csv")){
            string[] lines = System.IO.File.ReadAllLines("users.csv");
            int i=0;
            foreach (string line in lines)
            {
                string[] values = line.Split(";");
                if (i==0){
                    i=i+1;
                    _admin = new Admin(values[0],values[1],values[2]);
                }else{
                    _players.Add(new Player(values[0],values[1],values[2],values[3],int.Parse(values[4])));
                }
            }
        }else{
            Console.WriteLine("We are going to create admin account, please enter the following information:");
            Console.Write("Username: ");
            string username=Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Write("Name: ");
            string name = Console.ReadLine();
            _admin = new Admin(username,password,name);
        }
        Start();
    }
    public void Start(){
        int option=0;
        do{
        Console.WriteLine("===== PRINCIPAL MENU =====");
        Console.WriteLine("\t1. Login");
        Console.WriteLine("\t2. Display Players Scores");
        Console.WriteLine("\t3. Exit");
        Console.Write("Select a choice from the menu: ");
        option = int.Parse(Console.ReadLine());
        switch(option){
            case 1:
                Login();
                break;
            case 2:
                DisplayPlayersScore();
                break;
            }
        }while(option!=3);
    }
    public void Login(){
        Console.Clear();
        Console.WriteLine("Please login:");
        Console.Write("Type user (admin or player): ");
        string type=Console.ReadLine();
        Console.Write("Username: ");
        string username=Console.ReadLine();
        Console.Write("Password: ");
        string password = Console.ReadLine();
        switch(type){
            case "admin":
                if(_admin.Login(username,password)){
                    _type="admin";
                }
                break;
            case "player":
                foreach (Player p in _players)
                {
                    if(p.Login(username,password)){
                        _player=p;
                        _type="player";
                    }
                }
                break;
        
        }
        switch(_type){
            case "admin":
                Console.WriteLine($"\nWellcome {username}!!!\n");
                MenuAdmin();
                break;
            case "player":
                Console.WriteLine($"\nWellcome {username}!!!\n");
                MenuPlayer();
                break;
            default:
                Console.WriteLine("Wrong type, username or password");
                break;
        }
    }
    public void LogOut(){
        _type="";
        Console.Clear();
    }
    public void DisplayPlayersScore(){
        foreach (Player p in _players)
        {
            Console.WriteLine($"Name: {p.getNickName()} \tBest Score: {p.getBestScore()}");
        }
    }
    public void MenuAdmin(){
        int option=0;
        do{
        Console.WriteLine("===== ADMIN MENU =====");
        Console.WriteLine("\t1. Add Player");
        Console.WriteLine("\t2. Display Players");
        Console.WriteLine("\t3. Backup Game");
        Console.WriteLine("\t4. Restore Backup Game");
        Console.WriteLine("\t5. Log Out");
        Console.Write("Select a choice from the menu: ");
        option = int.Parse(Console.ReadLine());
        switch(option){
            case 1:
                
                break;
            case 2:
                
                break;
            }
        }while(option!=5);
    }
    public void MenuPlayer(){
        int option=0;
        do{
            
        Console.WriteLine("===== PLAYER MENU =====");
        Console.WriteLine("\t1. New Game");
        Console.WriteLine("\t2. Display Scores");
        Console.WriteLine("\t3. Log Out");
        Console.Write("Select a choice from the menu: ");
        option = int.Parse(Console.ReadLine());
        switch(option){
            case 1:
                MemoryGame memoryGame = new MemoryGame(_player);
                break;
            case 2:
                
                break;
            }
        }while(option!=3);
    }
    public void AddUser(){

    }
    public void BackupGame(){

    }
    public void LoadBackup(){

    }
}