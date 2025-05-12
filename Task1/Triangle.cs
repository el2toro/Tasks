namespace Task1;

public class Triangle(double sideA, double sideB, double sideC) : IShape
{
    // Public properties are used in case the user needs to access the sides of the triangle
    public double SideA { get; } = sideA;
    public double SideB { get; } = sideB;
    public double SideC { get; } = sideC;

    public double CalculateArea()
    {
        // Check if the triangle is valid
        if (!IsValidTriangle())
        {
            return double.NaN;
        }

        // Check if is right triangle
        if (IsRightTriangle())
        {
            return (SideA * SideB) / 2;
        }

        // Calculate area using Heron furmula if is not a right triangle

        // Semiperimeter
        double s = (SideA + SideB + SideC) / 2;

        // Area
        double area = Math.Sqrt(s * (s - SideA) * (s - SideB) * (s - SideC));

        return area;
    }

    private bool IsRightTriangle()
    {
        double[] sides = [SideA, SideB, SideC];

        // sort in ascending order, so hypotenuse is the largest side
        Array.Sort(sides);

        double firstLeg = sides[0];
        double secondLeg = sides[1];
        double hypotenuse = sides[2];

        // 1e-9 (which is 0.000000001) is used to account for floating-point precision errors that can occur
        return Math.Abs(hypotenuse * hypotenuse - (firstLeg * firstLeg + secondLeg * secondLeg)) < 1e-9;
    }

    private bool IsValidTriangle()
    {
        // Check if the sides form a valid triangle using the triangle inequality theorem
        return (SideA + SideB > SideC) && (SideA + SideC > SideB) && (SideB + SideC > SideA);
    }
}
