public class CharacterElement:Element{
    private char _value;
    public CharacterElement():base(){
        List<char> characters = new List<char>{'A','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
        Random randomGenerator=new Random();
        int number = randomGenerator.Next(0,characters.Count);
        _value=characters[number];
    }
    public CharacterElement(char value):base(){
        _value=value;
    }
    public char getValue(){
        return _value;
    }
    public override string GetStringRepresentation(){
        return $"\t[ {Char.ToString(_value)} ]";
    }
}