namespace LR2
{
    public interface IPrint
    {
        void Print();
    }

    public class GeometricShape
    {
        public virtual double Square() { return 0; }
    }

    public class Rectangle : GeometricShape, IPrint
    {
        public double width, height;
        public Rectangle(double _width, double _height)
        {
            width = _width;
            height = _height;
        }
        public override double Square()
        {
            return width * height;
        }
        public override string ToString()
        {
            return $"Прямоугольник:\n\tДлина - {width}\n\tШирина - {height}\n\tПлощадь - {Square()}";
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }

    public class Square : Rectangle, IPrint
    {
        public Square(double SideLength) : base(SideLength, SideLength)
        {

        }
        public override string ToString()
        {
            return $"Квадрат:\n\tДлина стороны - {width}\n\tПлощадь - {Square()}";
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }

    public class Circle : GeometricShape, IPrint
    {
        public double radius;
        public Circle(double _radius)
        {
            radius = _radius;
        }
        public override double Square()
        {
            return Math.PI * radius * radius;
        }
        public override string ToString()
        {
            return $"Круг:\n\tРадиус - {radius}\n\tПлощадь - {Square()}";
        }
        public void Print()
        {
            Console.WriteLine(ToString());
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IPrint f1 = new Rectangle(20, 10);
            IPrint f2 = new Square(15);
            IPrint f3 = new Circle(5);
            f1.Print();
            f2.Print();
            f3.Print();
        }
    }
}
