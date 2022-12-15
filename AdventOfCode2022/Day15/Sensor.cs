namespace AdventOfCode2022.Day15;

public class Sensor
{
    public Sensor(string input)
    {
        var inputArray = input.Split(" ");
        var pX = inputArray[2].Substring(0,inputArray[2].Length - 1).Substring(2);
        var pY = inputArray[3].Substring(0,inputArray[3].Length - 1).Substring(2);
        var bX = inputArray[8].Substring(0,inputArray[8].Length - 1).Substring(2);
        var bY = inputArray[9].Substring(2);

        _position = new Coordinate(int.Parse(pX), int.Parse(pY));
        Beacon = new Coordinate(int.Parse(bX), int.Parse(bY));
        MinimumRadius = _position.ManhattanDistance(Beacon);
    }

    private readonly Coordinate _position;
    public int X => _position.X;
    public int Y => _position.Y;
    public readonly Coordinate Beacon;
    public readonly int MinimumRadius;

    public int ManhattanDistance()
    {
        return _position.ManhattanDistance(Beacon);
    }

    public int ManhattanDistance(int x, int y)
    {
        return _position.ManhattanDistance(x, y);
    }

    public bool WithinRange(Coordinate b)
    {
        return _position.WithinRange(b.X, b.Y, MinimumRadius);
    }

    public List<Coordinate> ManhattanBorder()
    {
        return _position.ManhattanBorder(MinimumRadius);
    }
}