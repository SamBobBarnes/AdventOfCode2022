using AdventOfCode2022.Day18;

namespace UnitTests.Day18;

public class Day18
{
    [Fact]
    public void Map_Create_Grid()
    {
        var expected = new int[3, 3, 3];
        expected[2, 2, 2] = 1;
        expected[1, 1, 1] = 1;
        expected[0, 0, 0] = 1;
        expected[0, 0, 1] = 2;
        expected[0, 0, 2] = 2;
        expected[0, 1, 0] = 2;
        expected[0, 1, 1] = 2;
        expected[0, 1, 2] = 2;
        expected[0, 2, 0] = 2;
        expected[0, 2, 1] = 2;
        expected[0, 2, 2] = 2;
        expected[1, 0, 0] = 2;
        expected[1, 0, 1] = 2;
        expected[1, 0, 2] = 2;
        expected[1, 1, 0] = 2;
        expected[1, 1, 2] = 2;
        expected[1, 2, 0] = 2;
        expected[1, 2, 1] = 2;
        expected[1, 2, 2] = 2;
        expected[2, 0, 0] = 2;
        expected[2, 0, 1] = 2;
        expected[2, 0, 2] = 2;
        expected[2, 1, 0] = 2;
        expected[2, 1, 1] = 2;
        expected[2, 1, 2] = 2;
        expected[2, 2, 0] = 2;
        expected[2, 2, 1] = 2;

        var input = new List<string>
        {
            "2,2,2",
            "0,0,0",
            "1,1,1"
        };
        
        var map = new Map(input);

        map.Grid.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void Map_Create_Cubes()
    {
        var expected = new List<Cube>
        {
            new (2,2,2),
            new (1,1,1),
            new (0,0,0),
        };

        var input = new List<string>
        {
            "2,2,2",
            "0,0,0",
            "1,1,1"
        };
        
        var map = new Map(input);

        map.Cubes.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Map_GetOpenSides_AllOpen()
    {
        var input = new List<string>
        {
            "2,2,2",
            "0,0,0",
            "1,1,1"
        };

        var map = new Map(input);

        var actual = map.GetOpenSides();

        actual.Should().Be(18);
    }

    [Fact]
    public void Map_GetOpenToAirSides_ClosedBox()
    {
        var input = new List<string>
        {
            "0,1,1",
            "2,1,1",
            "1,0,1",
            "1,2,1",
            "1,1,0",
            "1,1,2",
        };

        var map = new Map(input);

        var actual = map.GetOpenToAirSides();

        actual.Should().Be(30);
    }

    [Fact]
    public void Map_GetOpenToAirSides_Cone()
    {
        var input = new List<string>
        {
            "0,1,1",
            "2,1,1",
            "1,0,1",
            "1,2,1",
            "1,1,0",
        };

        var map = new Map(input);

        var actual = map.GetOpenToAirSides();

        actual.Should().Be(30);
    }
}