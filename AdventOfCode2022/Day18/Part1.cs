namespace AdventOfCode2022.Day18;

public class Part1 : BasePart
{
    public static int Run()
    {
        var input = LoadInput(18, false);

        var map = new Map(input);

        var openSides = map.GetOpenSides();
        
        return openSides;
    }
}