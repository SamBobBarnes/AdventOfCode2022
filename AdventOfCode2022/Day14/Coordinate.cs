namespace AdventOfCode2022.Day14;

public class Coordinate
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

    public static bool Between(Coordinate a, Coordinate b, Coordinate c)
    {
        if (a.X != b.X && a.Y != b.Y) throw new InvalidOperationException("A and B must have a common axis.");
        var axis = a.X == b.X ? 'X' : 'Y';
        if (axis == 'X')
        {
            if (a.Y == b.Y && c.Y == a.Y && c.X == a.X) return true;
            var aY = a.Y < b.Y ? a.Y : b.Y;
            var bY = a.Y < b.Y ? b.Y : a.Y;
            if (c.Y >= aY && c.Y <= bY && c.X == a.X) return true;
        }
        else
        {
            if (a.X == b.X && c.X == a.X && c.Y == a.Y) return true;
            var aX = a.X < b.X ? a.X : b.X;
            var bX = a.X < b.X ? b.X : a.X;
            if (c.X >= aX && c.X <= bX && c.Y == a.Y) return true;
        }
        return false;
    }
}
