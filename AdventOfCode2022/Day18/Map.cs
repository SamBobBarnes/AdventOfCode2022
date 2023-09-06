namespace AdventOfCode2022.Day18;

public class Map
{
    private readonly int[,,] _grid;
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
        _grid = new int[_length, _length, _length];
        
        foreach (var cube in _cubes)
        {
            _grid[cube.X, cube.Y, cube.Z] = 1;
        }
        
        MarkOpenAir();
    }
    
    public int[,,] Grid => _grid;
    public List<Cube> Cubes => _cubes;

    private void MarkOpenAir()
    {
        var sideCubes = new List<Cube>();
        for (int i = 0; i < _length; i++)
        {
            sideCubes.Add(new Cube(i,0,0));
            sideCubes.Add(new Cube(i,_length-1,0));
            sideCubes.Add(new Cube(i,0,_length-1));
            sideCubes.Add(new Cube(i,_length-1,_length-1));
            sideCubes.Add(new Cube(0,i,0));
            sideCubes.Add(new Cube(_length-1,i,0));
            sideCubes.Add(new Cube(0,i,_length-1));
            sideCubes.Add(new Cube(_length-1,i,_length-1));
            sideCubes.Add(new Cube(0,0,i));
            sideCubes.Add(new Cube(_length-1,0,i));
            sideCubes.Add(new Cube(0,_length-1,i));
            sideCubes.Add(new Cube(_length-1,_length-1,i));
        }

        foreach (var cube in sideCubes)
        {
            Mark(cube.X, cube.Y, cube.Z);
        }
    }

    private void Mark(int x, int y, int z)
    {
        if(_grid[x, y, z] == 1) return;
        
        _grid[x, y, z] = 2;
        //left
        if(x-1 >= 0 && _grid[x-1, y, z] == 0) Mark(x-1, y, z);
        //right
        if(x+1 < _length && _grid[x+1, y, z] == 0) Mark(x+1, y, z);
        //up
        if(y-1 >= 0 && _grid[x, y-1, z] == 0) Mark(x, y-1, z);
        //down
        if(y+1 < _length && _grid[x, y+1, z] == 0) Mark(x, y+1, z);
        //forward
        if(z-1 >= 0 && _grid[x, y, z-1] == 0) Mark(x, y, z-1);
        //back
        if(z+1 < _length && _grid[x, y, z+1] == 0) Mark(x, y, z+1);
    }
    
    public int GetOpenSides()
    {
        var sides = 0;
        foreach (var cube in _cubes)
        {
            if (cube.X+1 == _length || _grid[cube.X+1, cube.Y, cube.Z] != 1) sides++;
            if (cube.X-1 == -1 || _grid[cube.X-1, cube.Y, cube.Z] != 1) sides++;
            if (cube.Y+1 == _length || _grid[cube.X, cube.Y+1, cube.Z] != 1) sides++;
            if (cube.Y-1 == -1 || _grid[cube.X, cube.Y-1, cube.Z] != 1) sides++;
            if (cube.Z+1 == _length || _grid[cube.X, cube.Y, cube.Z+1] != 1) sides++;
            if (cube.Z-1 == -1 || _grid[cube.X, cube.Y, cube.Z-1] != 1) sides++;
        }

        return sides;
    }

    public int GetOpenToAirSides()
    {
        var sides = 0;
        foreach (var cube in _cubes)
        {
            if (cube.X+1 == _length || _grid[cube.X+1, cube.Y, cube.Z] == 2) sides++;
            if (cube.X-1 == -1 || _grid[cube.X-1, cube.Y, cube.Z] == 2) sides++;
            if (cube.Y+1 == _length || _grid[cube.X, cube.Y+1, cube.Z] == 2) sides++;
            if (cube.Y-1 == -1 || _grid[cube.X, cube.Y-1, cube.Z] == 2) sides++;
            if (cube.Z+1 == _length || _grid[cube.X, cube.Y, cube.Z+1] == 2) sides++;
            if (cube.Z-1 == -1 || _grid[cube.X, cube.Y, cube.Z-1] == 2) sides++;
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