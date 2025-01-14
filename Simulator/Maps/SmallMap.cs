namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    public const int MaxMapSize = 20;
    public List<IMappable>[,] MapFields;
    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > MaxMapSize)
            throw new ArgumentOutOfRangeException(nameof(sizeX), "SmallSquareMap() only accepts size from 5 to 20!");
        if (sizeY > MaxMapSize)
            throw new ArgumentOutOfRangeException(nameof(sizeY), "SmallSquareMap() only accepts size from 5 to 20!");

        MapFields = new List<IMappable>[SizeX, SizeY];
        for (int i = 0; i < SizeY; i++)
        {
            for (int j = 0; j < SizeX; j++)
            {
                MapFields[j, i] = new List<IMappable>();
            }
        }
    }

    public override void Add(IMappable mappable, Point point)
    {
        MapFields[point.X, point.Y].Add(mappable);
    }
    public override void Remove(IMappable mappable, Point point)
    {
        MapFields[point.X, point.Y].Remove(mappable);
    }
    public override List<IMappable> At(Point point)
    {
        return MapFields[point.X, point.Y];
    }
    public override List<IMappable> At(int x, int y)
    {
        return MapFields[x, y];
    }

    /* public override bool Exist(Point p)
    {
        return mapRectangle.Contains(p);
    } */

    /* public override Point Next(Point p, Direction d)
    {
        throw new NotImplementedException();
    } */

    /* public override Point NextDiagonal(Point p, Direction d)
    {
        throw new NotImplementedException();
    } */
}
