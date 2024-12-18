namespace Simulator;

public class Elf : Creature
{
    private int agility = 1;
    public int Agility  //allowed range [0-10]
    {
        get { return agility; }
        init
        {
            if (value < 0)
                agility = 0;
            else if (value > 10)
                agility = 10;
            else
                agility = value;
        }
    }

    private int singCounter = 0;
    public void Sing()
    {
        Console.WriteLine($"{Name} is singing.");
        singCounter++;
        if (singCounter == 3)
        {
            agility++;
            if (agility > 10)
                agility = 10;
            singCounter = 0;
        }
    }

    public Elf() : base() { }

    public Elf(string name = "Unknown", int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }

    public override void SayHi() => Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}.");

    public override int Power => 8 * Level + 2 * Agility;
}
