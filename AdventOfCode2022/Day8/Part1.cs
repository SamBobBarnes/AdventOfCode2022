namespace AdventOfCode2022.Day8;

public class Part1 : BasePart
{
    public static int Run()
    {
        Start(8,1);
        var input = LoadInput(8);
        var map = input.Select(x =>
        {
            var row =  x.ToCharArray().ToList();
            return row.Select(y => int.Parse(y.ToString())).ToList();

        }).ToList();
        var total = 0;

        for (int i = 0; i < map[0].Count; i++)
        {
            for (int j = 0; j < map.Count; j++)
            {
                if (IsTreeVisible(map, i, j)) total++;
            }
        }
        
        return total;
    }

    private static bool IsTreeVisible(List<List<int>> map, int x, int y)
    {
        var left = true;
        var right = true;
        var up = true;
        var down = true;
        var tree = map[y][x];
        //left
        var row = map[y];
        for (int i = 0; i < x; i++)
        {
            if (row[i] >= tree) left = false;
        }
        //right
        for (int i = row.Count-1; i > x; i--)
        {
            if (row[i] >= tree) right = false;
        }
        //up
        for (int i = 0; i < y; i++)
        {
            if (map[i][x] >= tree) up = false;
        }
        //down
        for (int i = map.Count-1; i > y; i--)
        {
            if (map[i][x] >= tree) down = false;
        }

        return left || right || down || up;
    }
}