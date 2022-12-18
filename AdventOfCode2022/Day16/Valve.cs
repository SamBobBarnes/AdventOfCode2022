namespace AdventOfCode2022.Day16;

public class Valve
{
    public Valve(string id, int flow)
    {
        Id = id;
        FlowRate = flow;
        _tunnelsTo = new List<Valve>();
    }

    public readonly string Id;
    public readonly int FlowRate;
    private IEnumerable<Valve> _tunnelsTo;
    public List<Valve> Tunnels => _tunnelsTo.ToList();

    public void AddTunnel(Valve tunnel)
    {
        var temp = _tunnelsTo.ToList();
        temp.Add(tunnel);
        _tunnelsTo = temp;
    }

    public void AddTunnels(IEnumerable<Valve> tunnels)
    {
        var temp = _tunnelsTo.ToList();
        temp.AddRange(tunnels);
        _tunnelsTo = temp;
    }

    public new string ToString()
    {
        return $"{Id}: {FlowRate}";
    }
}