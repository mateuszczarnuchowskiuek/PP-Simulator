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

    public abstract void SayHi();
    public abstract string Info { get; }

    public void Upgrade()
    {
        level++;
        level = Validator.Limiter(level, 0, 10);
    }

    public void Go(Direction direction)
    {
        string dir = direction.ToString();
        dir = dir[0].ToString().ToLower() + dir[1..];
        Console.WriteLine($"{this.Name} goes {dir}.");
    }

    public void Go(Direction[] directions)
    {
        foreach (Direction direction in directions)
        {
            Go(direction);
        }
    }

    public void Go(string directions)
    {
        Go(DirectionParser.Parse(directions));
    }

    public abstract int Power { get; }

    public override string ToString()
    {
        return $"{this.GetType().Name.ToUpper()}: {this.Info}";
    }
}
