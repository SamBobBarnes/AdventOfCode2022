namespace AdventOfCode2022.Day9;

class Grid
{
    public Grid(Tuple<int, int, int, int> gridSize)
    {
        _width = gridSize.Item1;
        _height = gridSize.Item2;
        GridCells = CreateGrid();
        Head = new Position(gridSize.Item3, gridSize.Item4);
        Tail = new Position(gridSize.Item3, gridSize.Item4);
    }

    private readonly int _width;
    private readonly int _height;
    private List<List<Cell>> GridCells { get; }
    private Position Head { get; }
    private Position Tail { get; }

    private List<List<Cell>> CreateGrid()
    {
        var grid = new List<List<Cell>>();
        for (int i = 0; i < _height; i++)
        {
            var row = new List<Cell>();
            for (int j = 0; j < _width; j++)
            {
                row.Add(new Cell());
            }
            grid.Add(row);
        }

        return grid;
    }

    public new string ToString()
    {
        var grid = "";
        for (int i = 0; i < _height; i++)
        {
            var row = "";
            for (int j = 0; j < _width; j++)
            {
                if (Head.Locate(j, i)) row += "H";
                else if (Tail.Locate(j, i)) row += "T";
                else if (GridCells[i][j].Used) row += "#";
                else row += ".";
            }

            grid = row + "\r\n" + grid;
        }
        return grid;
    }

    public void Move(Move move)
    {
        while (move.Remaining() > 0)
        {
            switch (move.Where().Item1)
            {
                case Direction.Up:
                    Head.Y += move.Where().Item2;
                    MoveTail();
                    break;
                case Direction.Right:
                    Head.X += move.Where().Item2;
                    MoveTail();
                    break;
            }
        }
    }

    private void MoveTail()
    {
        //dont move tail
        if (Tail.X == Head.X && Tail.Y == Head.Y) return;
        else if (Tail.X + 1 == Head.X && Tail.Y + 1 == Head.Y) return;
        else if (Tail.X + 1 == Head.X && Tail.Y == Head.Y) return;
        else if (Tail.X + 1 == Head.X && Tail.Y - 1 == Head.Y) return;
        else if (Tail.X == Head.X && Tail.Y - 1 == Head.Y) return;
        else if (Tail.X - 1 == Head.X && Tail.Y - 1 == Head.Y) return;
        else if (Tail.X - 1 == Head.X && Tail.Y == Head.Y) return;
        else if (Tail.X - 1 == Head.X && Tail.Y + 1 == Head.Y) return;
        else if (Tail.X == Head.X && Tail.Y + 1 == Head.Y) return;
        
        //move tail
        GridCells[Tail.Y][Tail.X].Use();
        
        ChaseHead();
        
        GridCells[Tail.Y][Tail.X].Use();
    }

    private void ChaseHead()
    {
        if ((Tail.X - Head.X == 1 && Tail.Y - Head.Y == 2) 
            || (Tail.X - Head.X == 2 && Tail.Y - Head.Y == 1))
        {
            Tail.Y--;
            Tail.X--;
        }
        else if ((Head.X - Tail.X == 1 && Head.Y - Tail.Y == 2) 
                || (Head.X - Tail.X == 2 && Head.Y - Tail.Y == 1))
        {
            Tail.Y++;
            Tail.X++;
        }
        else if ((Head.X - Tail.X == 1 && Tail.Y - Head.Y == 2) 
                 || (Head.X - Tail.X == 2 && Tail.Y - Head.Y == 1))
        {
            Tail.Y--;
            Tail.X++;
        }
        else if ((Tail.X - Head.X == 1 && Head.Y - Tail.Y == 2) 
                 || (Tail.X - Head.X == 2 && Head.Y - Tail.Y == 1))
        {
            Tail.Y++;
            Tail.X--;
        }
        else if (Tail.X - Head.X == 2) Tail.X--;
        else if (Head.X - Tail.X == 2) Tail.X++;
        else if (Head.Y - Tail.Y == 2) Tail.Y++;
        else if (Tail.Y - Head.Y == 2) Tail.Y--;
    }

    public int VisitedPositions()
    {
        var visited = 0;
        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                if (GridCells[i][j].Used) visited++;
            }
        }

        return visited;
    }
}

class Position
{
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
    public int X { get; set; }
    public int Y { get; set; }

    public bool Locate(int x, int y)
    {
        return x == X && y == Y;
    }
}

class Cell
{
    public void Use()
    {
        Used = true;
    }
    public bool Used { get; set; }
}