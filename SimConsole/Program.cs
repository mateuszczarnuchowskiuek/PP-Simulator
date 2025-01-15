using Simulator.Maps;
using Simulator;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        /* SmallTorusMap map = new(8, 6);
        List<IMappable> mappables = [new Orc("Gorbag"), new Elf("Elandor"), new Animals { Description = "Rabbits", Size = 10 }, new Birds { Description = "Eagles" }, new Birds { Description = "Ostriches", Size = 4, CanFly = false }];
        List<Point> points = [new(0, 0), new(1, 0), new(2, 0), new(3, 0), new(4, 0)];
        string moves = "dddddurlldudrrl";

        Simulation simulation = new(map, mappables, points, moves);
        SimulationHistory simhist = new SimulationHistory(simulation);

        Console.WriteLine(simhist.TurnLogs[14].Move); */

        SmallTorusMap map = new(8, 6);
        List<IMappable> mappables = [new Orc("Gorbag"), new Elf("Elandor"), new Animals { Description = "Rabbits", Size = 10 }, new Birds { Description = "Eagles" }, new Birds { Description = "Ostriches", Size = 4, CanFly = false }];
        List<Point> points = [new(0, 0), new(1, 0), new(2, 0), new(3, 0), new(4, 0)];
        string moves = "dddddurlldudrrl";

        Simulation simulation = new(map, mappables, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        Console.WriteLine("SIMULATION!");
        Console.WriteLine("");
        Console.WriteLine("Starting positions:");
        mapVisualizer.Draw();

        while (!simulation.Finished)
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            simulation.Turn();
            Console.WriteLine("");
            Console.WriteLine($"Turn {simulation.turnIndex}");
            Console.WriteLine($"{simulation.CurrentMappable} goes {simulation.CurrentMoveName}:");
            mapVisualizer.Draw();
        }
        Console.WriteLine("");
        Console.WriteLine("Simulation has finished!");
    }
}