namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    public const int MaxMapSize = 20;

    public SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > MaxMapSize)
            throw new ArgumentOutOfRangeException(nameof(sizeX), "SmallSquareMap() only accepts size from 5 to 20!");
        if (sizeY > MaxMapSize)
            throw new ArgumentOutOfRangeException(nameof(sizeY), "SmallSquareMap() only accepts size from 5 to 20!");

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
