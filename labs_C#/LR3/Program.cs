using Microsoft.VisualBasic;
using System.Collections;

namespace LR3
{
    public class GeometricShape : IComparable
    {
        public virtual double get_area() { return 0; }
        public virtual void Print() { }
        int IComparable.CompareTo(object? other)
        {
            GeometricShape otherShape = other as GeometricShape;
            return this.get_area().CompareTo(otherShape.get_area());
        }
    }

    public class Rectangle : GeometricShape
    {
        public double width, height;
        public Rectangle(double _width, double _height)
        {
            width = _width;
            height = _height;
        }
        public override double get_area()
        {
            return width * height;
        }
        public override string ToString()
        {
            return $"Прямоугольник:\n\tДлина - {width}\n\tШирина - {height}\n\tПлощадь - {get_area()}";
        }
        public override void Print()
        {
            Console.WriteLine(ToString());
        }
    }

    public class Square : Rectangle
    {
        public Square(double SideLength) : base(SideLength, SideLength) {}
        public override string ToString()
        {
            return $"Квадрат:\n\tДлина стороны - {width}\n\tПлощадь - {get_area()}";
        }
        public override void Print()
        {
            Console.WriteLine(ToString());
        }
    }

    public class Circle : GeometricShape
    {
        public double radius;
        public Circle(double _radius)
        {
            radius = _radius;
        }
        public override double get_area()
        {
            return Math.PI * radius * radius;
        }
        public override string ToString()
        {
            return $"Круг:\n\tРадиус - {radius}\n\tПлощадь - {get_area()}";
        }
        public override void Print()
        {
            Console.WriteLine(ToString());
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //ArrayList
            ArrayList collection1 = [new Rectangle(10, 20), new Square(10), new Circle(5)];
            collection1.Sort();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Отсортированный ArrayList:");
            Console.ResetColor();
            foreach (GeometricShape i in collection1)
            {
                i.Print();
            }

            //List
            List<GeometricShape> collection2 = [new Rectangle(10, 20), new Square(19), new Circle(22)];
            collection2.Sort();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Отсортированный List:");
            Console.ResetColor();
            foreach (GeometricShape i in collection2)
            {
                i.Print();
            }

            //SparseMatrix
            
        }
    }
}
