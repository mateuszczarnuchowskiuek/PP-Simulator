namespace Simulator;

public class SimulationHistory
{
    private Simulation _simulation { get; }
    public int SizeX { get; }
    public int SizeY { get; }
    public List<SimulationTurnLog> TurnLogs { get; } = [];
    // store starting positions at index 0

    public SimulationHistory(Simulation simulation)
    {
        _simulation = simulation ??
            throw new ArgumentNullException(nameof(simulation));
        SizeX = _simulation.Map.SizeX;
        SizeY = _simulation.Map.SizeY;
        TurnLogs = new List<SimulationTurnLog>();
        Run();
    }

    private void Run()
    {
        int turn = 0;
        while (!_simulation.Finished)
        {
            TurnLogs.Add(new SimulationTurnLog(_simulation.CurrentMappable, _simulation.CurrentMoveName, _simulation.Map));
            _simulation.Turn();
            turn++;
        }
        TurnLogs.Add(new SimulationTurnLog(_simulation.CurrentMappable, _simulation.CurrentMoveName, _simulation.Map));
        Console.WriteLine(TurnLogs.Count());
        Console.WriteLine(_simulation.CurrentMoveName);
        Console.WriteLine(TurnLogs[TurnLogs.Count() - 1].Move);
    }
}
