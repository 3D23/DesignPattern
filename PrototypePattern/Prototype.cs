using System;

class Program
{
    static void Main(string[] args)
    {
        IFigure figure -new Rectangle(30, 40);
        IFigure clonedFigure = figure.Clone();
        figure.GetInfo();
        clonedFigure.GetInfo();

        figure = new Cirle(30);
        clonedFigure = figure.Clone();
        figure.GetInfo();
        clonedFigure.GetInfo();

        Console.Read();
    }
}

interface IFigure
{
    IFigure Clone();
    void GetInfo();
}

class Rectangle : IFigure
{
    int width;
    int height;

    public Rectangle(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public IFigure Clone() 
    {
        return new Rectangle(this.width, this.height);
    }

    public void GetInfo()
    {
        Console.WriteLine("Rectangle");
    }
}

class Circle : IFigure
{
    int radius;

    public Circle(int radius)
    {
        this.radius = radius;
    }

    public IFigure Clone()
    {
        return new Circle(this.radius);
    }

    public void GetInfo()
    {
        Console.Write("Circle");
    }
}