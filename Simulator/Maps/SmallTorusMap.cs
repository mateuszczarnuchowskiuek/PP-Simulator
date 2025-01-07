namespace Simulator.Maps;

public class SmallTorusMap : Map
{
    public readonly int Size;
    private const int MinMapSize = 5;
    private const int MaxMapSize = 20;
    private Rectangle mapRectangle;

    public SmallTorusMap(int size)
    {
        if (size < MinMapSize || size > MaxMapSize)
            throw new ArgumentOutOfRangeException(nameof(size), "SmallTorusMap() only accepts size from 5 to 20!");
        else
        {
            Size = size;
            mapRectangle = new Rectangle(new Point(0, 0), new Point(Size - 1, Size - 1));
        }
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override bool Exist(Point p)
    {
        return mapRectangle.Contains(p);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override Point Next(Point p, Direction d)
    {
        Point point = p.Next(d);
        if (mapRectangle.Contains(point))
            return point;
        else
        {
            if (point.X < 0)
                point = new Point(point.X + Size, point.Y);
            if (point.X >= Size)
                point = new Point(point.X - Size, point.Y);
            if (point.Y < 0)
                point = new Point(point.X, point.Y + Size);
            if (point.Y >= Size)
                point = new Point(point.X, point.Y - Size);
            return point;
        }
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        Point point = p.NextDiagonal(d);
        if (mapRectangle.Contains(point))
            return point;
        else
        {
            if (point.X < 0)
                point = new Point(point.X + Size, point.Y);
            if (point.X >= Size)
                point = new Point(point.X - Size, point.Y);
            if (point.Y < 0)
                point = new Point(point.X, point.Y + Size);
            if (point.Y >= Size)
                point = new Point(point.X, point.Y - Size);
            return point;
        }
    }

    public override string? ToString()
    {
        return base.ToString();
    }
}
