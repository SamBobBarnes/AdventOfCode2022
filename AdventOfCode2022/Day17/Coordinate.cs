namespace AdventOfCode2022.Day17;

public class Coordinate : IEquatable<Coordinate>
{
    public Coordinate(int x, int y)
    {
        X = x;
        Y = Convert.ToUInt64(y);
    }

    public Coordinate(int x, ulong y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public UInt64 Y { get; set; }

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

    public bool Equals(int x, ulong y)
    {
        return X == x && Y == y;
    }
}
