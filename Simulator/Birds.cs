using System.Diagnostics.Contracts;

namespace Simulator;

public class Birds : Animals
{
    public bool CanFly = true;

    public override string Info
    {
        get { return $"{Description} ({(CanFly ? "fly+" : "fly-")}) <{Size}>"; }
    }
}
