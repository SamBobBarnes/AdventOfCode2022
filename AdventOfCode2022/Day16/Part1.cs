namespace AdventOfCode2022.Day16;

public class Part1 : BasePart
{
    public static int Run()
    {
        Start(16,1);
        var exampleInput = LoadInput(16, true);
        var input = LoadInput(16, false);
        var network = new TunnelNetwork(exampleInput);
        var shortestPaths = network.ShortestPaths();
        var timeRemaining = 30;

        var currentPosition = network.Valve("AA");
        var unOpenedValves = network.UnOpenedValves();
        var visited = new Dictionary<Valve, bool>();
        foreach (var valve in unOpenedValves)
        {
            visited.Add(valve,false);
        }

        var total = DFS(visited, currentPosition, shortestPaths, timeRemaining, 0);
        
        return 0;
    }

    private static int DFS(Dictionary<Valve,bool> visited, Valve current, Dictionary<Valve,Dictionary<Valve,int>> shortestPaths, int timeRemaining, int total)
    {
        

        return total;
    }

    private static int FlowToAdd(Dictionary<Valve, bool> visited)
    {
        var total = 0;
        foreach (var valve in visited)
        {
            if (valve.Value) total += valve.Key.FlowRate;
        }

        return total;
    }
}