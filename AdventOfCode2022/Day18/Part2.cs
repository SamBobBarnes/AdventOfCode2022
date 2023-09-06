namespace AdventOfCode2022.Day18;

public class Part2 : BasePart
{
    public static int Run()
    {
        var input = LoadInput(18, false);
        
        var map = new Map(input);

        var openSides = map.GetOpenToAirSides();
        
        return openSides;
    }
}