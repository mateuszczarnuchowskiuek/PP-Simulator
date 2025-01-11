using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished = false;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature
    {
        /* implement getter only */
        get
        {
            return Creatures[turnIndex % Creatures.Count];
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
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures, List<Point> positions, string moves)
    {
        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;

        if (Creatures.Count == 0)
            throw new Exception("Creatures' list is empty");
        if (Creatures.Count != Positions.Count)
            throw new Exception("Number of creatures differs from number of starting positions");

        directions = DirectionParser.Parse(Moves);
        for (int i = 0; i < Creatures.Count; i++)
        {
            Creatures[i].InitMapAndPosition(Map, Positions[i]);
        }
    }

    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn()
    {
        if (Finished == true)
            throw new Exception("Simulation is already finished!");

        //Console.WriteLine($"trunIndex: {turnIndex}");
        //Console.WriteLine($"CurrentDirection: {CurrentDirection}");
        CurrentCreature.Go(CurrentDirection);
        turnIndex++;

        if (turnIndex >= directions.Count)
            Finished = true;
    }
}
