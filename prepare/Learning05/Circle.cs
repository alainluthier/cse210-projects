public class Circle:Shape{
    private double _radio;
    public Circle(string color,int radio):base(color){
        _radio=radio;
    }
    public override double  getArea(){
        return Math.PI*_radio*_radio;
    }
}