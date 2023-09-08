using System.Drawing;

namespace AdventOfCode2022.Day22;

public class Room
{
    public Point Position { get; set; }
    public Direction Facing { get; set; }
    public Tiles[,] Grid { get; set; }
    public int[] Steps { get; set; }
    public char[] Rotations { get; set; }
    public int StepIndex { get; set; }
    public int RotationIndex { get; set; }

    public Room(List<string> input)
    {
        Facing = Direction.Right;

        InitializeDirections(input[^1]);
        InitializeMap(input.GetRange(0, input.Count - 2));
        InitializeCharacter();
    }

    public void MoveCharacter()
    {
        switch (Facing)
        {
            case Direction.Right:
                Position = new Point(Position.X + Steps[StepIndex], Position.Y);
                if (Position.X >= Grid.GetLength(0)) Position = new Point(Position.X % Grid.GetLength(0), Position.Y);
                break;
            case Direction.Down:
                Position = new Point(Position.X, Position.Y + Steps[StepIndex]);
                if (Position.Y >= Grid.GetLength(1)) Position = new Point(Position.X, Position.Y % Grid.GetLength(1));
                break;
            case Direction.Left:
                Position = new Point(Position.X - Steps[StepIndex], Position.Y);
                if (Position.X < 0) Position = new Point(Grid.GetLength(0) + Position.X % Grid.GetLength(0), Position.Y);
                break;
            case Direction.Up:
                Position = new Point(Position.X, Position.Y - Steps[StepIndex]);
                if (Position.Y < 0) Position = new Point(Position.X,Grid.GetLength(1) + Position.Y % Grid.GetLength(1));
                break;
        }
    }

    private void InitializeCharacter()
    {
        for (int x = 0; x < Grid.GetLength(0); x++)
        {
            if (Grid[x, 0] == Tiles.Floor)
            {
                Position = new Point(x, 0);
                return;
            }
        
        }
    }

    private void InitializeDirections(string directions)
    {
        Steps = directions.Split(new[] { 'L', 'R' }).Select(int.Parse).ToArray();
        Rotations = directions.Where(char.IsLetter).ToArray();
    }

    private void InitializeMap(List<string> input)
    {
        var width = 0;
        var height = input.Count;
        foreach (var row in input)
        {
            if(width < row.Length)
                width = row.Length;
        }
        
        Grid = new Tiles[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                try
                {
                    switch (input[y][x])
                    {
                        case '.':
                            Grid[x, y] = Tiles.Floor;
                            break;
                        case '#':
                            Grid[x, y] = Tiles.Wall;
                            break;
                        case ' ':
                            Grid[x, y] = Tiles.Rebound;
                            break;
                    }
                }
                catch
                {
                    Grid[x, y] = Tiles.Rebound;
                }
                
            }
        }
    }
}

public enum Direction
{
    Right,
    Down,
    Left,
    Up
}

public enum Tiles
{
    Wall,
    Floor,
    Character,
    Trail,
    Rebound
}