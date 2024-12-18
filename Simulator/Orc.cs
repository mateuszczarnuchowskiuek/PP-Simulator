namespace Simulator;

public class Orc : Creature
{
    private int rage = 1;
    public int Rage //allowed range: [0-10]
    {
        get { return rage; }
        init
        {
            if (value < 0)
                rage = 0;
            else if (value > 10)
                rage = 10;
            else
                rage = value;
        }
    }

    private int huntCounter = 0;
    public void Hunt()
    {
        Console.WriteLine($"{Name} is hunting.");
        huntCounter++;
        if (huntCounter == 2)
        {
            rage++;
            if (rage > 10)
                rage = 10;
            huntCounter = 0;
        }
    }

    public Orc() : base() { }

    public Orc(string name = "Unknown", int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }

    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}.");

    public override int Power => 7 * Level + 3 * Rage;

}
