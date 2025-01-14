using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Mappables moving on the map.
    /// </summary>
    public List<IMappable> Mappables { get; }

    /// <summary>
    /// Starting positions of mappables.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of mappables moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first mappable, second for second and so on.
    /// When all mappables make moves, 
    /// next move is again for first mappable and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Mappables which will be moving current turn.
    /// </summary>
    public IMappable CurrentMappable
    {
        /* implement getter only */
        get
        {
            return Mappables[turnIndex % Mappables.Count];
        }
    }

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    private List<Direction> directions;
    public string CurrentMoveName
    {
        /* implement getter only */
        get
        {
            return directions[turnIndex % directions.Count].ToString().ToLower();
        }
    }

    private Direction CurrentDirection
    {
        get
        {
            return directions[turnIndex];
        }
    }
    public int turnIndex = 0;

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if mappables' list is empty,
    /// if number of mappables differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables, List<Point> positions, string moves)
    {
        Map = map;
        Mappables = mappables;
        Positions = positions;
        Moves = moves;

        if (Mappables.Count == 0)
            throw new Exception("Mappables' list is empty");
        if (Mappables.Count != Positions.Count)
            throw new Exception("Number of mappables differs from number of starting positions");

        directions = DirectionParser.Parse(Moves);
        for (int i = 0; i < Mappables.Count; i++)
        {
            Mappables[i].InitMapAndPosition(Map, Positions[i]);
        }
    }

    /// <summary>
    /// Makes one move of current mappable in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished == true)
            throw new Exception("Simulation is already finished!");

        //Console.WriteLine($"trunIndex: {turnIndex}");
        //Console.WriteLine($"CurrentDirection: {CurrentDirection}");
        CurrentMappable.Go(CurrentDirection);
        turnIndex++;

        if (turnIndex >= directions.Count)
            Finished = true;
    }
}
