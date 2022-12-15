namespace AdventOfCode2022.Day15;

public class Part1 : BasePart
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
        
        var exampleOutput = exampleGrid.GetImpossibilities(10);
        Console.WriteLine(exampleOutput);
        var output = grid.GetImpossibilities(2000000);
        //Console.WriteLine(output);
        return output;
    }
}