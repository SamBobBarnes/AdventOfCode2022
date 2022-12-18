namespace AdventOfCode2022.Day17;

public class Part1 : BasePart
{
    public static int Run()
    {
        Start(17,1);
        var exampleInput = LoadInputChars(17, true);
        var grid = new Grid(exampleInput);
        grid.DropRock();
        Console.WriteLine(grid.ToString());
        
        
        
        
        
        var input = LoadInput(17, false);
        
        
        
        return 0;
    }
}