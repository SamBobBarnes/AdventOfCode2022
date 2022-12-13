namespace AdventOfCode2022.Day12;

class Grid
{
    public Grid(List<List<char>> map)
    {
        _grid = new();
        for (int i = 0; i < map.Count; i++)
        {
            for (int j = 0; j < map[i].Count; j++)
            {
                _grid.Add(new Cell(j, i, map[i][j], CharToHeight(map[i][j])));
            }
        }
        _width = map[0].Count;
        _height = map.Count;

        var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        _moves = new Dictionary<char, char[]>();
        for (int i = 1; i < alphabet.Length - 1; i++)
        {
            _moves.Add(alphabet[i], new char[] { alphabet[i - 1], alphabet[i], alphabet[i + 1] });
        }
        _moves.Add('z', new char[] { 'z', 'E' });
        _moves.Add('S', new char[] { 'a' });
        _moves.Add('a', new char[] { 'a', 'b' });
        FindAdjacentCells();
        _start = _grid.First(c => c.Value == 'S');
        _goal = _grid.First(c => c.Value == 'E');
    }

    private readonly int _width;
    private readonly int _height;
    private readonly Dictionary<char, char[]> _moves;
    private readonly List<Cell> _grid;
    private Cell _start;
    private Cell _goal;

    private int CharToHeight(char a)
    {
        if (a == 'S') return 0;
        if (a == 'E') return 25;
        var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray().ToList();
        return alphabet.IndexOf(a);
    }

    private void FindAdjacentCells()
    {
        foreach (var cell in _grid)
        {
            var x = cell.X;
            var y = cell.Y;
            if (x > 0) cell.Left = _grid.First(c => c.X == x - 1 && c.Y == y);
            if (y > 0) cell.Up = _grid.First(c => c.X == x && c.Y == y - 1);
            if (x < _width - 1) cell.Right = _grid.First(c => c.X == x + 1 && c.Y == y);
            if (y < _height - 1) cell.Down = _grid.First(c => c.X == x && c.Y == y + 1);
        }
    }

    //private void PrintGrid()
    //{
    //    var grid = new List<List<string>>();
    //    for (int i = 0; i < _height; i++)
    //    {
    //        grid.Add(new());
    //    }
    //    foreach (var cell in _grid)
    //    {
    //        grid[cell.Y].Add(cell.Visited ? cell.Value.ToString().ToUpper() : cell.Value.ToString().ToLower());
    //    }

    //    var gridString = "";
    //    for (int i = 0; i < _height; i++)
    //    {
    //        for (int j = 0; j < _width; j++)
    //        {
    //            gridString += grid[i][j];
    //        }
    //        gridString += "\r\n";
    //    }
    //    Console.WriteLine(gridString);
    //}

    public int FindPathLength()
    {

        var depth = new Dictionary<Cell, int>() { [_start] = 0 };
        var queue = new Queue<Cell>(depth.Keys);

        while (queue.Count > 0)
        {

            var cell = queue.Peek();
            queue.Dequeue();
            if (cell == _goal) break;

            var d = depth[cell];

            var adjacent = cell.Adjacent();
            

            foreach (var item in adjacent)
            {
                if (!queue.Contains(item))
                {
                    depth[item] = d + 1;
                    queue.Enqueue(item);
                }
                
            }
        }

        return depth[_goal];
    }
}
