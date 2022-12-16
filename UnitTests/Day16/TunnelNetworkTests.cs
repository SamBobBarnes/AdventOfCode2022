using AdventOfCode2022.Day16;
using FluentAssertions;

namespace UnitTests.Day16;

public class TunnelNetworkTests
{
    [Fact]
    public void ShouldInitCorrectly()
    {
        var a = new Valve("AA", 4);
        var b = new Valve("BB", 5);
        var c = new Valve("CC", 2);
        var d = new Valve("DD", 6);
        a.AddTunnel(b);
        b.AddTunnel(a);
        c.AddTunnels(new List<Valve>(){a,b});
        d.AddTunnel(a);

        var input = new List<string>() {
            "Valve BB has flow rate=5; tunnels lead to valves AA",
            "Valve AA has flow rate=4; tunnels lead to valves BB",
            "Valve CC has flow rate=2; tunnels lead to valves AA, BB",
            "Valve DD has flow rate=6; tunnels lead to valves AA"
        };

        var actual = new TunnelNetwork(input);

        actual.CurrentPosition.Id.Should().Be("AA");
        
        actual.Valves[0].Id.Should().Be("BB");
        actual.Valves[0].FlowRate.Should().Be(5);
        actual.Valves[0].Tunnels[0].Id.Should().Be("AA");
        actual.Valves[1].Id.Should().Be("AA");
        actual.Valves[1].FlowRate.Should().Be(4);
        actual.Valves[1].Tunnels[0].Id.Should().Be("BB");
        actual.Valves[2].Id.Should().Be("CC");
        actual.Valves[2].FlowRate.Should().Be(2);
        actual.Valves[2].Tunnels[0].Id.Should().Be("BB");
        actual.Valves[2].Tunnels[1].Id.Should().Be("AA");
        actual.Valves[3].Id.Should().Be("DD");
        actual.Valves[3].FlowRate.Should().Be(6);
        actual.Valves[3].Tunnels[0].Id.Should().Be("AA");
        
    }

    [Fact]
    public void ShouldFindLargestFlowValveFromCurrentPosition()
    {
        var input = new List<string>() {
            "Valve BB has flow rate=0; tunnels lead to valves AA, CC",
            "Valve CC has flow rate=4; tunnels lead to valves BB",
            "Valve EE has flow rate=5; tunnels lead to valves DD",
            "Valve AA has flow rate=2; tunnels lead to valves BB, DD",
            "Valve DD has flow rate=6; tunnels lead to valves AA, EE"
        };

        var network = new TunnelNetwork(input);
        network.CurrentPosition.Tunnels[1].OpenValve();

        var actual = network.GetLargestFlowValve();

        actual.Id.Should().Be("EE");
    }
}