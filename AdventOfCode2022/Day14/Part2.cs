namespace AdventOfCode2022.Day14;

public class Part2 : BasePart
{
    public static int Run()
    {
        Start(14, 2);
        var input = LoadInput(14);
        var coordinateList = input.Select(x => x.Split(" -> "));
        var width = 0;
        var height = 0;
        var map = coordinateList.Select(i => i.Select(j =>
        {
            var coords = j.Split(",");
            if (int.Parse(coords[0]) > width) width = int.Parse(coords[0]);
            if (int.Parse(coords[1]) > height) height = int.Parse(coords[1]);
            return new Coordinate(int.Parse(coords[0]), int.Parse(coords[1]));
        }).ToList()).ToList();

        Console.WriteLine("Drawing grid...");
        var grid = new Grid2(map,width,height);
        Console.WriteLine("Simulating...");
        var count = grid.SimulateSand();
        Console.WriteLine(grid.ToString(480,0));

        return count;
    }

}
