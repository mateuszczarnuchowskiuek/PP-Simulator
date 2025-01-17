namespace Simulator;

public class Orc : Creature
{
    public override string Symbol
    {
        get => "O";
    }
    private int rage = 1;
    public int Rage //allowed range: [0-10]
    {
        get { return rage; }
        init
        {
            rage = Validator.Limiter(value, 0, 10);
        }
    }

    private int huntCounter = 0;
    public void Hunt()
    {
        huntCounter++;
        if (huntCounter == 2)
        {
            rage++;
            rage = Validator.Limiter(rage, 0, 10);
            huntCounter = 0;
        }
    }

    public Orc() : base() { }

    public Orc(string name = "Unknown", int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }

    public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.";

    public override int Power => 7 * Level + 3 * Rage;

    public override string Info
    {
        get { return $"{this.Name} [{this.Level}][{this.Rage}]"; }
    }

}
