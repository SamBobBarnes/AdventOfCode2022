namespace AdventOfCode2022.Day17;

public class Part1 : BasePart
{
    public static int Run()
    {
        Start(17,1);
        var rocksToDrop = 2022;

        var exampleInput = LoadInputChars(17, true);
        var exampleGrid = new Grid(exampleInput);
        
        for (int i = 0; i < rocksToDrop; i++)
        {
            exampleGrid.DropRock();
        }
        Console.WriteLine(exampleGrid.TowerHeight);
        
        
        
        
        
        var input = LoadInputChars(17, false);
        var grid = new Grid(input);
        for (int i = 0; i < rocksToDrop; i++)
        {
            grid.DropRock();
        }


        return grid.TowerHeight;
    }
}