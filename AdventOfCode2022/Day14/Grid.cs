﻿using System.Reflection.Metadata.Ecma335;

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

    protected readonly List<Cell> _cells;
    protected int _width;
    protected int _height;

    protected Cell? GetCell(int x, int y)
    {
        return _cells.FirstOrDefault(c => c.Position.X == x && c.Position.Y == y)!;
    }

    protected Cell GetSandSource()
    {
        return _cells.FirstOrDefault(c => c.PrintContent() == "+")!;
    }

    protected void DrawLine(Coordinate a, Coordinate b)
    {
        var cellsToDraw = _cells.FindAll(c => Coordinate.Between(a, b, c.Position));
        foreach (var cell in cellsToDraw)
        {
            cell.DrawRock();
        }
    }

    protected bool CheckForFloorBelow(Cell a)
    {
        for (int i = a.Position.Y; i < _height; i++)
        {
            if (GetCell(a.Position.X, i)!.isSolid) return true;
        }

        return false;
    }

    private Cell? NextValidCell(Cell a)
    {
        var down = GetCell(a.Position.X, a.Position.Y + 1);
        if (down != null && !down.isSolid) return down;
        var left = GetCell(a.Position.X - 1, a.Position.Y + 1);
        if (left != null && !left.isSolid) return left;
        var right = GetCell(a.Position.X + 1, a.Position.Y + 1);
        if (right != null && !right.isSolid) return right;
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
        var tempCells = _cells.OrderBy(c => c.Position.Y).ThenBy(c => c.Position.X);
        var result = "";
        var rowWidth = 0;
        foreach(var cell in tempCells)
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
