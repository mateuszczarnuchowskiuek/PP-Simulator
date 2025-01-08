using Simulator;
using Simulator.Maps;

namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_PointsGiven_CreatesRectangleCorrectly()
    {
        Point p1 = new Point(0, 0);
        Point p2 = new Point(10, 10);
        Rectangle rec = new Rectangle(p1, p2);
        Assert.Equal((0, 0, 10, 10), (rec.X1, rec.Y1, rec.X2, rec.Y2));
    }

    [Theory]
    [InlineData(0, 0, 10, 10, 0, 0, 10, 10)]
    [InlineData(5, 2, 6, 7, 5, 2, 6, 7)]
    [InlineData(1, 2, 3, 4, 1, 2, 3, 4)]
    public void Constructor_PerfectCoordinates_CreatesRectangleCorrectly(int x1, int y1, int x2, int y2, int ex1, int ey1, int ex2, int ey2)
    {
        Rectangle rec = new Rectangle(x1, y1, x2, y2);
        Assert.Equal((ex1, ey1, ex2, ey2), (rec.X1, rec.Y1, rec.X2, rec.Y2));
    }

    [Theory]
    [InlineData(7, 2, 3, 5, 3, 2, 7, 5)]
    [InlineData(2, 6, 7, 2, 2, 2, 7, 6)]
    [InlineData(7, 7, 2, 2, 2, 2, 7, 7)]
    public void Constructor_MisplacedCoordinates_SwitchesCoordinates(int x1, int y1, int x2, int y2, int ex1, int ey1, int ex2, int ey2)
    {
        Rectangle rec = new Rectangle(x1, y1, x2, y2);
        Assert.Equal((ex1, ey1, ex2, ey2), (rec.X1, rec.Y1, rec.X2, rec.Y2));
    }

    [Theory]
    [InlineData(2, 5, 5, 5)]
    [InlineData(0, 0, 0, 0)]
    [InlineData(6, 5, 3, 5)]
    public void Constructor_ThinRectangle_ThrowsArgumentException(int x1, int y1, int x2, int y2)
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(x1, y1, x2, y2));
    }

    [Theory]
    [InlineData(-10, -10, true)]
    [InlineData(10, -10, true)]
    [InlineData(-10, 10, true)]
    [InlineData(10, 10, true)]
    [InlineData(0, 0, true)]
    [InlineData(50, 30, false)]
    [InlineData(-50, -30, false)]
    public void Contains_ShouldReturnCorrectValue(int x, int y, bool value)
    {
        Rectangle rec = new Rectangle(-10, -10, 10, 10);
        Point p = new Point(x, y);
        Assert.Equal(value, rec.Contains(p));
    }

    [Theory]
    [InlineData(0, 0, 10, 10, "(0, 0):(10, 10)")]
    [InlineData(5, -5, 12, 6, "(5, -5):(12, 6)")]
    [InlineData(5, 5, 2, 2, "(2, 2):(5, 5)")]
    public void ToString_WorksCorrectly(int x1, int y1, int x2, int y2, string s)
    {
        Rectangle rec = new Rectangle(x1, y1, x2, y2);
        Assert.Equal(s, rec.ToString());
    }


}
