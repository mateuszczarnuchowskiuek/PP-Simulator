namespace Simulator;

public class Creature
{
    public string? Name { get; set; }
    public int Level { get; set; }

    public Creature(string name, int level = 1)
    {
        this.Name = name;
        this.Level = level;
    }
    public Creature()
    {
        //empty constructor
    }

    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {this.Name}, my level is {this.Level}.");
    }
    public string Info
    {
        get { return $"{this.Name} [{this.Level}]"; }
    }

}
