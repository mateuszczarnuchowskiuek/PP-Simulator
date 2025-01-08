namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    //public readonly int Size;
    //private const int MinMapSize = 5;
    //private const int MaxMapSize = 20;
    //private Rectangle mapRectangle;

    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        /* if (size < MinMapSize || size > MaxMapSize)
            throw new ArgumentOutOfRangeException(nameof(size), "SmallTorusMap() only accepts size from 5 to 20!");
        else
        {
            Size = size;
            mapRectangle = new Rectangle(new Point(0, 0), new Point(Size - 1, Size - 1));
        } */
    }

    /* public override bool Exist(Point p)
    {
        return mapRectangle.Contains(p);
    } */

    public override Point Next(Point p, Direction d)
    {
        Point point = p.Next(d);
        if (mapRectangle.Contains(point))
            return point;
        else
        {
            if (point.X < 0)
                point = new Point(point.X + SizeX, point.Y);
            if (point.X >= SizeX)
                point = new Point(point.X - SizeX, point.Y);
            if (point.Y < 0)
                point = new Point(point.X, point.Y + SizeY);
            if (point.Y >= SizeY)
                point = new Point(point.X, point.Y - SizeY);
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
                point = new Point(point.X + SizeX, point.Y);
            if (point.X >= SizeX)
                point = new Point(point.X - SizeX, point.Y);
            if (point.Y < 0)
                point = new Point(point.X, point.Y + SizeY);
            if (point.Y >= SizeY)
                point = new Point(point.X, point.Y - SizeY);
            return point;
        }
    }
}
