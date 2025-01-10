namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{
    public const int MinMapSize = 5;
    public int SizeX { get; init; }
    public int SizeY { get; init; }
    public readonly Rectangle mapRectangle;
    public Map(int sizeX, int sizeY)
    {
        if (sizeX < MinMapSize)
            throw new ArgumentOutOfRangeException(nameof(sizeX), "SmallSquareMap() only accepts size from 5 to 20!");
        if (sizeY < MinMapSize)
            throw new ArgumentOutOfRangeException(nameof(sizeY), "SmallSquareMap() only accepts size from 5 to 20!");

        SizeX = sizeX;
        SizeY = sizeY;
        mapRectangle = new Rectangle(new Point(0, 0), new Point(SizeX - 1, SizeY - 1));
    }

    public abstract void Add(Creature creature, Point point);
    public abstract void Remove(Creature creature, Point point);
    public void Move(Creature creature, Point from, Point to)
    {
        Remove(creature, from);
        Add(creature, to);
    }
    public abstract List<Creature> At(Point point);
    public abstract List<Creature> At(int x, int y);

    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p)
    {
        return mapRectangle.Contains(p);
    }

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);
}