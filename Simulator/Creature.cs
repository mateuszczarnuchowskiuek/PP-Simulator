namespace Simulator;

public abstract class Creature
{
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

    public Creature(string Name, int Level = 1)
    {
        this.Name = Name;
        this.Level = Level;
    }
    public Creature()
    {
        //empty constructor
    }

    public abstract string Greeting();
    public abstract string Info { get; }

    public void Upgrade()
    {
        level++;
        level = Validator.Limiter(level, 0, 10);
    }

    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";

    public string[] Go(Direction[] directions)
    {
        string[] output = new string[directions.Length];
        int i = 0;
        foreach (Direction direction in directions)
        {
            output[i] = Go(direction);
            i++;
        }
        return output;
    }

    public string[] Go(string directions)
    {
        return Go(DirectionParser.Parse(directions));
    }

    public abstract int Power { get; }

    public override string ToString()
    {
        return $"{this.GetType().Name.ToUpper()}: {this.Info}";
    }
}
