using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Learning05 World!");
        Square square = new Square("Blue",10);
        Rectangle rectangle = new Rectangle("Blue",10,5);
        Circle circle = new Circle("Blue",10);
        List<Shape> list = new List<Shape>();
        list.Add(square);
        list.Add(rectangle);
        list.Add(circle);
        foreach (var i in list)
        {
            Console.WriteLine($"Color: {i.getColor()}, Area: {i.getArea()}");    
        }        
    }
}