namespace AdventOfCode2022.Day14;

public class Cell
{
    public Cell(Coordinate position) : this()
    {
        Position = position;
    }

    public Cell(int x, int y) : this()
    {
        Position = new Coordinate(x, y);
    }

    private Cell()
    {
        Content = CellContent.Air;
    }

    public Coordinate Position;
    private char Content;
    public bool isAir { get => Content == CellContent.Air; }
    public bool isSolid { get => Content == CellContent.Sand || Content == CellContent.Rock; }


    private void SetSand()
    {
        Content = CellContent.Sand;
    }
    private void SetAir()
    {
        Content = CellContent.Air;
    }
    public void DrawRock()
    {
        Content = CellContent.Rock;
    }
    public void SetSource()
    {
        Content = CellContent.Source;
    }

    public static bool MoveSand(Cell a, Cell b)
    {
        if (b.isSolid) return false;
        a.SetAir();
        b.SetSand();
        return true;
    }

    public static void CreateSand(Cell sand)
    {
        sand.Content = CellContent.Sand;
    }

    public string PrintContent()
    {
        return Content.ToString();
    }

    public new string ToString()
    {
        return $"{Position.ToString()} : {Content}";
    }
}

public class CellContent
{
    public static readonly char Air = '.';
    public static readonly char Rock = '#';
    public static readonly char Source = '+';
    public static readonly char Sand = '*';
    public static bool ImmovableObject(char x)
    {
        return x == Rock || x == Source;
    }
}
