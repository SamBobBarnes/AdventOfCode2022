namespace AdventOfCode2022.Day18;

public class Map
{
    private readonly bool[,,] _grid;
    private readonly List<Cube> _cubes;
    private readonly int _length;
    public Map(List<string> input)
    {
        _cubes = new List<Cube>();
        foreach (var cube in input)
        {
            var xyz = cube.Split(",");
            var x = int.Parse(xyz[0]);
            var y = int.Parse(xyz[1]);
            var z = int.Parse(xyz[2]);
            
            _cubes.Add(new Cube(x,y,z));

            if (x > _length) _length = x;
            if (y > _length) _length = y;
            if (z > _length) _length = z;
        }

        _length++;
        _grid = new bool[_length, _length, _length];
        
        foreach (var cube in _cubes)
        {
            _grid[cube.X, cube.Y, cube.Z] = true;
        }
    }
    
    public bool[,,] Grid => _grid;
    public List<Cube> Cubes => _cubes;

    public int GetOpenSides()
    {
        var sides = 0;
        foreach (var cube in _cubes)
        {
            if (cube.X+1 == _length || !_grid[cube.X+1, cube.Y, cube.Z]) sides++;
            if (cube.X-1 == -1 || !_grid[cube.X-1, cube.Y, cube.Z]) sides++;
            if (cube.Y+1 == _length || !_grid[cube.X, cube.Y+1, cube.Z]) sides++;
            if (cube.Y-1 == -1 || !_grid[cube.X, cube.Y-1, cube.Z]) sides++;
            if (cube.Z+1 == _length || !_grid[cube.X, cube.Y, cube.Z+1]) sides++;
            if (cube.Z-1 == -1 || !_grid[cube.X, cube.Y, cube.Z-1]) sides++;
        }

        return sides;
    }
}

public class Cube : Tuple<int, int, int>
{
    public Cube(int t1, int t2, int t3) : base(t1, t2, t3) { }

    public int X => Item1;
    public int Y => Item2;
    public int Z => Item3;
}