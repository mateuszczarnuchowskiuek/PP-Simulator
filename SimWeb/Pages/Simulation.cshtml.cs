using System.Reflection.Metadata;
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
    public Simulation simulation;
    public int width;
    public int height;
    public int simlength;
    public int Turn = 0;
    public string Orc = "Assets/orc.jpg";
    public string Elf = "Assets/elf.jpg";
    public string Bird = "Assets/bird.jpg";
    public string Background = "Assets/background.jpg";
    public int CurrentTurn { get; private set; }
    public Dictionary<Point, char> positions;
    public int Previous => Turn - 1;
    public int Next => Turn + 1;


    public void OnGet()
    {
        PrepareSimulation();
    }
    public void PrepareSimulation()
    {
        Turn = HttpContext.Session.GetInt32("Turn") ?? 0;
        SmallTorusMap map = new(8, 5);
        List<IMappable> mappables = [new Orc("Gorbag")];
        List<Point> points = [new Point(5, 2)];
        string moves = "dddddd";

        simulation = new Simulation(map, mappables, points, moves);
        simhistory = new SimulationHistory(simulation);

        simlength = simulation.Moves.Length;
        positions = simhistory.TurnLogs[Turn].Symbols;
        width = simhistory.SizeX;
        height = simhistory.SizeY;


        //Console.WriteLine(simhistory.TurnLogs[0].Symbols[new Point(0, 0)]);
    }
    public IActionResult OnPostNext()
    {
        Turn = HttpContext.Session.GetInt32("Turn") ?? 0;
        Turn++;
        HttpContext.Session.SetInt32("Turn", Turn);
        PrepareSimulation();
        return Page();
    }
    public IActionResult OnPostPrevious()
    {
        Turn = HttpContext.Session.GetInt32("Turn") ?? 0;
        Turn--;
        HttpContext.Session.SetInt32("Turn", Turn);
        PrepareSimulation();
        return Page();
    }
}

