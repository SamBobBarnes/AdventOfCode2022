namespace AdventOfCode2022.Day12;

public class Part1 : BasePart
{
    public static int Run()
    {
        Start(12,1);
        var input = LoadInput(12);
        var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
        var Next = new Dictionary<char, char>();
        for (int i = 0; i < alphabet.Length-1; i++)
        {
            Next.Add(alphabet[i], alphabet[i+1]);
        }
        Next.Add('z','E');
        Next.Add('S','a');
        Position current = null;
        var steps = 0;
        var Map = input.Select(x => x.ToCharArray().ToList()).ToList();
        for (int i = 0; i < Map.Count; i++)
        {
            for (int j = 0; j < Map[0].Count; j++)
            {
                if (Map[i][j] == 'S') current = new Position(j, i);
            }
        }
        
        Console.WriteLine(current!.ToString());

        steps = PathFind(Next, Map, current, new List<Position>());
        
        return 0;
    }

    private static int PathFind(Dictionary<char,char> Next, List<List<char>>map, Position current, List<Position> visited, int previousSteps = 0)
    {
        var steps = previousSteps + 1;
        var visitedSteps = visited.Select(x => new Position(x)).ToList();
        visitedSteps.Add(current);
        var currentStep = map[current.Y][current.X];
        var paths = new List<int>(){0,0,0,0};
        if (currentStep == 'E') return steps;

        for (int i = 0; i < 4; i++)
        {
            char direction = '\0';
            Position nextStep = null;
            switch (i)
            {
                case 0:
                    if (current.Y == 0) continue;
                    if (visitedSteps.FirstOrDefault(x => x.Y == current.Y - 1 && x.X == current.X) != null) continue;
                    direction = map[current.Y - 1][current.X];
                    nextStep = new Position(current.X, current.Y - 1);
                    break;
                case 1:
                    if (current.X == map[0].Count - 1) continue; 
                    if (visitedSteps.FirstOrDefault(x => x.Y == current.Y && x.X == current.X + 1) != null) continue;
                    direction = map[current.Y][current.X + 1];
                    nextStep = new Position(current.X + 1, current.Y);
                    break;
                case 2:
                    if(current.Y == map.Count - 1) continue;
                    if (visitedSteps.FirstOrDefault(x => x.Y == current.Y + 1 && x.X == current.X) != null) continue;
                    direction = map[current.Y + 1][current.X];
                    nextStep = new Position(current.X, current.Y + 1);
                    break;
                case 3:
                    if (current.X == 0) continue;
                    if (visitedSteps.FirstOrDefault(x => x.Y == current.Y && x.X == current.X - 1) != null) continue;
                    direction = map[current.Y][current.X - 1];
                    nextStep = new Position(current.X - 1, current.Y);
                    break;
            }

            if (direction == '\0') continue;
            if (Next[currentStep] == direction || currentStep == direction)
            {
                paths[i] = PathFind(Next, map, nextStep!, visitedSteps, steps);
            }
        }

        var possiblePaths = paths.Where(x => x > 0).ToList();
        if (possiblePaths.Count == 0) return -1;
        return possiblePaths.Min();

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