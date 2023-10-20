public class NumberElement:Element{
    private int _value;
    public NumberElement():base(){
        List<int> numbers = new List<int>{1,2,3,4,5,6,7,8,9,10};
        Random randomGenerator=new Random();
        int number = randomGenerator.Next(0,numbers.Count);
        _value=numbers[number];
    }
    public NumberElement(int value):base(){
        _value=value;
    }
    public int getValue(){
        return _value;
    }
    public override string GetStringRepresentation(){
        return $"\t[ {_value} ]";
    }
}