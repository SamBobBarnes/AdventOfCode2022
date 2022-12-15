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

        Position = new Coordinate(int.Parse(pX), int.Parse(pY));
        Beacon = new Coordinate(int.Parse(bX), int.Parse(bY));
        MinimumRadius = Position.ManhattanDistance(Beacon);
    }

    private Coordinate Position;
    public int X => Position.X;
    public int Y => Position.Y;
    public Coordinate Beacon;
    public int MinimumRadius;

    public int ManhattanDistance()
    {
        return Position.ManhattanDistance(Beacon);
    }

    public int ManhattanDistance(int x, int y)
    {
        return Position.ManhattanDistance(x, y);
    }
}