using Simulator.Maps;
using Simulator;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        SmallSquareMap map = new(5);
        List<IMappable> mappables = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludl";

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