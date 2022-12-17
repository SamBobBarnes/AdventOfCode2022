using AdventOfCode2022.Day16;

namespace UnitTests.Day16;

public class ValveTests
{
    [Fact]
    public void ShouldInitCorrectly()
    {
        var actual = new Valve("a", 4);

        actual.Id.Should().Be("a");
        actual.FlowRate.Should().Be(4);
    }
    
    [Fact]
    public void ShouldAddTunnel()
    {
        var actual = new Valve("a", 4);
        var b = new Valve("b", 5);
        actual.AddTunnel(b);
        
        actual.Tunnels.Should().Contain(b);
    }
    
    [Fact]
    public void ShouldAddTunnels()
    {
        var actual = new Valve("a", 4);
        var b = new Valve("b", 5);
        var c = new Valve("c", 6);
        actual.AddTunnels(new List<Valve>(){b,c});

        actual.Tunnels.Count.Should().Be(2);
        actual.Tunnels.Should().Contain(b);
        actual.Tunnels.Should().Contain(c);
    }

    [Fact]
    public void ShouldFindLargestFlowTunnelWithDirectConnection()
    {
        var a = new Valve("a", 4);
        var b = new Valve("b", 5);
        var c = new Valve("c", 6);
        a.AddTunnels(new List<Valve>(){b,c});

        var actual = a.GetLargestFlow();

        actual.Should().Be(c);
    }
}