namespace AdventOfCode2022.Day21;

public class Part1 : BasePart
{
    public static Int64 Run()
    {
        var input = LoadInput(21, false);

        var tribe = new Tribe(input);
        var root = tribe.Root;
        
        return root.GetValue();
    }
}