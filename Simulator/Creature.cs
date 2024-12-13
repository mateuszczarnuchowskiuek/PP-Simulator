namespace Simulator;

public class Creature
{
    private string name = "Unknown";
    public string Name
    {
        get { return name; }
        init
        {
            if (value == null)
                name = "Unknown";
            else
            {
                name = value.Trim();
                if (name.Length == 0)
                    name = "Unknown";
                if (name.Length == 1)
                    name += "##";
                else if (name.Length == 2)
                    name += "#";
                else if (name.Length > 25)
                    name = name[..25];
                name = name.Trim();

                if (name.Length == 0)
                    name = "Unknown";
                if (name.Length == 1)
                    name += "##";
                else if (name.Length == 2)
                    name += "#";

                name = name[0].ToString().ToUpper() + name[1..];
            }
        }
    }
    private int level = 1;
    public int Level
    {
        get { return level; }
        init
        {
            if (value < 1)
                level = 1;
            else if (value > 10)
                level = 10;
            else
                level = value;
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

    public void SayHi()
    {
        Console.WriteLine($"Hi, I'm {this.Name}, my level is {this.Level}.");
    }
    public string Info
    {
        get { return $"{this.Name} [{this.Level}]"; }
    }

    public void Upgrade()
    {
        level += 1;
        if (level > 10)
            level = 10;
    }

}
