using Simulator.Maps;

namespace Simulator;

public class Birds : Animals
{
    public bool CanFly = true;
    public override string Symbol
    {
        get
        {
            if (CanFly == true)
                return "B";
            else
                return "b";
        }
    }

    public override void Go(Direction direction)
    {
        if (AssignedMap != null)
        {
            Point from = Position;
            if (CanFly == true)
                Position = AssignedMap.Next(AssignedMap.Next(Position, direction), direction);
            else
                Position = AssignedMap.NextDiagonal(Position, direction);
            AssignedMap.Move(this, from, Position);
        }
    }

    public override string Info
    {
        get { return $"{Description} ({(CanFly ? "fly+" : "fly-")}) <{Size}>"; }
    }
}
