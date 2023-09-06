using AdventOfCode2022.Day18;

namespace UnitTests.Day18;

public class Day18
{
    [Fact]
    public void Map_Create()
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
}