namespace AdventOfCode2022.Day16;

public class Part1 : BasePart
{
    public static int Run()
    {
        Start(16,1);
        var exampleInput = LoadInput(16, true);
        var exampleNetwork = new TunnelNetwork(exampleInput);
        var examplePathList = GetAllPaths(exampleNetwork);
        var exampleShortestPaths = exampleNetwork.ShortestPaths();
        var exampleLargest = 0;
        // foreach (var path in examplePathList)
        // {
        //     var value = GetPathValue(exampleShortestPaths, path);
        //     if (value > exampleLargest) exampleLargest = value;
        // }
        Console.WriteLine(exampleLargest);
        
        var input = LoadInput(16, false);
        var network = new TunnelNetwork(input);
        var shortestPaths = network.ShortestPaths();
        var pathList = GetAllPaths(network);
        var largest = 0;
        // foreach (var path in pathList)
        // {
        //     var value = path.GetPathValue(shortestPaths);
        //     if (value > largest) largest = value;
        // }
        return largest;
    }

    private static List<string> GetAllPaths(TunnelNetwork network)
    {
        var paths = new List<string>();
        var path = "AA";
        var routes = network.UseableValves();
        foreach (var route in routes)
        {
            var myPath = path;
            var remainingRoutes = new List<string>();
            remainingRoutes.AddRange(routes);
            remainingRoutes.Remove(route);
            myPath += $"-{route}";
            paths.AddRange(GetPaths(myPath, remainingRoutes));
        }
        
        return paths;
    }

    private static List<string> GetPaths(string path, List<string> routes)
    {
        if (!routes.Any()) return new List<string>() { path };
        var paths = new List<string>();
        foreach (var route in routes)
        {
            var myPath = path;
            var remainingRoutes = new List<string>();
            remainingRoutes.AddRange(routes);
            remainingRoutes.Remove(route);
            myPath += $"-{route}";
            paths.AddRange(GetPaths(myPath, remainingRoutes));
        }

        return paths;
    }
    
    // public static int GetPathValue(Dictionary<string,Dictionary<string,int>> shortestPaths, string path)
    // {
    //     var pathList = path.Split("-").ToList();
    //     var total = 0;
    //     var totalTime = 0;
    //     var stepsToTake = pathList.Count - 1;
    //     var current = pathList[0];
    //     pathList.RemoveAt(0);
    //     var visited = new List<string>();
    //     for (int i = 0; i < stepsToTake; i++)
    //     {
    //         var next = pathList[0];
    //         var timeTaken = CalculateMinutesForStep(shortestPaths, current, next);
    //         total += FlowToAdd(visited, timeTaken);
    //         totalTime += timeTaken;
    //         if (totalTime > 30) return 0;
    //         visited.Add(next);
    //         current = next;
    //     }
    //
    //     total += FlowToAdd(visited, 30 - totalTime);
    //
    //     return total;
    // }
    
    private static int CalculateMinutesForStep(Dictionary<string,Dictionary<string,int>> shortestPaths, string a, string b)
    {
        return shortestPaths[a][b] + 1;
    }
    
    private static int FlowToAdd(List<Valve> visited, int timeTaken)
    {
        var total = 0;
        foreach (var valve in visited)
        {
            total += valve.FlowRate;
        }
    
        return total * timeTaken;
    }
}