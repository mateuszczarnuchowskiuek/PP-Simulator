using Simulator.Maps;

namespace Simulator;

public abstract class Creature : IMappable
{
    public abstract string Symbol { get; }
    private string name = "Unknown";
    public string Name
    {
        get { return name; }
        init
        {
            name = Validator.Shortener(value, 3, 25, '#');
        }
    }
    private int level = 1;
    public int Level
    {
        get { return level; }
        init
        {
            level = Validator.Limiter(value, 1, 10);
        }
    }
    public Map? AssignedMap { get; set; }
    public Point Position { get; set; }
    public Creature(string Name, int Level = 1)
    {
        this.Name = Name;
        this.Level = Level;
    }
    public Creature()
    {
        //empty constructor
    }

    public void InitMapAndPosition(Map map, Point position)
    {
        AssignedMap = map;
        Position = position;
        AssignedMap.Add(this, position);
    }

    public abstract string Greeting();
    public abstract string Info { get; }

    public void Upgrade()
    {
        level++;
        level = Validator.Limiter(level, 0, 10);
    }

    public void Go(Direction direction)
    {
        //sprawdzić czy mapa nie jest nullem
        //Map.Next()
        //Zaktualizwać pozycję stwora lokalnie
        //Map.Move() zaktalizować pozycję stwora na mapie
        if (AssignedMap != null)
        {
            Point from = Position;
            Position = AssignedMap.Next(Position, direction);   //creature position update
            AssignedMap.Move(this, from, Position);     //map update
        }
    }

    /* public string[] Go(List<Direction> directions)
    {
        string[] output = new string[directions.Count];
        int i = 0;
        foreach (Direction direction in directions)
        {
            output[i] = Go(direction);
            i++;
        }
        return output;
    } */

    /* public string[] Go(string directions)
    {
        return Go(DirectionParser.Parse(directions));
    } */

    public abstract int Power { get; }

    public override string ToString()
    {
        return $"{this.GetType().Name.ToUpper()}: {this.Info}";
    }
}
