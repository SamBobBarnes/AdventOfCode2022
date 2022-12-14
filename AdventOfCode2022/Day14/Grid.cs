using System.Reflection.Metadata.Ecma335;

namespace AdventOfCode2022.Day14;

class Grid
{
    public Grid(IEnumerable<IEnumerable<Coordinate>> map, int width, int height)
    {
        _cells = new List<Cell>();
        _width = width + 1;
        _height = height + 1;

        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                _cells.Add(new(j,i));
            }
        }

        foreach(var row in map)
        {
            var rowItems = row.ToList();
            for (int j = 0; j < row.Count()-1; j++)
            {
                DrawLine(rowItems[j], rowItems[j + 1]);
            }
        }

        GetCell(500, 0).SetSource();
    }

    private readonly List<Cell> _cells;
    private readonly int _width;
    private readonly int _height;

    private Cell GetCell(int x, int y)
    {
        return _cells.FirstOrDefault(c => c.Position.X == x && c.Position.Y == y)!;
    }

    private Cell GetSandSource()
    {
        return _cells.FirstOrDefault(c => c.PrintContent() == "+")!;
    }

    private void DrawLine(Coordinate a, Coordinate b)
    {
        var cellsToDraw = _cells.FindAll(c => Coordinate.Between(a, b, c.Position));
        foreach (var cell in cellsToDraw)
        {
            cell.DrawRock();
        }
    }

    private bool CheckForFloorBelow(Cell a)
    {
        var b = GetCell(a.Position.X, _height - 1);
        if (a.Position.Y == b.Position.Y) return false;
        var cellsToCheck = _cells.FindAll(c => Coordinate.Between(a.Position, b.Position, c.Position));

        foreach (var cell in cellsToCheck)
        {
            if (cell.isSolid) return true;
        }

        return false;
    }

    private Cell? NextValidCell(Cell a)
    {
        var down = GetCell(a.Position.X, a.Position.Y + 1);
        if (!down.isSolid) return down;
        var left = GetCell(a.Position.X - 1, a.Position.Y + 1);
        if (!left.isSolid) return left;
        var right = GetCell(a.Position.X + 1, a.Position.Y + 1);
        if (!right.isSolid) return right;
        return null;
    }
    
    public int SimulateSand()
    {
        var source = GetSandSource();
        var noFloor = false;
        var count = 0;
        Cell.CreateSand(source);
        while (!noFloor)
        {
            count++;
            var sand = DropSand(source);
            if (!CheckForFloorBelow(sand!))
            {
                Cell.RemoveSand(sand);
                noFloor = true;
            }
        }
        
        count--;
        return count;
    }

    private Cell DropSand(Cell source)
    {
        var sand = source;
        var noFloor = false;
        Cell.CreateSand(sand);
        while (!noFloor)
        {
            if (!CheckForFloorBelow(sand!))
            {
                noFloor = true;
                break;
            }
            var nextValid = NextValidCell(sand);
            if (nextValid == null) break;
            Cell.MoveSand(sand,nextValid!);
            sand = nextValid;
        }

        return sand;
    }

    public new string ToString()
    {
        var result = "";
        var rowWidth = 0;
        foreach(var cell in _cells)
        {
            result += cell.PrintContent();
            rowWidth++;
            if (rowWidth == _width)
            {
                result += "\r\n";
                rowWidth = 0;
            }
        }
        return result;
    }

    public string ToString(int x, int y)
    {
        var result = "";
        var rowWidth = 0;
        var row = 0;
        foreach (var cell in _cells)
        {
            if(rowWidth >= x && row >= y) result += cell.PrintContent();
            rowWidth++;
            if (rowWidth == _width)
            {
                result += "\r\n";
                rowWidth = 0;
            }
        }
        return result;
    }
}
