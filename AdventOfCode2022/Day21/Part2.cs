namespace AdventOfCode2022.Day21;

public class Part2 : BasePart
{
    public static Int64 Run()
    {
        var input = LoadInput(21, true);

        var tribe = new Tribe2(input);
        var root = tribe.Root;

        return root.GetValue();
    }
}