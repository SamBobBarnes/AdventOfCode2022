namespace AdventOfCode2022.Day15;

public class Coordinate : IEquatable<Coordinate>
{
    public Coordinate(int x, int y)
    {
        X = x;
        Y = y;
    }
    public int X { get; set; }
    public int Y { get; set; }

    public new string ToString()
    {
        return $"{X},{Y}";
    }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Coordinate);
    }
    
    public bool Equals(Coordinate? x)
    {
        if (x == null) return false;
        return X == x.X && Y == x.Y;
    }

    public bool Equals(int x, int y)
    {
        return X == x && Y == y;
    }

    public int ManhattanDistance(Coordinate b)
    {
        if (Equals(b)) return 0;
        return Math.Abs(X - b.X) + Math.Abs(Y - b.Y);
    }

    public int ManhattanDistance(int x, int y)
    {
        if (Equals(x,y)) return 0;
        return Math.Abs(X - x) + Math.Abs(Y - y);
    }

    public bool WithinRange(int x, int y, int range)
    {
        return ManhattanDistance(x, y) <= range;
    }

    public List<Coordinate> ManhattanBorder(int range)
    {
        var result = new List<Coordinate>();

        for (int i = 0; i <= range + 1; i++)
        {
            var x = X + i;
            var y = Y + range + 1 - i;
            result.Add(new Coordinate(x,y));
            if (i != 0 && range + 1 -i != 0) result.Add(new Coordinate(-x,y));
            if (i != 0 && range + 1 -i != 0) result.Add(new Coordinate(x,-y));
            result.Add(new Coordinate(-x,-y));
        }
        
        return result;
    }
}
