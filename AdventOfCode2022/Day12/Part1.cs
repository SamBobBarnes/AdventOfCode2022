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

    private static int PathFind(Dictionary<char,char> Next, List<List<char>>map, Position current, Position previous = null, int initialSteps = 0)
    {
        var steps = initialSteps;
        var directions = new List<char>(){'\0','\0','\0','\0'}; // up down left right
        var NewPathSteps = new List<int>(){0,0,0,0};
        var currentStep = map[current.Y][current.X];
        if (currentStep == 'E') return steps;
        
        if(current.Y != 0) directions[0] = map[current.Y - 1][current.X];
        if(current.Y != map.Count - 1) directions[1] = map[current.Y + 1][current.X];
        if(current.X != 0) directions[2] = map[current.Y][current.X - 1];
        if(current.X != map[0].Count - 1) directions[3] = map[current.Y][current.X + 1];

        for (int i = 0; i < 4; i++)
        {
            if (directions[i] == '\0') continue;

            if ((currentStep == 'S' && directions[i] == 'a') ||
                (directions[i] == Next[currentStep] || directions[i] == currentStep))
            {
                var nextStep = new Position(current);
                switch (i)
                {
                    case 0:
                        nextStep.Y -= 1;
                        break;
                    case 1:
                        nextStep.Y += 1;
                        break;
                    case 2:
                        nextStep.X -= 1;
                        break;
                    case 3:
                        nextStep.X += 1;
                        break;
                }

                if (nextStep.Equals(previous)) continue;
                NewPathSteps[i] = PathFind(Next, map, nextStep, current, steps + 1);
            }
        }

        if (NewPathSteps[0] <= 0 && NewPathSteps[1] <= 0 && NewPathSteps[2] <= 0 && NewPathSteps[3] <= 0) return 0;
        else
        {
            steps = NewPathSteps.Where(x => x > 0).Min(x => x);
        }
        
        return steps;
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