public class MemoryGame{
    private Player _user;
    private List<Element> _matrix = new List<Element>();
    private int _time;
    private DateTime _date;
    //A default matrix of 4x4
    public MemoryGame(Player user,DateTime date,int time){
        _user=user;
        _time=time;
        _date=date;
    }
    public MemoryGame(Player user){
        _date = DateTime.Now;
        _time=0;
        _user=user;
        for(int i=0;i<8;i++){
            Random randomGenerator=new Random();
            int type = randomGenerator.Next(0,3);
            switch(type){
                case 0:
                    NumberElement number1 = new NumberElement();
                    _matrix.Add(number1);
                    NumberElement number2 = new NumberElement(number1.getValue());
                    _matrix.Add(number2);
                    break;
                case 1:
                    CharacterElement character1 = new CharacterElement();
                    _matrix.Add(character1);
                    CharacterElement character2 = new CharacterElement(character1.getValue());
                    _matrix.Add(character2);
                    break;
                case 2:
                    SymbolElement symbol1 = new SymbolElement();
                    _matrix.Add(symbol1);
                    SymbolElement symbol2 = new SymbolElement(symbol1.getValue());
                    _matrix.Add(symbol2);
                    break;
            }
        }
        StartMatrix();
    }
    public DateTime getDate(){
        return _date;
    }
    public Player getUser(){
        return _user;
    }
    public int getTime(){
        return _time;
    }
    public void Shuffle()  
    {  
        Random random = new Random();  
        int n = _matrix.Count;  
        for(int i= _matrix.Count - 1; i > 1; i--)
        {
            int rnd = random.Next(i + 1);  
            Element value = _matrix[rnd];  
            _matrix[rnd] = _matrix[i];  
            _matrix[i] = value;
        }
    }
    public void StartMatrix(){
        Shuffle();
        Console.Clear();
        printMatrix();
        Console.WriteLine("Memorize! We are going to start in: ");
        ShowCountDown(5);
        DateTime startTime = DateTime.Now;
        Console.Clear();
        for(int i=0;i<16;i++){
            _matrix[i].setSide("bottom");
        }

        string option;
        int ax=-1;
        int ay=-1;
        int bx=-1;
        int by=-1;
        do{
            Console.Clear();
            printMatrix();
            Console.WriteLine("> To surrender type R ");
            Console.WriteLine("> To flip card type position (example 4.4 for row 4 and column 4)");
            Console.Write("Enter a Option: ");
            option=Console.ReadLine();
            if (option!="R"){
                string[] positions = option.Split(".");
                if (ax==-1){
                    ax=int.Parse(positions[0]);
                    ay=int.Parse(positions[1]);
                    _matrix[(ax-1)*4+(ay-1)].setSide("top");
                }else{
                    bx=int.Parse(positions[0]);
                    by=int.Parse(positions[1]);
                    _matrix[(bx-1)*4+(by-1)].setSide("top");
                    if(_matrix[(ax-1)*4+(ay-1)].IsEquals(_matrix[(bx-1)*4+(by-1)])){
                        
                    }else{
                        Console.Clear();
                        printMatrix();
                        Console.WriteLine("> To surrender type R ");
                        Console.WriteLine("> To flip card type position (example 4.4 for row 4 and column 4)");
                        Console.Write("Enter a Option: ");
                        ShowSpinner(2);
                        _matrix[(ax-1)*4+(ay-1)].setSide("bottom");
                        _matrix[(bx-1)*4+(by-1)].setSide("bottom");
                    }
                    ax=-1;ay=-1;bx=-1;by=-1;
                }
            }else{
                break;
            }
        }while(!IsWin());
        if(IsWin()){
            DateTime currentTime = DateTime.Now;
            Console.Clear();
            printMatrix();
            Console.WriteLine("Congratulations you won!!!");
            TimeSpan ts = currentTime - startTime;
            _time=Convert.ToInt32(ts.TotalSeconds);
            Console.WriteLine($"Your score is {_time} seconds.\n");
            ShowSpinner(4);
        }
    }
    public void printMatrix(){
        Console.Write("\n");
        for(int i=0;i<16;i++){
            if(_matrix[i].getSide()=="top"){
                Console.Write(_matrix[i].GetStringRepresentation());
            }
            else{
                Console.Write($"\t[{(i/4)+1}.{(i%4)+1}]");
            }
            if((i+1)%4==0){
                Console.Write("\n");
            }
        }
        Console.Write("\n");
    }
    public bool IsWin(){
        for(int i=0;i<16;i++){
            if(_matrix[i].getSide()=="bottom")
                return false;
        }
        return true;
    }
    public int getScore(){
        return 0;
    }
    public void ShowCountDown(int seconds){
        for(int i=seconds;i>0;i--){
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
    public void ShowSpinner(int seconds){
        for(int i=0;i<seconds;i++){
            Console.Write("-");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("\\"); 
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("|");
            Thread.Sleep(250);
            Console.Write("\b \b");
            Console.Write("/");
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
    }
    public string GetCompleteStringRepresentation(){
        return $"{_user.getUserName()};{_date};{_time}";
    }
}