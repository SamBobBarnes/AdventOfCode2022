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

    public static int ManhattanDistance(Coordinate a, Coordinate b)
    {
        if (a.Equals(b)) return 0;
        return Math.Abs(a.X - b.X) + Math.Abs(a.Y - b.Y);
    }

    public static int ManhattanDistance(Coordinate a, int x, int y)
    {
        if (a.Equals(x,y)) return 0;
        return Math.Abs(a.X - x) + Math.Abs(a.Y - y);
    }

    public List<Coordinate> ManhattanRange(Coordinate beacon, int range)
    {
        var result = new List<Coordinate>(){this};

        for (int i = X - range; i <= X + range; i++)
        {
            for (int j = Y - range; j <= Y + range; j++)
            {
                if (Equals(i, j)) continue;
                if (beacon.Equals(i, j)) continue;
                if (ManhattanDistance(this,i,j) <= range) result.Add(new(i,j));
            }
        }
        
        return result;
    }
}
