namespace AdventOfCode2022.Day18;

public class Map
{
    private readonly bool[,,] _grid;
    public Map(List<string> input)
    {
        var maxLength = 0;
        foreach (var cube in input)
        {
            var xyz = cube.Split(",");
            var x = int.Parse(xyz[0]);
            var y = int.Parse(xyz[1]);
            var z = int.Parse(xyz[2]);

            if (x > maxLength) maxLength = x;
            if (y > maxLength) maxLength = y;
            if (z > maxLength) maxLength = z;
        }

        maxLength++;
        _grid = new bool[maxLength, maxLength, maxLength];
        
        foreach (var cube in input)
        {
            var xyz = cube.Split(",");
            var x = int.Parse(xyz[0]);
            var y = int.Parse(xyz[1]);
            var z = int.Parse(xyz[2]);

            _grid[x, y, z] = true;
        }
    }
    
    public bool[,,] Grid => _grid;
}