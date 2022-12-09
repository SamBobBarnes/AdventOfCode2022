namespace AdventOfCode2022.Day9;

class Move
{
    public Move(string input)
    {
        var data = input.Split(" ");
        Spaces = int.Parse(data[1]);
        SpacesRemaining = int.Parse(data[1]);
        switch (data[0])
        {
            case "U":
                Direction = Direction.Up;
                break;
            case "R":
                Direction = Direction.Right;
                break;
            case "D":
                Direction = Direction.Down;
                break;
            case "L":
                Direction = Direction.Left;
                break;
        }
    }

    public Direction Direction { get; }
    public int Spaces { get; set; }
    private int SpacesRemaining;

    public int Remaining()
    {
        if (SpacesRemaining > 0)
        {
            SpacesRemaining--;
            return SpacesRemaining + 1;
        }

        return 0;
    }

    public new string ToString()
    {
        return $"{Direction}:{Spaces}";
    }

    public Tuple<Direction, int> Where()
    {
        var direction = Direction.Up;
        var distance = 0;
        switch (Direction)
        {
            case Direction.Up:
                distance = 1;
                break;
            case Direction.Down:
                distance = -1;
                break;
            case Direction.Right:
                direction = Direction.Right;
                distance = 1;
                break;
            case Direction.Left:
                direction = Direction.Right;
                distance = -1;
                break;
        }

        return new Tuple<Direction, int>(direction, distance);
    }
}

enum Direction
{
    Up,
    Right,
    Down,
    Left
}