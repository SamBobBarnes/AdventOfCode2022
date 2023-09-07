namespace AdventOfCode2022.Day21;

public class Part2 : BasePart
{
    public static string Run()
    {
        var input = LoadInput(21, false);

        var tribe = new Tribe2(input);
        var root = tribe.Root;

        return root.GetRootValue();
    }
}