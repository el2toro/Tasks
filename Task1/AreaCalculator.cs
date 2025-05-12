namespace Task1;

public interface IShape
{
    double CalculateArea();
}

public class Circle(double radius) : IShape
{
    public double Radius { get; } = radius;

    public double CalculateArea()
    => Math.PI * Radius * Radius;
}

// Rectangle added just to prove that a new geometric form can be added easily
// without modifying the existing code.
public class Rectangle(double width, double height) : IShape
{
    public double Width { get; } = width;
    public double Height { get; } = height;

    public double CalculateArea()
    => Width * Height;
}
