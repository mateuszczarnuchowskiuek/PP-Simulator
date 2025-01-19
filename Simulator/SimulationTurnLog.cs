using Simulator.Maps;

namespace Simulator;

/// <summary>
/// State of map after single simulation turn.
/// </summary>
public class SimulationTurnLog
{
    /// <summary>
    /// Text representastion of moving object in this turn.
    /// CurrentMappable.ToString()
    /// </summary>
    public string Mappable { get; init; }
    /// <summary>
    /// Text representation of move in this turn.
    /// CurrentMoveName.ToString();
    /// </summary>
    public string Move { get; init; }
    /// <summary>
    /// Dictionary of IMappable.Symbol on the map in this turn.
    /// </summary>
    public Dictionary<Point, char> Symbols { get; init; }

    public SimulationTurnLog(IMappable mappable, string move, Map map)
    {
        Mappable = mappable.ToString();
        Move = move.ToString();
        Symbols = new Dictionary<Point, char>();
        for (int i = map.SizeY - 1; i >= 0; i--)
        {
            for (int j = 0; j < map.SizeX; j++)
            {
                if (map.At(j, i).Count == 0)
                {
                    Symbols.Add(new Point(j, i), '#');
                }
                else if (map.At(j, i).Count == 1)
                {
                    Symbols.Add(new Point(j, i), map.At(j, i)[0].Symbol.ToCharArray()[0]);
                }
                else
                {
                    Symbols.Add(new Point(j, i), 'X');
                }
            }
        }
    }
}
