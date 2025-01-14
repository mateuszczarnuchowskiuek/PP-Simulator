using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class SmallSquareMapTests
{
    [Theory]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(10)]
    [InlineData(15)]
    [InlineData(16)]
    [InlineData(19)]
    [InlineData(20)]
    public void Constructor_ValidSize_ShouldSetSize(int size)
    {
        SmallSquareMap map = new SmallSquareMap(size);
        Assert.Equal((size, size), (map.SizeX, map.SizeY));
    }

    [Theory]
    [InlineData(-5)]
    [InlineData(0)]
    [InlineData(2)]
    [InlineData(4)]
    [InlineData(21)]
    [InlineData(1000)]
    public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int size)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
    }

    [Theory]
    [InlineData(0, 0, 10, true)]
    [InlineData(-2, 3, 10, false)]
    [InlineData(3, -2, 10, false)]
    [InlineData(3, 4, 5, true)]
    [InlineData(3, 0, 5, true)]
    [InlineData(6, 1, 5, false)]
    [InlineData(19, 19, 20, true)]
    [InlineData(20, 20, 20, false)]
    [InlineData(50, 50, 20, false)]
    [InlineData(-1, -1, 15, false)]
    [InlineData(14, 14, 15, true)]
    public void Exist_ShouldReturnCorrectValue(int x, int y, int size, bool expected)
    {
        // Arrange
        var map = new SmallSquareMap(size);
        var point = new Point(x, y);
        // Act
        var result = map.Exist(point);
        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(5, 5, Direction.Up, 5, 6)]
    [InlineData(5, 14, Direction.Up, 5, 14)]
    [InlineData(5, -1, Direction.Up, 5, 0)]
    [InlineData(5, -3, Direction.Up, 5, -3)]
    [InlineData(5, 3, Direction.Right, 6, 3)]
    [InlineData(5, 0, Direction.Right, 6, 0)]
    [InlineData(5, -1, Direction.Right, 5, -1)]
    [InlineData(0, 0, Direction.Right, 1, 0)]
    [InlineData(13, 5, Direction.Right, 14, 5)]
    [InlineData(14, 5, Direction.Right, 14, 5)]
    [InlineData(5, 3, Direction.Left, 4, 3)]
    [InlineData(0, 3, Direction.Left, 0, 3)]
    [InlineData(1, 3, Direction.Left, 0, 3)]
    [InlineData(14, 3, Direction.Left, 13, 3)]
    [InlineData(5, 3, Direction.Down, 5, 2)]
    [InlineData(5, 0, Direction.Down, 5, 0)]
    [InlineData(5, 1, Direction.Down, 5, 0)]
    [InlineData(5, 4, Direction.Down, 5, 3)]
    [InlineData(5, 14, Direction.Down, 5, 13)]
    public void Next_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(15);
        var point = new Point(x, y);
        // Act
        var nextPoint = map.Next(point, direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }

    [Theory]
    [InlineData(5, 5, Direction.Up, 6, 6)]
    [InlineData(-1, -1, Direction.Up, 0, 0)]
    [InlineData(0, 0, Direction.Up, 1, 1)]
    [InlineData(14, 5, Direction.Up, 14, 5)]
    [InlineData(5, -1, Direction.Up, 6, 0)]
    [InlineData(5, 5, Direction.Right, 6, 4)]
    [InlineData(14, 14, Direction.Right, 14, 14)]
    [InlineData(5, 5, Direction.Left, 4, 6)]
    [InlineData(0, 14, Direction.Left, 0, 14)]
    [InlineData(1, 13, Direction.Left, 0, 14)]
    [InlineData(5, 5, Direction.Down, 4, 4)]
    [InlineData(0, 0, Direction.Down, 0, 0)]
    [InlineData(1, 1, Direction.Down, 0, 0)]
    public void NextDiagonal_ShouldReturnCorrectNextPoint(int x, int y, Direction direction, int expectedX, int expectedY)
    {
        // Arrange
        var map = new SmallSquareMap(15);
        var point = new Point(x, y);
        // Act
        var nextPoint = map.NextDiagonal(point, direction);
        // Assert
        Assert.Equal(new Point(expectedX, expectedY), nextPoint);
    }
}
