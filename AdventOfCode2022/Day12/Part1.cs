namespace AdventOfCode2022.Day12;

public class Part1 : BasePart
{
    public static int Run()
    {
        Start(12,1);
        var input = LoadInput(12);
        var grid = new Grid(input.Select(x => x.ToCharArray().ToList()).ToList());

        return grid.FindPathLength();
    }
}