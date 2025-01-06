namespace Simulator;

public class Elf : Creature
{
    private int agility = 1;
    public int Agility  //allowed range [0-10]
    {
        get { return agility; }
        init
        {
            agility = Validator.Limiter(value, 0, 10);
        }
    }

    private int singCounter = 0;
    public void Sing()
    {
        singCounter++;
        if (singCounter == 3)
        {
            agility++;
            agility = Validator.Limiter(agility, 0, 10);
            singCounter = 0;
        }
    }

    public Elf() : base() { }

    public Elf(string name = "Unknown", int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public override string Greeting() => $"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.";

    public override int Power => 8 * Level + 2 * Agility;

    public override string Info
    {
        get { return $"{this.Name} [{this.Level}][{this.Agility}]"; }
    }
}
