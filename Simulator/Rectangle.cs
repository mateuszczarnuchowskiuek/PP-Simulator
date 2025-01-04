namespace Simulator;

public class Rectangle
{
    public int X1, Y1, X2, Y2;

    public Rectangle(int x1, int y1, int x2, int y2)
    {
        try
        {
            if (x1 == x2 || y1 == y2)
                throw new ArgumentException("We don't want \"thin\" rectangles");
            else
            {
                if (x1 > x2)
                    (x2, x1) = (x1, x2);
                if (y1 > y2)
                    (y2, y1) = (y1, y2);
            }
        }
        finally
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }
    }

    public Rectangle(Point p1, Point p2) : this(p1.X, p1.Y, p2.X, p2.Y) { }

    public bool Contains(Point point)
    {
        if (X1 <= point.X && point.X <= X2 && Y1 <= point.Y && point.Y <= Y2)
            return true;
        else
            return false;
    }

    public override string ToString()
    {
        return $"({X1}, {Y1}):({X2}, {Y2})";
    }
}
