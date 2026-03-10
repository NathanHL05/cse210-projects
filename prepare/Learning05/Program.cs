using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        shapes.Add(new Square("red", 2.5));
        shapes.Add(new Rectangle("blue", 6, 3.5));
        shapes.Add(new Circle("green", 5));

        foreach (Shape item in shapes)
        {
            string color = item.GetColor();
            double area = item.GetArea();
            Console.WriteLine($"Color: {color}");
            Console.WriteLine($"Area: {area}\n");
        }
    }
}