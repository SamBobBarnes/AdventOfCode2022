﻿using System.Security;

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

    public List<string> UseableValves()
    {
        return Valves.Where(v => v.FlowRate > 0).Select(v => v.Id).ToList();
    }
    
    public Dictionary<string,Dictionary<string,int>> ShortestPaths() {
        var paths = new Dictionary<string,Dictionary<string,int>>();
        foreach (var valve in Valves)
        {
            paths.Add(valve.Id,new Dictionary<string,int>());
            foreach (var valve2 in Valves)
            {
                if (valve != valve2)
                {
                    paths[valve.Id].Add(valve2.Id,ShortestPath(valve,valve2));
                }
            }
        }
        
        return paths;
    }

    public static int ShortestPath(Valve start, Valve end)
    {
        var visited = new List<Valve>();
        var depth = new Dictionary<string, int>() { [start.Id] = 0 };
        var q = new Queue<Valve>();
        
        q.Enqueue(start);

        while (q.Any())
        {
            var current = q.Dequeue();
            if (current == end) break;
            var d = depth[current.Id];
            visited.Add(current);

            foreach (var tunnel in current.Tunnels)
            {
                if (!visited.Contains(tunnel))
                {
                    depth[tunnel.Id] = d + 1;
                    visited.Add(tunnel);
                    q.Enqueue(tunnel);
                }
            }
        }

        return depth[end.Id];
    }
}