using System.Reflection.Metadata.Ecma335;

namespace AdventOfCode2022.Day14;

class Grid
{
    public Grid(IEnumerable<IEnumerable<Coordinate>> map, int width, int height)
    {
        cells = new List<Cell>();
        _width = width + 1;
        _height = height + 1;

        for (int i = 0; i < _height; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                cells.Add(new(j,i));
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

    private List<Cell> cells;
    private readonly int _width;
    private readonly int _height;

    private Cell GetCell(int x, int y)
    {
        return cells.FirstOrDefault(c => c.Position.X == x && c.Position.Y == y);
    }

    private void DrawLine(Coordinate a, Coordinate b)
    {
        var cellsToDraw = cells.FindAll(c => Coordinate.Between(a, b, c.Position));
        foreach (var cell in cellsToDraw)
        {
            cell.DrawRock();
        }
    }

    public new string ToString()
    {
        var result = "";
        var rowWidth = 0;
        foreach(var cell in cells)
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
        foreach (var cell in cells)
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
