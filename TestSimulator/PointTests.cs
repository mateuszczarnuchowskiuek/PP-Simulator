using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class PointTests
{
    [Theory]
    [InlineData(0, 0, 0, 0)]
    [InlineData(-10, -10, -10, -10)]
    [InlineData(25, 25, 25, 25)]
    [InlineData(6, 5, 6, 5)]
    [InlineData(3, 54, 3, 54)]
    [InlineData(19, -5, 19, -5)]
    public void Constructor_CreatesPointCorrectly(int x, int y, int expectedX, int expectedY)
    {
        Point p = new Point(x, y);
        Assert.Equal((expectedX, expectedY), (p.X, p.Y));
    }

    [Theory]
    [InlineData(0, 0, Direction.Up, 0, 1)]
    [InlineData(0, 0, Direction.Down, 0, -1)]
    [InlineData(0, 0, Direction.Left, -1, 0)]
    [InlineData(0, 0, Direction.Right, 1, 0)]
    public void Next_GivesNextPointCorrectly(int x, int y, Direction d, int eX, int eY)
    {
        Point p = new Point(x, y);
        Point n = p.Next(d);
        Assert.Equal((eX, eY), (n.X, n.Y));
    }

    [Theory]
    [InlineData(0, 0, Direction.Up, 1, 1)]
    [InlineData(0, 0, Direction.Down, -1, -1)]
    [InlineData(0, 0, Direction.Left, -1, 1)]
    [InlineData(0, 0, Direction.Right, 1, -1)]
    public void NextDiagonal_GivesNextPointCorrectly(int x, int y, Direction d, int eX, int eY)
    {
        Point p = new Point(x, y);
        Point n = p.NextDiagonal(d);
        Assert.Equal((eX, eY), (n.X, n.Y));
    }
}
