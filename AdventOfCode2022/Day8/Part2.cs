namespace AdventOfCode2022.Day8;

public class Part2 : BasePart
{
    public static int Run()
    {
        Start(8,1);
        var input = LoadInput(8);
        var map = input.Select(x =>
        {
            var row =  x.ToCharArray().ToList();
            return row.Select(y => new Tree(y)).ToList();

        }).ToList();
        var bestTree = 0;

        for (int i = 0; i < map[0].Count; i++)
        {
            for (int j = 0; j < map.Count; j++)
            {
                var score = ScoreTree(map, i, j);
                if (score > bestTree) bestTree = score;
            }
        }

        return bestTree;
    }

    private static int ScoreTree(List<List<Tree>> map, int x, int y)
    {
        var left = 0;
        var right = 0;
        var up = 0;
        var down = 0;
        var tree = map[y][x];
        
        //left
        var row = map[y];
        for (var i = x-1; i >= 0; i--)
        {
            if (row[i].Height < tree.Height) left++;
            else
            {
                left++;
                break;
            }
            
        }
        //right
        for (var i = x+1; i < row.Count; i++)
        {
            if (row[i].Height < tree.Height) right++;
            else
            {
                right++;
                break;
            }
        }
        //up
        for (var i = y-1; i >= 0; i--)
        {
            if (map[i][x].Height < tree.Height) up++;
            else
            {
                up++;
                break;
            }
        }
        //down
        for (var i = y+1; i < map.Count; i++)
        {
            if (map[i][x].Height < tree.Height) down++;
            else
            {
                down++;
                break;
            }
        }

        map[y][x].Score = left * right * up * down;
        return left * right * up * down;
    }
}

class Tree
{
    public Tree(char height)
    {
        Height = int.Parse(height.ToString());
    }
    public int Height { get; }
    public int Score { get; set; }
}