using System.Collections.Generic;

namespace Simulator;

public static class DirectionParser
{
    public static List<Direction> Parse(string dirs)
    {
        //int counter = 0;
        List<Direction> directions = new();
        foreach (char character in dirs)
        {
            char letter = Char.ToUpper(character);
            if (letter == 'U')
            {
                //counter++;
                directions.Add(Direction.Up);
            }
            if (letter == 'D')
            {
                //counter++;
                directions.Add(Direction.Down);
            }
            if (letter == 'L')
            {
                //counter++;
                directions.Add(Direction.Left);
            }
            if (letter == 'R')
            {
                //counter++;
                directions.Add(Direction.Right);
            }
        }
        /* Direction[] directions = new Direction[counter];
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
        }*/
        return directions;
    }
}
