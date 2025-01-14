using Simulator;

namespace Simulator.Maps;

public interface IMappable
{
    void InitMapAndPosition(Map map, Point position);
    void Go(Direction direction);
}
