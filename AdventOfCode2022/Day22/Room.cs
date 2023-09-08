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
        var spacesToMove = GetSpacesAhead(Steps[StepIndex]);
        
        switch (Facing)
        {
            case Direction.Right:
                Position = new Point(Position.X + spacesToMove, Position.Y);
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

    private int GetSpacesAhead(int spacesToMove)
    {
        var floor = new List<Tiles>();
        var walls = new List<int>();
        var rebound = 0;
        var rowX = Grid.GetLength(1);
        var rowY = Grid.GetLength(0);
        
        switch (Facing)
        {
            case Direction.Right:
                for (var i = 0; i < Grid.GetLength(0); i++)
                {
                    if(Grid[i, Position.Y] == Tiles.Floor)
                        floor.Add(Grid[i, Position.Y]);
                    if (Grid[i, Position.Y] == Tiles.Rebound)
                        rebound++;
                    if(Grid[i, Position.Y] == Tiles.Wall)
                        walls.Add(i);
                }
        
                if (floor.Count == rowX) return spacesToMove;
                if(Position.X + spacesToMove >= rowX && floor.Count + rebound == rowX) return spacesToMove + rebound;
        
                if (spacesToMove + Position.X < rowX)
                {
                    foreach (var wall in walls.Where(wall => wall > Position.X && wall <= Position.X + spacesToMove))
                    {
                        spacesToMove = wall - Position.X;
                        break;
                    }
                }
                else
                {
                    foreach (var wall in walls.Where(wall => wall > Position.X && wall <= rowX || wall <= (Position.X + spacesToMove) % rowX))
                    {
                        spacesToMove = wall - Position.X - 1;
                        break;
                    }
                }
        
                return spacesToMove;
            case Direction.Down:
                for (var i = 0; i < Grid.GetLength(1); i++)
                {
                    if(Grid[Position.X, i] == Tiles.Floor)
                        floor.Add(Grid[i, Position.Y]);
                    if (Grid[Position.X, i] == Tiles.Rebound)
                        rebound++;
                    if(Grid[Position.X, i] == Tiles.Wall)
                        walls.Add(i);
                }
        
                if (floor.Count == rowY) return spacesToMove;
                if(Position.Y + spacesToMove >= rowY && floor.Count + rebound == rowY) return spacesToMove + rebound;
        
                if (spacesToMove + Position.Y < rowY)
                {
                    foreach (var wall in walls.Where(wall => wall > Position.Y && wall <= Position.Y + spacesToMove))
                    {
                        spacesToMove = wall - Position.Y;
                        break;
                    }
                }
                else
                {
                    foreach (var wall in walls.Where(wall => wall > Position.X && wall <= rowY || wall <= (Position.Y + spacesToMove) % rowY))
                    {
                        spacesToMove = wall - Position.Y - 1;
                        break;
                    }
                }
        
                return spacesToMove;
            case Direction.Left:
                
            case Direction.Up:
                
            default: 
                return spacesToMove;
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