using System.Diagnostics;

namespace AdventOfCode2022.Day17;

public class Part2 : BasePart
{
    public static ulong Run()
    {
        Start(17,2);
        var stopwatch = new Stopwatch();
        var rocksToDrop = 1000000000000;
        stopwatch.Start();
        var exampleInput = LoadInputChars(17, true);
        var exampleGrid = new Grid(exampleInput);
        
        for (int i = 0; i < rocksToDrop; i++)
        {
            exampleGrid.DropRock();
        }
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed.TotalSeconds + "s");
        Console.WriteLine(exampleGrid.TowerHeight);
        
        stopwatch.Restart();
        var input = LoadInputChars(17, false);
        var grid = new Grid(input);
        for (int i = 0; i < rocksToDrop; i++)
        {
            grid.DropRock();
        }
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed.TotalSeconds + "s");


        return grid.TowerHeight;
    }
}