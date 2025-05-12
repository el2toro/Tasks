using Task1;

namespace Tasks.Tests.Task1;

public class Task1Test
{
    [Theory]
    [InlineData(5, Math.PI * 5 * 5)]
    [InlineData(12.6, Math.PI * 12.6 * 12.6)]
    [InlineData(21.4, Math.PI * 21.4 * 21.4)]
    public void CalculateCircleArea(double radius, double expectedArea)
    {
        // Arrange
        IShape circle = new Circle(radius);

        // Act
        double area = circle.CalculateArea();

        // Assert
        Assert.Equal(expectedArea, area, 5);
    }

    [Theory]
    [InlineData(5, 6, 7, 14.696938456699069)] // Right triangle
    [InlineData(4, 5, 8, 8.1815340859768)] // Non-right triangle
    [InlineData(1, 10, 15, double.NaN)] // Invalid triangle
    [InlineData(0, 8, 9, double.NaN)] // Invalid triangle
    public void CalculateTriangleArea(double sideA, double sideB, double sideC, double expectedArea)
    {
        // Arrange
        IShape triangle = new Triangle(sideA, sideB, sideC);

        // Act
        double area = triangle.CalculateArea();

        // Assert
        Assert.Equal(expectedArea, area, 5);
    }

    [Theory]
    [InlineData(15, 9, 135)]
    [InlineData(55, 20, 1100)]
    [InlineData(7.8, 5.5, 42.9)]
    public void CalculateRectangleArea(double width, double height, double expectedArea)
    {
        // Arrange
        IShape rectangle = new Rectangle(width, height);

        // Act
        double area = rectangle.CalculateArea();

        // Assert
        Assert.Equal(expectedArea, area, 3);
    }
}
