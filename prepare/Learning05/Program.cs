using System;

class Program
{
    static void Main(string[] args)
    {
        Square square = new Square("blue", 4);

        // Console.WriteLine(square.GetColor());
        // Console.WriteLine(square.GetArea());

        Rectangle rectangle = new Rectangle("yellow", 4, 6);

        // Console.WriteLine(rectangle.GetColor());
        // Console.WriteLine(rectangle.GetArea());

        Circle circle = new Circle("purple", 12);

        // Console.WriteLine(circle.GetColor());
        // Console.WriteLine(circle.GetArea());

        List<Shape> shapes = new List<Shape>();
        shapes.Add(square);
        shapes.Add(rectangle);
        shapes.Add(circle);

        foreach (Shape shape in shapes)
        {
            Console.WriteLine(shape.GetColor());
            Console.WriteLine(shape.GetArea());
            Console.WriteLine("pass");
        }
    }
}