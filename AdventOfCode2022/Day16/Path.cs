namespace AdventOfCode2022.Day16;

public class Path
{
    public Path(Path path) : this()
    {
        var steps = path.Steps();
        foreach (var valve in steps)
        {
            _steps.Enqueue(valve);
        }
    }
    
    public Path(List<Valve> valves) : this()
    {
        foreach (var valve in valves)
        {
            _steps.Enqueue(valve);
        }
    }
    
    public Path(Valve valve) : this()
    {
        _steps.Enqueue(valve);
    }
    
    public Path()
    {
        _steps = new();
    }

    private Queue<Valve> _steps;

    public void Add(Valve x)
    {
        _steps.Enqueue(x);
    }

    public List<Valve> Steps()
    {
        return _steps.ToList();
    }

    public bool InPath(Valve x)
    {
        return _steps.Any(v => v.Id == x.Id);
    }

    public int GetPathValue(Dictionary<string,Dictionary<string,int>> shortestPaths)
    {
        var total = 0;
        var totalTime = 0;
        var stepsToTake = _steps.Count - 1;
        var current = _steps.Dequeue();
        var visited = new List<Valve>();
        for (int i = 0; i < stepsToTake; i++)
        {
            var next = _steps.Dequeue();
            var timeTaken = CalculateMinutesForStep(shortestPaths, current, next);
            total += FlowToAdd(visited, timeTaken);
            totalTime += timeTaken;
            if (totalTime > 30) return 0;
            visited.Add(next);
            current = next;
        }

        total += FlowToAdd(visited, 30 - totalTime);

        return total;
    }

    private int CalculateMinutesForStep(Dictionary<string,Dictionary<string,int>> shortestPaths, Valve a, Valve b)
    {
        return shortestPaths[a.Id][b.Id] + 1;
    }

    private int FlowToAdd(List<Valve> visited, int timeTaken)
    {
        var total = 0;
        foreach (var valve in visited)
        {
            total += valve.FlowRate;
        }

        return total * timeTaken;
    }
}