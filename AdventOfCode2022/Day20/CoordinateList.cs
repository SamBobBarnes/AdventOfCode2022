namespace AdventOfCode2022.Day20;

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
        }
    }

    public void MultiplyAll(int multiplier)
    {
        foreach (var coordinate in Coordinates)
        {
            coordinate.Value *= multiplier;
        }
    }

    public void UnVisitAll()
    {
        foreach (var coordinate in Coordinates)
        {
            coordinate.IsVisited = false;
        }
    }

    public long FindIndexFromZero(int index)
    {
        var zero = Coordinates.FindIndex(c => c.Value == 0);
        var length = Coordinates.Count;
        var newIndex = (zero + index) % length;
        return Coordinates[newIndex].Value;
    }

    public void MixAll()
    {
        while(Coordinates.Any(c => !c.IsVisited))
        {
            var next = Coordinates.Where(c => !c.IsVisited).Min(c => c.ExecutionOrder);
            var index = Coordinates.FindIndex(c => c.ExecutionOrder == next);
            Mix(index);
        }
    }

    public void Mix(int index)
    {
        var coord = Coordinates[index];
        var direction = coord.Value;
        Coordinates.RemoveAt(index);
        var newIndex = index + direction;
        while(newIndex < 0)
        {
            if (Math.Abs(newIndex) > Coordinates.Count)
            {
                newIndex %= Coordinates.Count;
            }
            else
            {
                newIndex = Coordinates.Count + newIndex;
            }
        }
        while(newIndex >= Coordinates.Count)
        {
            newIndex %= Coordinates.Count;
        }

        coord.IsVisited = true;
        Coordinates.Insert((int)newIndex, coord);
    }

    public override string ToString()
    {
        var result = "";
        foreach (var coordinate in Coordinates)
        {
            result += coordinate.Value + " ";
        }
        return result.Trim();
    }
}

public class Coordinate
{
    public Int64 Value { get; set; }
    public bool IsVisited { get; set; }
    public int ExecutionOrder { get; set; }
    
    public Coordinate(int value, int executionOrder)
    {
        Value = value;
        ExecutionOrder = executionOrder;
    }
}