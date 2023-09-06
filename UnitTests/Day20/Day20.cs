using AdventOfCode2022.Day20;

namespace UnitTests.Day20;

public class Day20
{
    [Fact]
    public void Coordinate_Create()
    {
        var coordinate = new Coordinate(1, 0);
        
        coordinate.Value.Should().Be(1);
        coordinate.ExecutionOrder.Should().Be(0);
        coordinate.IsVisited.Should().BeFalse();
    }

    [Fact]
    public void CoordinateList_Create()
    {
        var expected = new List<Coordinate>
        {
            new(55, 0),
            new(232, 1),
            new(366, 2),
            new(334, 3),
            new(56, 4)
        };
        
        var coordinateList = new CoordinateList(new List<string> {"55", "232", "366", "334", "56"});

        coordinateList.Coordinates.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void CoordinateList_Mix_MoveWithinList()
    {
        var coordinateList = new CoordinateList(new List<string> {"3", "-1", "3", "8", "-12"});
        
        coordinateList.Mix(0);
        
        coordinateList.Coordinates[0].Value.Should().Be(-1);
        coordinateList.Coordinates[1].Value.Should().Be(3);
        coordinateList.Coordinates[2].Value.Should().Be(8);
        coordinateList.Coordinates[3].Value.Should().Be(3);
        coordinateList.Coordinates[4].Value.Should().Be(-12);
        coordinateList.Coordinates[3].IsVisited.Should().BeTrue();
    }

    [Fact]
    public void CoordinateList_Mix_MoveBackwardsWithinList()
    {
        var coordinateList = new CoordinateList(new List<string> {"3", "-1", "3", "8", "-12"});
        
        coordinateList.Mix(1);
        
        coordinateList.Coordinates[0].Value.Should().Be(-1);
        coordinateList.Coordinates[1].Value.Should().Be(3);
        coordinateList.Coordinates[2].Value.Should().Be(3);
        coordinateList.Coordinates[3].Value.Should().Be(8);
        coordinateList.Coordinates[4].Value.Should().Be(-12);
        coordinateList.Coordinates[0].IsVisited.Should().BeTrue();
    }

    [Fact]
    public void CoordinateList_Mix_MoveAroundList()
    {
        var coordinateList = new CoordinateList(new List<string> {"4", "-1", "3", "8", "-12"});
        
        coordinateList.Mix(2);
        
        coordinateList.Coordinates[0].Value.Should().Be(4);
        coordinateList.Coordinates[1].Value.Should().Be(3);
        coordinateList.Coordinates[2].Value.Should().Be(-1);
        coordinateList.Coordinates[3].Value.Should().Be(8);
        coordinateList.Coordinates[4].Value.Should().Be(-12);
        coordinateList.Coordinates[1].IsVisited.Should().BeTrue();
    }

    [Fact]
    public void CoordinateList_Mix_MoveBackwardsAroundList()
    {
        var coordinateList = new CoordinateList(new List<string> {"4", "-1", "3", "8", "-6"});
        
        coordinateList.Mix(4);
        
        coordinateList.Coordinates[0].Value.Should().Be(4);
        coordinateList.Coordinates[1].Value.Should().Be(-1);
        coordinateList.Coordinates[2].Value.Should().Be(-6);
        coordinateList.Coordinates[3].Value.Should().Be(3);
        coordinateList.Coordinates[4].Value.Should().Be(8);
        coordinateList.Coordinates[2].IsVisited.Should().BeTrue();
    }

    [Fact]
    public void CoordinateList_MixAll_Example()
    {
        var input = new List<string> {"1", "2", "-3", "3", "-2", "0", "4"};
        
        var coordinateList = new CoordinateList(input);
        
        coordinateList.MixAll();

        coordinateList.Coordinates[0].Value.Should().Be(-2);
        coordinateList.Coordinates[1].Value.Should().Be(1);
        coordinateList.Coordinates[2].Value.Should().Be(2);
        coordinateList.Coordinates[3].Value.Should().Be(-3);
        coordinateList.Coordinates[4].Value.Should().Be(4);
        coordinateList.Coordinates[5].Value.Should().Be(0);
        coordinateList.Coordinates[6].Value.Should().Be(3);
    }

    [Fact]
    public void CoordinateList_FindIndexFromZero()
    {
        var input = new List<string> {"1", "2", "-3", "3", "-2", "0", "4"};
        
        var coordinateList = new CoordinateList(input);
        
        coordinateList.MixAll();
        
        coordinateList.FindIndexFromZero(1000).Should().Be(4);
        coordinateList.FindIndexFromZero(2000).Should().Be(-3);
        coordinateList.FindIndexFromZero(3000).Should().Be(2);
    }
}