namespace Simulator;

public static class DirectionParser
{
    public static Direction[] Parse(string dirs)
    {
        int counter = 0;
        foreach (char character in dirs)
        {
            char letter = Char.ToUpper(character);
            if (letter == 'U')
                counter++;
            if (letter == 'D')
                counter++;
            if (letter == 'L')
                counter++;
            if (letter == 'R')
                counter++;
        }
        Direction[] directions = new Direction[counter];
        counter = 0;
        foreach (char character in dirs)
        {
            char letter = Char.ToUpper(character);
            if (letter == 'U')
            {
                directions[counter] = Direction.Up;
                counter++;
            }
            if (letter == 'D')
            {
                directions[counter] = Direction.Down;
                counter++;
            }
            if (letter == 'L')
            {
                directions[counter] = Direction.Left;
                counter++;
            }
            if (letter == 'R')
            {
                directions[counter] = Direction.Right;
                counter++;
            }
        }
        return directions;
    }
}
