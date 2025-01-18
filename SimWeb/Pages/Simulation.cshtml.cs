using System.Runtime.Serialization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using Simulator.Maps;

namespace SimWeb.Pages;

public class PrivacyModel : PageModel
{

    public SimulationHistory simhistory;
    public int width = 10;
    public int height = 5;
    public int Turn = 0;
    public string Orc = "Assets/orc.jpg";
    public string Elf = "Assets/elf.jpg";
    public string Bird = "Assets/bird.jpg";
    public int CurrentTurn { get; private set; }

    public void OnGet()
    {
        SmallTorusMap map = new(8, 6);
        List<IMappable> mappables = [new Orc("Gorbag"), new Elf("Elandor"), new Animals { Description = "Rabbits", Size = 10 }, new Birds { Description = "Eagles" }, new Birds { Description = "Ostriches", Size = 4, CanFly = false }];
        List<Point> points = [new(0, 0), new(1, 0), new(2, 0), new(3, 0), new(4, 0)];
        string moves = "dddddurlldudrrl";

        Simulation simulation = new Simulation(map, mappables, points, moves);
        SimulationHistory FinalHistory = new SimulationHistory(simulation);

        Turn = HttpContext.Session.GetInt32("Turn") ?? 0;
        Point p = new Point(0, 0);
        Console.WriteLine(FinalHistory.TurnLogs[0].Symbols.Count);
    }
    public void OnPrevious()
    {
        Turn--;
    }
    public void Next()
    {
        Console.WriteLine("amd");
        Turn++;
    }
}

