namespace AdventOfCode2022.Day15;

public class Part2 : BasePart
{
    public static int Run()
    {
        Start(15,2);
        var exampleInput = LoadInput(15, true);
        var input = LoadInput(15);
        var exampleSensors = exampleInput.Select(i => new Sensor(i));
        var sensors = input.Select(i => new Sensor(i));
        var exampleGrid = new Grid(exampleSensors);
        var grid = new Grid(sensors);
        
        //Console.WriteLine(grid.ToString());
        Console.WriteLine(exampleGrid.GetImpossibilities(10));
        return grid.GetImpossibilities(2000000);
    }
}