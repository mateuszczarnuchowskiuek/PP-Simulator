namespace Simulator;

public static class Validator
{
    public static int Limiter(int value, int min, int max)
    {
        if (value < min)
            value = min;
        else if (value > max)
            value = max;

        return value;
    }

    public static string Shortener(string value, int min, int max, char placeholder)
    {
        if (value == null || value == "")
            value = "Unknown";
        else
        {
            value = value.Trim();
            if (value.Length == 0)
                value = "Unknown";
            if (value.Length < min)
            {
                for (int i = min - value.Length; i > 0; i--)
                    value += placeholder;
            }
            if (value.Length > max)
                value = value[..max];
            value = value.Trim();

            if (value.Length == 0)
                value = "Unknown";
            if (value.Length < min)
            {
                for (int i = min - value.Length; i > 0; i--)
                    value += placeholder;
            }
            if (value.Length > max)
                value = value[..max];
            value = value.Trim();

            value = value[0].ToString().ToUpper() + value[1..];
        }
        return value;
    }
}
