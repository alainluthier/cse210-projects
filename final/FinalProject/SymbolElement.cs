public class SymbolElement:Element{
    private string _value;
    public SymbolElement():base(){
        List<string> symbols = new List<string>{"<3",":)",":'(",":/",";-)","╔╗","░░░","♥"};
        Random randomGenerator=new Random();
        int number = randomGenerator.Next(0,symbols.Count);
        _value=symbols[number];
    }
    public SymbolElement(string value):base(){
        _value=value;
    }
    public string getValue(){
        return _value;
    }
    public override string GetStringRepresentation(){
        return $"\t  {_value}  ";
    }
}