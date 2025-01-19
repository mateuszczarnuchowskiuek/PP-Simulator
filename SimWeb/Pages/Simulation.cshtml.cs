﻿using System.Reflection.Metadata;
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
        Turn = HttpContext.Session.GetInt32("Turn") ?? 0;
        simlength = HttpContext.Session.GetInt32("simlength") ?? 0;
        PrepareSimulation();
        HttpContext.Session.SetInt32("Turn", Turn);
        HttpContext.Session.SetInt32("simlength", simlength);
    }
    public void PrepareSimulation()
    {
        SmallTorusMap map = new(8, 5);
        List<IMappable> mappables = [new Orc("Gorbag")];
        List<Point> points = [new Point(5, 2)];
        string moves = "dddddd";

        simulation = new Simulation(map, mappables, points, moves);
        simhistory = new SimulationHistory(simulation);

        simlength = DirectionParser.Parse(moves).Count;
        positions = simhistory.TurnLogs[Turn].Symbols;
        width = simhistory.SizeX;
        height = simhistory.SizeY;


        //Console.WriteLine(simhistory.TurnLogs[0].Symbols[new Point(0, 0)]);
    }
    public IActionResult OnPostNext()
    {
        Turn = HttpContext.Session.GetInt32("Turn") ?? 0;
        simlength = HttpContext.Session.GetInt32("simlength") ?? 0;
        Turn++;
        if (Turn >= simlength)
            Turn--;
        HttpContext.Session.SetInt32("Turn", Turn);
        HttpContext.Session.SetInt32("simlength", simlength);
        PrepareSimulation();
        return Page();
    }
    public IActionResult OnPostPrevious()
    {
        Turn = HttpContext.Session.GetInt32("Turn") ?? 0;
        simlength = HttpContext.Session.GetInt32("simlength") ?? 0;
        Turn--;
        if (Turn < 0)
            Turn++;
        HttpContext.Session.SetInt32("Turn", Turn);
        HttpContext.Session.SetInt32("simlength", simlength);
        PrepareSimulation();
        return Page();
    }
}
