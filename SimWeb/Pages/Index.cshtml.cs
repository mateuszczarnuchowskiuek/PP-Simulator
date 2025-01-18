using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using Simulator.Maps;

namespace SimWeb.Pages;

public class IndexModel : PageModel
{
    public int Counter { get; private set; }
    public string MapType = "torus";
    public string MoveSequence = "dlrludluddlrulr";
    public void OnGet()
    {
        Counter = HttpContext.Session.GetInt32("Counter") ?? 1;
    }
    public void OnPost()
    {
        Counter = HttpContext.Session.GetInt32("Counter") ?? 1;
        Counter++;
        HttpContext.Session.SetInt32("Counter", Counter);
    }
}
