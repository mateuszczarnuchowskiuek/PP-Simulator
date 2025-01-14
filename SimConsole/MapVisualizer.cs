using System.Text;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class MapVisualizer
{
    private Map Map;
    public MapVisualizer(Map map)
    {
        Map = map;
    }

    public void Draw()
    {
        Console.OutputEncoding = Encoding.UTF8;
        string line = "";

        //Top border
        line += Box.TopLeft;
        for (int i = 0; i < Map.SizeX - 1; i++)
        {
            line += Box.Horizontal;
            line += Box.TopMid;
        }
        line += Box.Horizontal;
        line += Box.TopRight;
        Console.WriteLine(line);

        //Main contents
        for (int i = Map.SizeY - 1; i >= 0; i--)
        {
            line = "";
            line += Box.Vertical;
            for (int j = 0; j < Map.SizeX; j++)
            {
                if (Map.At(j, i).Count == 0)
                    line += "#";
                else if (Map.At(j, i).Count == 1)
                {
                    line += Map.At(j, i)[0].Symbol;
                    /* if (Map.At(j, i)[0].GetType() == typeof(Orc))
                        line += "O";
                    else if (Map.At(j, i)[0].GetType() == typeof(Elf))
                        line += "E"; */
                }
                else
                {
                    line += "X";
                }
                line += Box.Vertical;
            }
            Console.WriteLine(line);

            if (i > 0)
            {
                line = "";
                line += Box.MidLeft;
                for (int xd = 0; xd < Map.SizeX - 1; xd++)
                {
                    line += Box.Horizontal;
                    line += Box.Cross;
                }
                line += Box.Horizontal;
                line += Box.MidRight;
                Console.WriteLine(line);
            }
        }

        //Bottom border
        line = "";
        line += Box.BottomLeft;
        for (int i = 0; i < Map.SizeX - 1; i++)
        {
            line += Box.Horizontal;
            line += Box.BottomMid;
        }
        line += Box.Horizontal;
        line += Box.BottomRight;
        Console.WriteLine(line);
    }
}
