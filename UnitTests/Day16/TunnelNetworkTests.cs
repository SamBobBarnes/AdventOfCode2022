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
    public void ShouldFindAllShortestPathsFromA()
    {

        var input = new List<string>()
        {
            "Valve AA has flow rate=0; tunnels lead to valves DD, II, BB",
            "Valve BB has flow rate=13; tunnels lead to valves CC, AA",
            "Valve CC has flow rate=2; tunnels lead to valves DD, BB",
            "Valve DD has flow rate=20; tunnels lead to valves CC, AA, EE",
            "Valve EE has flow rate=3; tunnels lead to valves FF, DD",
            "Valve FF has flow rate=0; tunnels lead to valves EE, GG",
            "Valve GG has flow rate=0; tunnels lead to valves FF, HH",
            "Valve HH has flow rate=22; tunnel leads to valve GG",
            "Valve II has flow rate=0; tunnels lead to valves AA, JJ",
            "Valve JJ has flow rate=21; tunnel leads to valve II"
        };

        var network = new TunnelNetwork(input);
        var a = network.Valves[0];
        var d = a.Tunnels[1];
        var b = a.Tunnels[0];
        var i = a.Tunnels[2];
        var j = i.Tunnels[1];
        var c = d.Tunnels[1];
        var e = d.Tunnels[2];
        var f = e.Tunnels[1];
        var g = f.Tunnels[1];
        var h = g.Tunnels[1];
        
        var actual = TunnelNetwork.ShortestPath(a, b);
        actual.Should().Be(1);
        actual = TunnelNetwork.ShortestPath(a, c);
        actual.Should().Be(2);
        actual = TunnelNetwork.ShortestPath(a, d);
        actual.Should().Be(1);
        actual = TunnelNetwork.ShortestPath(a, e);
        actual.Should().Be(2);
        actual = TunnelNetwork.ShortestPath(a, f);
        actual.Should().Be(3);
        actual = TunnelNetwork.ShortestPath(a, g);
        actual.Should().Be(4);
        actual = TunnelNetwork.ShortestPath(a, h);
        actual.Should().Be(5);
        actual = TunnelNetwork.ShortestPath(a, i);
        actual.Should().Be(1);
        actual = TunnelNetwork.ShortestPath(a, j);
        actual.Should().Be(2); 
    }
    
    [Fact]
    public void ShouldFindAllShortestPathsFromAllPoints()
    {
        var input = new List<string>()
        {
            "Valve AA has flow rate=0; tunnels lead to valves DD, II, BB",
            "Valve BB has flow rate=13; tunnels lead to valves CC, AA",
            "Valve CC has flow rate=2; tunnels lead to valves DD, BB",
            "Valve DD has flow rate=20; tunnels lead to valves CC, AA, EE",
            "Valve EE has flow rate=3; tunnels lead to valves FF, DD",
            "Valve FF has flow rate=0; tunnels lead to valves EE, GG",
            "Valve GG has flow rate=0; tunnels lead to valves FF, HH",
            "Valve HH has flow rate=22; tunnel leads to valve GG",
            "Valve II has flow rate=0; tunnels lead to valves AA, JJ",
            "Valve JJ has flow rate=21; tunnel leads to valve II"
        };

        var network = new TunnelNetwork(input);
        var a = network.Valves[0];
        var d = a.Tunnels[1];
        var b = a.Tunnels[0];
        var i = a.Tunnels[2];
        var j = i.Tunnels[1];
        var c = d.Tunnels[1];
        var e = d.Tunnels[2];
        var f = e.Tunnels[1];
        var g = f.Tunnels[1];
        var h = g.Tunnels[1];
        
        var expected = new Dictionary<Valve,Dictionary<Valve,int>>()
        {
            {
                a, 
                new()
                {
                    {b,1}, {c,2}, {d,1}, {e,2}, {f,3}, {g,4}, {h,5}, {i,1}, {j,2}
                }
            },
            {
                b, 
                new()
                {
                    {a,1}, {c,1}, {d,2}, {e,3}, {f,4}, {g,5}, {h,6}, {i,2}, {j,3}
                }
            },
            {
                c, 
                new()
                {
                    {a,2}, {b,1}, {d,1}, {e,2}, {f,3}, {g,4}, {h,5}, {i,3}, {j,4}
                }
            },
            {
                d, 
                new()
                {
                    {a,1}, {b,2}, {c,1}, {e,1}, {f,2}, {g,3}, {h,4}, {i,2}, {j,3}
                }
            },
            {
                e, 
                new()
                {
                    {a,2}, {b,3}, {c,2}, {d,1}, {f,1}, {g,2}, {h,3}, {i,3}, {j,4}
                }
            },
            {
                f, 
                new()
                {
                    {a,3}, {b,4}, {c,3}, {d,2}, {e,1}, {g,1}, {h,2}, {i,4}, {j,5}
                }
            },
            {
                g, 
                new()
                {
                    {a,4}, {b,5}, {c,4}, {d,3}, {e,2}, {f,1}, {h,1}, {i,5}, {j,6}
                }
            },
            {
                h, 
                new()
                {
                    {a,5}, {b,6}, {c,5}, {d,4}, {e,3}, {f,2}, {g,1}, {i,6}, {j,7}
                }
            },
            {
                i, 
                new()
                {
                    {a,1}, {b,2}, {c,3}, {d,2}, {e,3}, {f,4}, {g,5}, {h,6}, {j,1}
                }
            },
            {
                j, 
                new()
                {
                    {a,2}, {b,3}, {c,4}, {d,3}, {e,4}, {f,5}, {g,6}, {h,7}, {i,1}
                }
            },
        };
        
        var actual = network.ShortestPaths();

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void ShouldReturnAllUnOpenedValvesWithValueOfMoreThanZero()
    {
        var input = new List<string>()
        {
            "Valve AA has flow rate=0; tunnels lead to valves DD, II, BB",
            "Valve BB has flow rate=13; tunnels lead to valves CC, AA",
            "Valve CC has flow rate=2; tunnels lead to valves DD, BB",
            "Valve DD has flow rate=20; tunnels lead to valves CC, AA, EE",
            "Valve EE has flow rate=3; tunnels lead to valves FF, DD",
            "Valve FF has flow rate=0; tunnels lead to valves EE, GG",
            "Valve GG has flow rate=0; tunnels lead to valves FF, HH",
            "Valve HH has flow rate=22; tunnel leads to valve GG",
            "Valve II has flow rate=0; tunnels lead to valves AA, JJ",
            "Valve JJ has flow rate=21; tunnel leads to valve II"
        };

        var network = new TunnelNetwork(input);
        var a = network.Valves[0];
        var d = a.Tunnels[1];
        var b = a.Tunnels[0];
        var i = a.Tunnels[2];
        var j = i.Tunnels[1];
        var c = d.Tunnels[1];
        var e = d.Tunnels[2];
        var f = e.Tunnels[1];
        var g = f.Tunnels[1];
        var h = g.Tunnels[1];
        
        j.OpenValve();
        
        var expected = new List<Valve>()
        {
            b, c, d, e, h
        };
        
        var actual = network.UnOpenedValves();

        actual.Should().BeEquivalentTo(expected);
    }
}