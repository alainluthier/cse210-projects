using System;

class Program
{
    static void Main(string[] args)
    {
        //Console.WriteLine("Hello Learning03 World!");
        //First constructor (defalut value)
        Console.WriteLine("Testing constructors");
        Fraction first = new Fraction();
        Console.WriteLine(first.GetFractionString());
        //Second constructor (whole number)
        Fraction second = new Fraction(6);
        Console.WriteLine(second.GetFractionString());
        //Third constructor (fraction)
        Fraction third = new Fraction(6,7);
        Console.WriteLine(third.GetFractionString());

        Console.WriteLine("Testing Representations of fractions");
        //Testing representations for a fractions
        Fraction a = new Fraction(1);
        Fraction b = new Fraction(5);
        Fraction c = new Fraction(3,4);
        Fraction d = new Fraction(1,3);
        Console.WriteLine(a.GetFractionString());
        Console.WriteLine(a.GetDecimalValue());
        Console.WriteLine(b.GetFractionString());
        Console.WriteLine(b.GetDecimalValue());
        Console.WriteLine(c.GetFractionString());
        Console.WriteLine(c.GetDecimalValue());
        Console.WriteLine(d.GetFractionString());
        Console.WriteLine(d.GetDecimalValue());
    }
}