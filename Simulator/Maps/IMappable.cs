using Simulator;

namespace Simulator.Maps;

public interface IMappable
{
    public string Symbol { get; }
    public Map? AssignedMap { get; set; }
    public Point Position { get; set; }
    void InitMapAndPosition(Map map, Point position);
    void Go(Direction direction);
}
