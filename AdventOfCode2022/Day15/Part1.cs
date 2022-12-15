namespace AdventOfCode2022.Day15;

public class Part1 : BasePart
{
    public static int Run()
    {
        Start(15,1);
        var input = LoadInput(15);
        var sensors = input.Select(i => new Sensor(i));
        var grid = new Grid(sensors);
        
        //Console.WriteLine(grid.ToString());

        return grid.GetImpossibilities(2000000);
    }
}