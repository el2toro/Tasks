using Task3;

namespace Tasks.Tests.Task3;

public class Task3Tests
{
    public Task3Tests()
    {

    }

    [Theory]
    [InlineData(46, 2, 9)]
    [InlineData(11, 5, 6)]
    [InlineData(20, 2, 6)]
    [InlineData(75, 9, 14)]
    public void FindElementsForSum_ValidInput_ReturnsCorrectIndices(ulong sum, int expectedStart, int expectedEnd)
    {
        var list = new List<uint> { 0, 1, 2, 3, 4, 5, 6, 7, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        ElementsFinder.FindElementsForSum(list, sum, out int start, out int end);

        Assert.Equal(expectedStart, start);
        Assert.Equal(expectedEnd, end);
    }

    [Theory]
    [InlineData(1186, 4, 10)]
    [InlineData(398, 0, 5)]
    [InlineData(1120, 11, 12)]
    [InlineData(1409, 7, 11)]
    public void FindElementsForSum_ValidInput_ReturnsIndices(ulong sum, int expectedStart, int expectedEnd)
    {
        var list = new List<uint> { 55, 59, 62, 66, 71, 85, 99, 123, 214, 229, 365, 478, 642 };

        ElementsFinder.FindElementsForSum(list, sum, out int start, out int end);

        Assert.Equal(expectedStart, start);
        Assert.Equal(expectedEnd, end);
    }

    [Fact]
    public void FindElementsForSum_When_Indices_NotFound_ReturnsZeroIndices()
    {
        var list = new List<uint> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        ulong sum = 99;
        int expectedStart = 0;
        int expectedEnd = 0;

        ElementsFinder.FindElementsForSum(list, sum, out int start, out int end);

        Assert.Equal(expectedStart, start);
        Assert.Equal(expectedEnd, end);
    }
}
