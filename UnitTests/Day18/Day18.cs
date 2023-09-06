using AdventOfCode2022.Day18;

namespace UnitTests.Day18;

public class Day18
{
    [Fact]
    public void Map_Create_Grid()
    {
        var expected = new bool[3, 3, 3];
        expected[2, 2, 2] = true;
        expected[1, 1, 1] = true;
        expected[0, 0, 0] = true;

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
    public void GetOpenSides_AllOpen()
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
}