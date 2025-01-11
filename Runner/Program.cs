using Simulator.Maps;
using Simulator;

namespace Runner;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");

        Lab4a();
        Lab4b();
        Lab5a();
        Lab5b();
        //Testowa();
    }
    static void Testowa()
    {
        SmallSquareMap map = new SmallSquareMap(10, 10);
        List<Creature> c = new List<Creature>();
        c.Add(new Orc("stefan"));
        c.Add(new Orc("Bogdan"));
        c.Add(new Elf("Maksymilian"));
        List<Point> p = new List<Point>();
        p.Add(new Point(5, 5));
        p.Add(new Point(1, 0));
        p.Add(new Point(2, 0));
        Simulation sim = new Simulation(map, c, p, "uuuuuuu");
        Console.WriteLine(c[0].Position);
        Console.WriteLine(c[1].Position);
        Console.WriteLine(c[2].Position);
        sim.Turn();
        sim.Turn();
        sim.Turn();
        Console.WriteLine(c[0].Position);
        Console.WriteLine(c[1].Position);
        Console.WriteLine(c[2].Position);
        Console.WriteLine(map.At(2, 1)[0]);
    }
    static void Lab4a()
    {
        Console.WriteLine("HUNT TEST\n");
        var o = new Orc() { Name = "Gorbag", Rage = 7 };
        Console.WriteLine(o.Greeting());
        for (int i = 0; i < 10; i++)
        {
            o.Hunt();
            Console.WriteLine(o.Greeting());
        }

        Console.WriteLine("\nSING TEST\n");
        var e = new Elf("Legolas", agility: 2);
        Console.WriteLine(e.Greeting());
        for (int i = 0; i < 10; i++)
        {
            e.Sing();
            Console.WriteLine(e.Greeting());
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
    static void Lab5b()
    {
        SmallSquareMap map;
        Point p;

        //SmallSquareMap() only accepts size from 5 to 20! (Parameter 'size')
        try
        {
            map = new SmallSquareMap(2, 2);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        //SmallSquareMap() only accepts size from 5 to 20! (Parameter 'size')
        try
        {
            map = new SmallSquareMap(22, 22);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        //Simulator.Maps.SmallSquareMap
        map = new SmallSquareMap(5, 5);
        Console.WriteLine(map);

        //Simulator.Maps.SmallSquareMap
        map = new SmallSquareMap(20, 20);
        Console.WriteLine(map);

        //Simulator.Maps.SmallSquareMap
        map = new SmallSquareMap(15, 15);
        Console.WriteLine(map);

        //False
        p = new Point(-1, -1);
        Console.WriteLine(map.Exist(p));

        //True
        p = new Point(0, 0);
        Console.WriteLine(map.Exist(p));

        //True
        p = new Point(5, 5);
        Console.WriteLine(map.Exist(p));

        //True
        p = new Point(14, 14);
        Console.WriteLine(map.Exist(p));

        //False
        p = new Point(15, 15);
        Console.WriteLine(map.Exist(p));

        //(5, 6)//
        p = new Point(5, 5);
        p = map.Next(p, Direction.Up);
        Console.WriteLine(p);

        //(6, 6)//
        p = new Point(5, 5);
        p = map.NextDiagonal(p, Direction.Up);
        Console.WriteLine(p);

        //(5, 14)//
        p = new Point(5, 14);
        p = map.Next(p, Direction.Up);
        Console.WriteLine(p);

        //(14, 5)//
        p = new Point(14, 5);
        p = map.NextDiagonal(p, Direction.Up);
        Console.WriteLine(p);

        //(16, 30)
        p = new Point(16, 30);
        p = map.Next(p, Direction.Up);
        Console.WriteLine(p);

        //(16, 30)
        p = new Point(16, 30);
        p = map.NextDiagonal(p, Direction.Up);
        Console.WriteLine(p);

        //(5, 0)
        p = new Point(5, -1);
        p = map.Next(p, Direction.Up);
        Console.WriteLine(p);

        //(6, 0)
        p = new Point(5, -1);
        p = map.NextDiagonal(p, Direction.Up);
        Console.WriteLine(p);

    }
}
