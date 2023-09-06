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
        expected[0].Right = expected[1];
        expected[0].Left = expected[4];
        expected[1].Right = expected[2];
        expected[1].Left = expected[0];
        expected[2].Right = expected[3];
        expected[2].Left = expected[1];
        expected[3].Right = expected[4];
        expected[3].Left = expected[2];
        expected[4].Right = expected[0];
        expected[4].Left = expected[3];
        
        var coordinateList = new CoordinateList(new List<string> {"55", "232", "366", "334", "56"});
        
        coordinateList.Coordinates[0].Left.Value.Should().Be(56);
        coordinateList.Coordinates[0].Right.Value.Should().Be(232);
        coordinateList.Coordinates[1].Left.Value.Should().Be(55);
        coordinateList.Coordinates[1].Right.Value.Should().Be(366);
        coordinateList.Coordinates[2].Left.Value.Should().Be(232);
        coordinateList.Coordinates[2].Right.Value.Should().Be(334);
        coordinateList.Coordinates[3].Left.Value.Should().Be(366);
        coordinateList.Coordinates[3].Right.Value.Should().Be(56);
        coordinateList.Coordinates[4].Left.Value.Should().Be(334);
        coordinateList.Coordinates[4].Right.Value.Should().Be(55);
        coordinateList.Coordinates[0].ExecutionOrder.Should().Be(0);
        coordinateList.Coordinates[1].ExecutionOrder.Should().Be(1);
        coordinateList.Coordinates[2].ExecutionOrder.Should().Be(2);
        coordinateList.Coordinates[3].ExecutionOrder.Should().Be(3);
        coordinateList.Coordinates[4].ExecutionOrder.Should().Be(4);
        coordinateList.Coordinates[0].Value.Should().Be(55);
        coordinateList.Coordinates[1].Value.Should().Be(232);
        coordinateList.Coordinates[2].Value.Should().Be(366);
        coordinateList.Coordinates[3].Value.Should().Be(334);
        coordinateList.Coordinates[4].Value.Should().Be(56);
        
    }
}