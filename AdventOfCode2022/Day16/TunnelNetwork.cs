using System.Security;

namespace AdventOfCode2022.Day16;

public class TunnelNetwork
{
    public TunnelNetwork(List<string> input)
    {
        var tunnelNetwork = new Dictionary<Valve, List<string>>();
        var valveList = new List<Valve>();
        foreach (var item in input)
        {
            var items = item.Split(" ").ToList();
            var valve = new Valve(items[1],int.Parse(items[4].Substring(0,items[4].Length-1).Substring(5)));
            tunnelNetwork.Add(valve,new List<string>());
            items.RemoveRange(0,9);
            var tunnels = string.Join("",items).Split(",");
            foreach (var tunnel in tunnels)
            {
                tunnelNetwork[valve].Add(tunnel);
            }
            valveList.Add(valve);
        }

        foreach (var valve in valveList)
        {
            var tunnels = tunnelNetwork[valve];
            valve.AddTunnels(valveList.Where(v => tunnels.Contains(v.Id)));
        }
        
        Valves = valveList;
    }

    public readonly List<Valve> Valves;

    public Valve Valve(string id)
    {
        return Valves.First(v => v.Id == "AA");
    }

    public List<Valve> UnOpenedValves()
    {
        return Valves.Where(v => !v.IsOpen && v.FlowRate > 0).ToList();
    }
    
    public Dictionary<Valve,Dictionary<Valve,int>> ShortestPaths() {
        var paths = new Dictionary<Valve,Dictionary<Valve,int>>();
        foreach (var valve in Valves)
        {
            paths.Add(valve,new Dictionary<Valve,int>());
            foreach (var valve2 in Valves)
            {
                if (valve != valve2)
                {
                    paths[valve].Add(valve2,ShortestPath(valve,valve2));
                }
            }
        }
        
        return paths;
    }

    public static int ShortestPath(Valve start, Valve end)
    {
        var visited = new List<Valve>();
        var depth = new Dictionary<Valve, int>() { [start] = 0 };
        var q = new Queue<Valve>();
        
        q.Enqueue(start);

        while (q.Any())
        {
            var current = q.Dequeue();
            if (current == end) break;
            var d = depth[current];
            visited.Add(current);

            foreach (var tunnel in current.Tunnels)
            {
                if (!visited.Contains(tunnel))
                {
                    depth[tunnel] = d + 1;
                    visited.Add(tunnel);
                    q.Enqueue(tunnel);
                }
            }
        }

        return depth[end];
    }
}