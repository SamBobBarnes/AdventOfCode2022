namespace UnitTests.Day20;

public class CoordinateList
{
    public List<Coordinate> Coordinates;
    public CoordinateList(List<string> coords)
    {
        Coordinates = new List<Coordinate>();
        for (int i = 0; i < coords.Count; i++)
        {
            var coordinate = new Coordinate(int.Parse(coords[i]), i);
            Coordinates.Add(coordinate);
            if (i != 0)
            {
                Coordinates[i-1].Right = coordinate;
                Coordinates[i].Left = Coordinates[i-1];
            }

            if (i == coords.Count - 1)
            {
                Coordinates[i].Right = Coordinates[0];
                Coordinates[0].Left = Coordinates[i];
            }
        }
    }
}

public class Coordinate
{
    public int Value { get; set; }
    public bool IsVisited { get; set; }
    public Coordinate Left { get; set; }
    public Coordinate Right { get; set; }
    public int ExecutionOrder { get; set; }
    
    public Coordinate(int value, int executionOrder)
    {
        Value = value;
        ExecutionOrder = executionOrder;
    }
}