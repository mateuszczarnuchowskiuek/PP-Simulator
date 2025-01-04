namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        Lab4a();
        Lab4b();
        Lab5a();
    }

    static void Lab4a()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        o.SayHi();
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            o.SayHi();
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        e.SayHi();
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            e.SayHi();
        }

        Console.WriteLine("\nPOWER TEST\n");
        Creature[] creatures = {
        o,
        e,
        new Orc("Morgash", 3, 8),
        new Elf("Elandor", 5, 3)
    };
        foreach (Creature creature in creatures)
        {
            Console.WriteLine($"{creature.Name,-15}: {creature.Power}");
        }
    }
    static void Lab4b()
    {
        object[] myObjects = {
        new Animals() { Description = "dogs"},
        new Birds { Description = "  eagles ", Size = 10 },
        new Elf("e", 15, -3),
        new Orc("morgash", 6, 4)
    };
        Console.WriteLine("\nMy objects:");
        foreach (var o in myObjects) Console.WriteLine(o);
        /*
            My objects:
            ANIMALS: Dogs <3>
            BIRDS: Eagles (fly+) <10>
            ELF: E## [10][0]
            ORC: Morgash [6][4]
        */
    }
    static void Lab5a()
    {
        //(0, 0):(10, 10)
        Point p1 = new Point(0, 0);
        Point p2 = new Point(10, 10);
        Point p3;
        Rectangle rec = new Rectangle(p1, p2);
        Console.WriteLine(rec);

        //(2, 3):(4, 5)
        rec = new Rectangle(2, 3, 4, 5);
        Console.WriteLine(rec);

        //(5, 3):(7, 8)
        rec = new Rectangle(7, 8, 5, 3);
        Console.WriteLine(rec);

        //(-130, -260): (54, 543)
        p1 = new Point(-130, -260);
        p2 = new Point(54, 543);
        rec = new Rectangle(p1, p2);
        Console.WriteLine(rec);

        //(3, 2): (7, 5)
        p1 = new Point(7, 2);
        p2 = new Point(3, 5);
        rec = new Rectangle(p1, p2);
        Console.WriteLine(rec);

        //(2, 2): (7, 6)
        p1 = new Point(2, 6);
        p2 = new Point(7, 2);
        rec = new Rectangle(p1, p2);
        Console.WriteLine(rec);

        //(2, 2): (7, 7)
        p1 = new Point(7, 7);
        p2 = new Point(2, 2);
        rec = new Rectangle(p1, p2);
        Console.WriteLine(rec);

        //(1, 1): (7, 8)
        p1 = new Point(7, 7).Next(Direction.Up);
        p2 = new Point(2, 2).NextDiagonal(Direction.Down);
        rec = new Rectangle(p1, p2);
        Console.WriteLine(rec);

        //We don't want "thin" rectangles
        p1 = new Point(2, 2);
        p2 = new Point(2, 5);
        try
        {
            rec = new Rectangle(p1, p2);
            Console.WriteLine(rec);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        //We don't want "thin" rectangles
        p1 = new Point(2, 5);
        p2 = new Point(5, 5);
        try
        {
            rec = new Rectangle(p1, p2);
            Console.WriteLine(rec);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        //We don't want "thin" rectangles
        p1 = new Point(0, 0);
        p2 = new Point(0, 0);
        try
        {
            rec = new Rectangle(p1, p2);
            Console.WriteLine(rec);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        //We don't want "thin" rectangles
        p1 = new Point(2, 2);
        p2 = new Point(5, 5);
        try
        {
            rec = new Rectangle(p1, p1);
            Console.WriteLine(rec);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        //(2, 2):(5, 5)
        p1 = new Point(2, 2);
        p2 = new Point(5, 5);
        rec = new Rectangle(p1, p2);
        Console.WriteLine(rec);

        //False
        p3 = new Point(1, 1);
        Console.WriteLine(rec.Contains(p3));

        //False
        p3 = new Point(6, 6);
        Console.WriteLine(rec.Contains(p3));

        //True
        p3 = new Point(3, 3);
        Console.WriteLine(rec.Contains(p3));

        //True
        p3 = new Point(2, 2);
        Console.WriteLine(rec.Contains(p3));

        //True
        p3 = new Point(5, 5);
        Console.WriteLine(rec.Contains(p3));

        //True
        p3 = new Point(4, 2);
        Console.WriteLine(rec.Contains(p3));

        //False
        p3 = new Point(2, 1);
        Console.WriteLine(rec.Contains(p3));

        //False
        p3 = new Point(8, 7);
        Console.WriteLine(rec.Contains(p3));

        //False
        p3 = new Point(-50, 4);
        Console.WriteLine(rec.Contains(p3));
    }
}
