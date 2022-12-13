namespace AdventOfCode2022.Day12;

public class Part2 : BasePart
{
    public static int Run()
    {
        Start(12, 2);
        var input = LoadInput(12);
        var startingPoints = new List<Position>();
        var map = input.Select(x => x.ToCharArray().ToList()).ToList();
        Console.WriteLine("Building...");
        var count = 0;
        for (int i = 0; i < map.Count; i++)
        {
            for (int j = 0; j < map[i].Count; j++)
            {
                if (map[i][j] == 'a' || map[i][j] == 'S')
                {
                    startingPoints.Add(new Position(j, i));
                    count++;
                    Console.WriteLine($"Starting points: {count}");
                }
            }
        }

        var grids = startingPoints.Select(a => new Grid(map, a.X, a.Y));
        
        Console.WriteLine("Starting...");
        var paths = grids.Select(g =>
        {
            var length = g.FindPathLength();
            Console.WriteLine($"{g._start.ToString()} with path length of {length}. Remaining: {count}");
            count--;
            return length;
        });

        return paths.Where(x => x > 0).Min();
    }
}