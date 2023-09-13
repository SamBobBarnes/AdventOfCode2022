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

    public override string ToString()
    {
        var map = "";
        for(int y = 0; y < Grid.GetLength(1); y++)
        {
            for (int x = 0; x < Grid.GetLength(0); x++)
            {
                if (Position.X == x && Position.Y == y)
                {
                    map += "X";
                    continue;
                }
                switch (Grid[x, y])
                {
                    case Tiles.Floor:
                        map += ".";
                        break;
                    case Tiles.Wall:
                        map += "#";
                        break;
                    case Tiles.Rebound:
                        map += " ";
                        break;
                }
            }
            map += "\n";
        }

        return map;
    }

    public void MoveCharacter()
    {
        var spacesToMove = GetSpacesAhead(Steps[StepIndex]);
        
        switch (Facing)
        {
            case Direction.Right:
                Position = new Point(Position.X + spacesToMove, Position.Y);
                if (Position.X >= Grid.GetLength(0)) Position = new Point(Position.X % Grid.GetLength(0), Position.Y);
                if (Position.X < 0) Position = new Point(Grid.GetLength(0) + Position.X % Grid.GetLength(0), Position.Y);
                break;
            case Direction.Down:
                Position = new Point(Position.X, Position.Y + spacesToMove);
                if (Position.Y >= Grid.GetLength(1)) Position = new Point(Position.X, Position.Y % Grid.GetLength(1));
                if (Position.Y < 0) Position = new Point(Position.X,Grid.GetLength(1) + Position.Y % Grid.GetLength(1));
                break;
            case Direction.Left:
                Position = new Point(Position.X - spacesToMove, Position.Y);
                if (Position.X < 0) Position = new Point(Grid.GetLength(0) + Position.X % Grid.GetLength(0), Position.Y);
                if (Position.X >= Grid.GetLength(0)) Position = new Point(Position.X % Grid.GetLength(0), Position.Y);
                break;
            case Direction.Up:
                Position = new Point(Position.X, Position.Y - spacesToMove);
                if (Position.Y < 0) Position = new Point(Position.X,Grid.GetLength(1) + Position.Y % Grid.GetLength(1));
                if (Position.Y >= Grid.GetLength(1)) Position = new Point(Position.X, Position.Y % Grid.GetLength(1));
                break;
        }
        StepIndex++;
    }
    
    public bool Rotate()
    {
        if (RotationIndex >= Rotations.Length) return false;
        
        Facing = NextRotation(Rotations[RotationIndex]);
        RotationIndex++;
        
        return true;
    }

    private Direction NextRotation(char direction)
    {
        switch (direction)
        {
            case 'L':
                switch (Facing)
                {
                    case Direction.Right:
                        return Direction.Up;
                    case Direction.Down:
                        return Direction.Right;
                    case Direction.Left:
                        return Direction.Down;
                    case Direction.Up:
                        return Direction.Left;
                    default:
                        return Facing;
                }
            case 'R':
                switch (Facing)
                {
                    case Direction.Right:
                        return Direction.Down;
                    case Direction.Down:
                        return Direction.Left;
                    case Direction.Left:
                        return Direction.Up;
                    case Direction.Up:
                        return Direction.Right;
                    default:
                        return Facing;
                }
            default:
                return Facing;
        }
    }

    private int GetSpacesAhead(int spacesToMove)
    {
        var floor = new List<Tiles>();
        var walls = new List<int>();
        var rebound = 0;
        var rowX = Grid.GetLength(0);
        var rowY = Grid.GetLength(1);
        
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
        
                return spacesToMove + rebound;
            case Direction.Down:
                for (var i = 0; i < Grid.GetLength(1); i++)
                {
                    if(Grid[Position.X, i] == Tiles.Floor)
                        floor.Add(Grid[Position.X, i]);
                    if (Grid[Position.X, i] == Tiles.Rebound)
                        rebound++;
                    if(Grid[Position.X, i] == Tiles.Wall)
                        walls.Add(i);
                }
        
                if (floor.Count == rowY) return spacesToMove;
        
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
                    foreach (var wall in walls.Where(wall => wall > Position.Y && wall <= rowY || wall <= (Position.Y + spacesToMove) % rowY))
                    {
                        spacesToMove = wall - Position.Y - 1;
                        break;
                    }
                }
        
                return spacesToMove + rebound;
            case Direction.Left:
                var positionX = rowX - Position.X - 1;
                var reverseIndexX = 0;
                for (var i = Grid.GetLength(0) - 1; i >= 0; i--)
                {
                    if(Grid[i, Position.Y] == Tiles.Floor)
                        floor.Add(Grid[i, Position.Y]);
                    if (Grid[i, Position.Y] == Tiles.Rebound)
                        rebound++;
                    if(Grid[i, Position.Y] == Tiles.Wall)
                        walls.Add(reverseIndexX);
                    reverseIndexX++;
                }
        
                if (floor.Count == rowX) return spacesToMove;
        
                if (spacesToMove + positionX < rowX)
                {
                    foreach (var wall in walls.Where(wall => wall > positionX && wall <= positionX + spacesToMove))
                    {
                        spacesToMove = wall - positionX - 1;
                        break;
                    }
                }
                else
                {
                    foreach (var wall in walls.Where(wall => wall > positionX && wall <= rowX || wall <= (positionX + spacesToMove) % rowX))
                    {
                        spacesToMove = wall - positionX - 1;
                        break;
                    }
                }
        
                return spacesToMove + rebound;
            case Direction.Up:
                var positionY = rowY - Position.Y - 1;
                var reverseIndexY = 0;
                for (var i = Grid.GetLength(1) - 1; i >= 0; i--)
                {
                    if(Grid[Position.X, i] == Tiles.Floor)
                        floor.Add(Grid[Position.X, i]);
                    if (Grid[Position.X, i] == Tiles.Rebound)
                        rebound++;
                    if(Grid[Position.X, i] == Tiles.Wall)
                        walls.Add(reverseIndexY);
                    reverseIndexY++;
                }
        
                if (floor.Count == rowY) return spacesToMove;
        
                if (spacesToMove + positionY < rowY)
                {
                    foreach (var wall in walls.Where(wall => wall > positionY && wall <= positionY + spacesToMove))
                    {
                        spacesToMove = wall - positionY;
                        break;
                    }
                }
                else
                {
                    foreach (var wall in walls.Where(wall => wall > positionY && wall <= rowY || wall <= (positionY + spacesToMove) % rowY))
                    {
                        spacesToMove = wall - positionY - 1;
                        break;
                    }
                }
        
                return spacesToMove + rebound;
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