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
        TimeRemaining = 30;
        CurrentPosition = Valves.First(v => v.Id == "AA");
    }

    public Valve CurrentPosition;
    public int TimeRemaining;
    public readonly List<Valve> Valves;

    public Valve GetLargestFlowValve()
    {
        return GetLargestFlowValveRecursive(CurrentPosition, new(){});
    }

    private Valve GetLargestFlowValveRecursive(Valve current, List<Valve> visited)
    {
        visited.Add(current);
        var valve = current.GetLargestFlow();
        if (valve == null)
        {
            foreach (var tunnel in current.Tunnels.Where(v => !visited.Contains(v)))
            {
                valve = GetLargestFlowValveRecursive(tunnel,visited);
                if (valve != null) break;
            }
        } 
        return valve;
    }
}