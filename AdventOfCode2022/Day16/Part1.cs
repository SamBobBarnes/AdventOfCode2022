namespace AdventOfCode2022.Day16;

public class Part1 : BasePart
{
    public static int Run()
    {
        Start(16,1);
        var exampleInput = LoadInput(16, true);
        var input = LoadInput(16, false);
        var network = new TunnelNetwork(exampleInput);

        var total = DFSBase(network);
        
        return total;
    }

    private static int DFSBase(TunnelNetwork network)
    {
        var total = 0;
        var currentPosition = network.Valve("AA");
        var shortestPaths = network.ShortestPaths();
        var timeRemaining = 30;
        var unOpenedValves = network.UnOpenedValves();
        var visited = new Dictionary<Valve, bool>();
        foreach (var valve in unOpenedValves)
        {
            visited.Add(valve, false);
        }

        foreach(var valve in visited)
        {
            timeRemaining -= shortestPaths[currentPosition][valve.Key] + 1;
            visited[valve.Key] = true;
            var visitedList = visited.Select(i => $"{i.Key.ToString()}: {i.Value}").ToList();
            var pathTotal = DFS(visited, valve.Key, shortestPaths, timeRemaining, 0);
            if (pathTotal > total) total = pathTotal;
            visited[valve.Key] = false;
            timeRemaining += shortestPaths[currentPosition][valve.Key] + 1;
        }

        return total;
    }

    private static int DFS(Dictionary<Valve,bool> visited, Valve current, Dictionary<Valve,Dictionary<Valve,int>> shortestPaths, int timeRemaining, int total)
    {
        if (timeRemaining <= 0) return 0;
        visited[current] = true;
        if (visited.Where(i => i.Value == false).Count() == 0)
        {
            for(int i = timeRemaining; i >= 0; i--)
            {
                total += FlowToAdd(visited,1);
            }
            return total;
        }
        foreach (var valve in visited)
        {
            if (valve.Value) continue;
            timeRemaining -= shortestPaths[current][valve.Key] + 1;
            var pathTotal = FlowToAdd(visited, shortestPaths[current][valve.Key] + 1);
            visited[valve.Key] = true;
            var visitedList = visited.Select(i => $"{i.Key.ToString()}: {i.Value}").ToList();
            pathTotal = DFS(visited, valve.Key, shortestPaths, timeRemaining, pathTotal);
            if (pathTotal > total) total = pathTotal;
            visited[valve.Key] = false;
            timeRemaining += shortestPaths[current][valve.Key] + 1;
        }

        return total;
    }

    private static int FlowToAdd(Dictionary<Valve, bool> visited, int timeTaken)
    {
        var total = 0;
        foreach (var valve in visited)
        {
            if (valve.Value) total += valve.Key.FlowRate;
        }

        return total * timeTaken;
    }
}