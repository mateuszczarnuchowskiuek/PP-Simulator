using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Simulator;

public class Animals
{
    private string description = "Unknown";
    public required string Description
    {
        get { return description; }
        init
        {
            if (value == null)
                description = "Unknown";
            else
            {
                description = value.Trim();
                if (description.Length == 0)
                    description = "Unknown";
                if (description.Length == 1)
                    description += "##";
                else if (description.Length == 2)
                    description += "#";
                else if (description.Length > 15)
                    description = description[..15];
                description = description.Trim();

                if (description.Length == 0)
                    description = "Unknown";
                if (description.Length == 1)
                    description += "##";
                else if (description.Length == 2)
                    description += "#";

                description = description[0].ToString().ToUpper() + description[1..];
            }
        }
    }
    public uint Size { get; set; } = 3;
    public string Info
    {
        get { return $"{Description} <{Size}>"; }
    }

}
