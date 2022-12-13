using AdventOfCode2022.Day9;
using System.ComponentModel.DataAnnotations;

namespace AdventOfCode2022.Day12;

class Cell : IEquatable<Cell>
{
    public Cell(int x, int y, char value, int height)
    {
        X = x;
        Y = y;
        Value = value;
        this.Height = height;
        _max = height + 1;
    }

    public char Value;
    public int Height;
    public int X;
    public int Y;
    public Cell Up;
    public Cell Down;
    public Cell Left;
    public Cell Right;
    private int _max;
    public bool Visited;

    public IEnumerable<Cell> Adjacent(Cell prev = null)
    {
        var validCells = new List<Cell>();
        if (Left != null && Left.Height <= _max && Left != prev && !Left.Visited)
        {
            validCells.Add(Left);
        }

        if (Up != null && Up.Height <= _max && Up != prev && !Up.Visited)
        {
            validCells.Add(Up);
        }

        if (Right != null && Right.Height <= _max && Right != prev && !Right.Visited)
        {
            validCells.Add(Right);
        }

        if (Down != null && Down.Height <= _max && Down != prev && !Down.Visited)
        {
            validCells.Add(Down);
        }
        return validCells;
    }


    public override bool Equals(object obj)
    {
        return Equals(obj as Cell);
    }

    public bool Equals(Cell other)
    {
        if (other == null)
            return false;

        return X.Equals(other.X) && Y.Equals(other.Y);
    }

    public new string ToString()
    {
        return $"{X},{Y}: {Value}";
    }
}

class Position : IEquatable<Position>
{
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Position(Position a)
    {
        X = a.X;
        Y = a.Y;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public new string ToString()
    {
        return $"{X},{Y}";
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Position);
    }

    public bool Equals(Position other)
    {
        if (other == null)
            return false;

        return X.Equals(other.X) && Y.Equals(other.Y);
    }
}