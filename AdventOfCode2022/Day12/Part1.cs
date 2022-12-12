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
        Position current = null;
        Position goal = null;
        var steps = 0;
        var Map = input.Select(x => x.ToCharArray().ToList()).ToList();
        for (int i = 0; i < Map.Count; i++)
        {
            for (int j = 0; j < Map[0].Count; j++)
            {
                if (Map[i][j] == 'S') current = new Position(j, i);
                if (Map[i][j] == 'E') goal = new Position(j, i);
            }
        }
        
        Console.WriteLine(current!.ToString());
        Console.WriteLine(goal!.ToString());

        steps = PathFind(Next, Map, current);
        
        return 0;
    }

    private static int PathFind(Dictionary<char,char> Next, List<List<char>>map, Position current, int initialSteps = 0)
    {
        var steps = initialSteps;
        var Directions = new Dictionary<char,char>(){{'U','\0'},{'D','\0'},{'L','\0'},{'R','\0'}}; // up down left right
        var NewPathSteps = new Dictionary<char, int>(){{'U',0},{'D',0},{'L',0},{'R',0}};
        var currentStep = map[current.Y][current.X];
        if (currentStep == 'E') return steps;
        
        if(current.Y != 0) Directions['U'] = map[current.Y - 1][current.X];
        if(current.Y != map.Count - 1) Directions['D'] = map[current.Y + 1][current.X];
        if(current.X != 0) Directions['L'] = map[current.Y][current.X - 1];
        if(current.X != map[0].Count - 1) Directions['R'] = map[current.Y][current.X + 1];

        foreach (var direction in Directions)
        {
            if (direction.Value == '\0') continue;

            if ((currentStep == 'S' && direction.Value == 'a') ||
                (direction.Value == Next[currentStep] || direction.Value == currentStep))
            {
                var nextStep = current;
                switch (direction.Key)
                {
                    case 'U':
                        nextStep.Y -= 1;
                        break;
                    case 'D':
                        nextStep.Y += 1;
                        break;
                    case 'L':
                        nextStep.X -= 1;
                        break;
                    case 'R':
                        nextStep.X += 1;
                        break;
                }
                NewPathSteps[direction.Key] = PathFind(Next, map, nextStep, steps + 1);
            }
        }

        try
        {
            steps = NewPathSteps.Where(x => x.Value > 0).Min(x => x.Value);
        }
        catch
        {
            return 0;
        }
        
        return steps;
    }
}

class Position
{
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }

    public new string ToString()
    {
        return $"{X},{Y}";
    }
}