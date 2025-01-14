using Simulator.Maps;

namespace Simulator;

public class Animals : IMappable
{
    public virtual string Symbol
    {
        get => "A";
    }
    private string description = "Unknown";
    public required string Description
    {
        get { return description; }
        init
        {
            description = Validator.Shortener(value, 3, 15, '#');
        }
    }
    public uint Size { get; set; } = 3;
    public virtual string Info
    {
        get { return $"{Description} <{Size}>"; }
    }

    public Map? AssignedMap { get; set; }
    public Point Position { get; set; }

    public void InitMapAndPosition(Map map, Point position)
    {
        AssignedMap = map;
        Position = position;
        AssignedMap.Add(this, position);
    }

    public virtual void Go(Direction direction)
    {
        if (AssignedMap != null)
        {
            Point from = Position;
            Position = AssignedMap.Next(Position, direction);
            AssignedMap.Move(this, from, Position);
        }
    }

    public override string ToString()
    {
        return $"{this.GetType().Name.ToUpper()}: {this.Info}";
    }

}
