public class MenuGame{
    private List<Player> _players = new List<Player>();
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
        if(File.Exists("games.csv")){
            string[] lines = System.IO.File.ReadAllLines("games.csv");
            foreach (string line in lines)
            {
                string[] values = line.Split(";");
                foreach (Player player in _players)
                {
                    if(player.getUserName()==values[0]){           
                        DateTime date=DateTime.Parse(values[1]);
                        int time=int.Parse(values[2]);
                        MemoryGame mg = new MemoryGame(player,date,time);
                        _games.Add(mg);
                    }
                }    
            }
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
                DisplayScores();
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
    public void DisplayScores(){
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
                AddPlayer();
                SavePlayers();
                break;
            case 2:
                DisplayPlayers();
                break;
            case 3:
                BackupGame();
                break;
            case 4:
                RestoreBackup();
                SavePlayers();
                SaveGames();
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
                if (memoryGame.IsWin()){
                    _games.Add(memoryGame);
                    updateBestScore(_player);
                    SaveGames();
                }
                break;
            case 2:
                foreach (MemoryGame m in _games)
                {
                    Player p =m.getUser();
                    if(p.getUserName()==_player.getUserName()){
                        Console.WriteLine($"Date: {m.getDate()} \tScore: {m.getTime()} seconds.");
                    }
                }
                break;
            }
        }while(option!=3);
    }
    public void AddPlayer(){
        Console.Write("\nEnter username: ");
        string username = Console.ReadLine();
        Console.Write("\nEnter password: ");
        string password1 = Console.ReadLine();
        Console.Write("\nEnter password again: ");
        string password2 = Console.ReadLine();
        if (password1!=password2){
            Console.Write("\nPasswords doesn't match");
            return;
        }
        Console.Write("\nEnter name: ");
        string name = Console.ReadLine();
        Console.Write("\nEnter nick name: ");
        string nickname = Console.ReadLine();
        Player player = new Player(username,password1,name,nickname,0);
        _players.Add(player);
    }
    public void DisplayPlayers(){
        Console.WriteLine("\n");
        foreach (Player player in _players)
        {
            Console.WriteLine(player.GetStringRepresentation());
        }
    }
    public void updateBestScore(Player player){
        int min=-1;
        bool sw = false;
        foreach (MemoryGame m in _games)
        {
            if(m.getUser().getUserName()==player.getUserName()){
                if(sw==false){
                    min=m.getTime();
                    sw=true;
                }else{
                    if(m.getTime()<min){
                        min=m.getTime();
                    }
                }
            }
        }
        if (min!=-1){
            player.setBestScore(min);
        }
        foreach (Player p in _players)
        {
            if(p.getUserName()==player.getUserName()){
                p.setBestScore(player.getBestScore());
            }
        }
    }
    public void SavePlayers(){
        string txt = _admin.GetCompleteStringRepresentation()+"\n";
        foreach (Player player in _players)
        {
            string newLine=$"{player.GetCompleteStringRepresentation()}\n";
            txt+=newLine;    
        }
        File.WriteAllText("users.csv",txt.ToString());
    }
    public void SaveGames(){
        string txt ="";
        foreach (MemoryGame m in _games)
        {
            string newLine=$"{m.GetCompleteStringRepresentation()}\n";
            txt+=newLine;   
        }
        File.WriteAllText("games.csv",txt.ToString());
    }
    public void BackupGame(){
        Console.Write("What is the filename for the backup? ");
        string fileName = Console.ReadLine();
        string txt = _admin.GetCompleteStringRepresentation()+"\n";
        foreach (Player player in _players)
        {
            string newLine=$"{player.GetCompleteStringRepresentation()}\n";
            txt+=newLine;    
        }
        txt+="=;=;=;=;=;=\n";   
        foreach (MemoryGame m in _games)
        {
            string newLine=$"{m.GetCompleteStringRepresentation()}\n";
            txt+=newLine;   
        }
        File.WriteAllText(fileName,txt.ToString());
    }
    public void RestoreBackup(){
        Console.Write("What is the filename backup file? ");
        string fileName = Console.ReadLine();
        List<Player> players = new List<Player>();
        List<MemoryGame> games = new List<MemoryGame>();
        string[] lines = System.IO.File.ReadAllLines(fileName);
        int i=0;
        bool swGames=false;
        foreach (string line in lines)
        {
            string[] values = line.Split(";");
            if (i==0){
                _admin = new Admin(values[0],values[1],values[2]);
                i=i+1;
            }else{
                if (values[0]=="="){
                    swGames=true;
                }else{
                    if(swGames==false){
                        Player player = new Player(values[0],values[1],values[2],values[3],int.Parse(values[4]));
                        players.Add(player);
                    }else{
                        foreach (Player player in players)
                        {
                            if(player.getUserName()==values[0]){
                                MemoryGame memoryGame = new MemoryGame(player,DateTime.Parse(values[1]),int.Parse(values[2]));
                                games.Add(memoryGame);
                            }
                        }
                        
                    }
                }
            }
        }
        _players=players;
        _games=games;
    }
}