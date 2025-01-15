using Simulator;
using Simulator.Maps;

namespace SimConsole;

internal class LogVisulizer
{
    SimulationHistory Log { get; }
    public LogVisulizer(SimulationHistory log)
    {
        Log = log;
    }

    public void Draw(int turnIndex)
    {
        Console.WriteLine(Log);
    }
}