namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    //private const int MinMapSize = 5;
    //private const int MaxMapSize = 20;
    //public readonly int Size;
    //private Rectangle mapRectangle;

    public SmallSquareMap(int size) : base(size, size)
    {
        /*if (size < MinMapSize || size > MaxMapSize)
            throw new ArgumentOutOfRangeException(nameof(size), "SmallSquareMap() only accepts size from 5 to 20!");
        else
        {
            Size = size;
            mapRectangle = new Rectangle(new Point(0, 0), new Point(Size - 1, Size - 1));
        }*/
    }

    /*public override bool Exist(Point p)
    {
        return mapRectangle.Contains(p);
    }*/

    public override Point Next(Point p, Direction d)
    {
        if (mapRectangle.Contains(p.Next(d)))
            return p.Next(d);
        else
            return p;
    }

    public override Point NextDiagonal(Point p, Direction d)
    {
        if (mapRectangle.Contains(p.NextDiagonal(d)))
            return p.NextDiagonal(d);
        else
            return p;
    }
}
