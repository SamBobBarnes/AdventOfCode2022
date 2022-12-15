using AdventOfCode2022.Day15;
using FluentAssertions;

namespace UnitTests.Day_15;

public class CoordinateTests
{
    [Fact]
    public void ManhattanDistance_ShouldReturnZeroIfPointsArTheSame()
    {
        var a = new Coordinate(5, 5);
        var b = new Coordinate(5, 5);

        var actual1 = Coordinate.ManhattanDistance(a, b);
        var actual2 = Coordinate.ManhattanDistance(a, b.X,b.Y);

        actual1.Should().Be(0);
        actual2.Should().Be(0);
    }
    
    [Fact]
    public void ManhattanDistance_ShouldReturnManhattanDistanceBetweenAAndB_Quadrant1()
    {
        var a = new Coordinate(5, 5);
        var b = new Coordinate(10, 8);
        var c = new Coordinate(0, 0);
        var d = new Coordinate(10, 8);
        

        var actual1 = Coordinate.ManhattanDistance(a, b);
        var actual2 = Coordinate.ManhattanDistance(c, d);
        var actual3 = Coordinate.ManhattanDistance(c, d.X,d.Y);
        
        actual1.Should().Be(8);
        actual2.Should().Be(18);
        actual3.Should().Be(18);
    }
    
    [Fact]
    public void ManhattanDistance_ShouldReturnManhattanDistanceBetweenAAndB_Quadrant2()
    {
        var a = new Coordinate(5, 5);
        var b = new Coordinate(10, 2);
        var c = new Coordinate(0, 0);
        var d = new Coordinate(10, -2);

        var actual1 = Coordinate.ManhattanDistance(a, b);
        var actual2 = Coordinate.ManhattanDistance(c, d);
        var actual3 = Coordinate.ManhattanDistance(c, d.X,d.Y);

        actual1.Should().Be(8);
        actual2.Should().Be(12);
        actual3.Should().Be(12);
    }
    
    [Fact]
    public void ManhattanDistance_ShouldReturnManhattanDistanceBetweenAAndB_Quadrant3()
    {
        var a = new Coordinate(5, 5);
        var b = new Coordinate(0, 2);
        var c = new Coordinate(0, 0);
        var d = new Coordinate(-10, -2);

        var actual1 = Coordinate.ManhattanDistance(a, b);
        var actual2 = Coordinate.ManhattanDistance(c, d);
        var actual3 = Coordinate.ManhattanDistance(c, d.X,d.Y);

        actual1.Should().Be(8);
        actual2.Should().Be(12);
        actual3.Should().Be(12);
    }
    
    [Fact]
    public void ManhattanDistance_ShouldReturnManhattanDistanceBetweenAAndB_Quadrant4()
    {
        var a = new Coordinate(5, 5);
        var b = new Coordinate(0, 8);
        var c = new Coordinate(0, 0);
        var d = new Coordinate(-10, 2);

        var actual1 = Coordinate.ManhattanDistance(a, b);
        var actual2 = Coordinate.ManhattanDistance(c, d);
        var actual3 = Coordinate.ManhattanDistance(c, d.X,d.Y);

        actual1.Should().Be(8);
        actual2.Should().Be(12);
        actual3.Should().Be(12);
    }

    [Fact]
    public void MahattanRange_ShouldReturnSelfIfRangeIsZero()
    {
        var expected = new List<Coordinate>() { new(5, 5) };
        var a = new Coordinate(5, 5);
        var beacon = new Coordinate(0, 0);
        var range = 0;

        var actual = a.ManhattanRange(beacon,range);

        actual.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void MahattanRange_ShouldReturnCorrectListForRanges()
    {
        var expected = new List<Coordinate>
        {
            new(0,0),
            new(0,1), new(0,2), new(0,3), new(0,4),// new(0,5),
            new(0,-1), new(0,-2), new(0,-3), new(0,-4), new(0,-5),
            new(1,0), new(2,0), new(3,0), new(4,0), new(5,0),
            new(-1,0), new(-2,0), new(-3,0), new(-4,0), new(-5,0),
            new(1,1), new(1,2), new(1,3), new(1,4), new(2,1), new(2,2), new(2,3), new(3,1), new(3,2), new(4,1),
            new(1,-1), new(1,-2), new(1,-3), new(1,-4), new(2,-1), new(2,-2), new(2,-3), new(3,-1), new(3,-2), new(4,-1),
            new(-1,1), new(-1,2), new(-1,3), new(-1,4), new(-2,1), new(-2,2), new(-2,3), new(-3,1), new(-3,2), new(-4,1),
            new(-1,-1), new(-1,-2), new(-1,-3), new(-1,-4), new(-2,-1), new(-2,-2), new(-2,-3), new(-3,-1), new(-3,-2), new(-4,-1),
        };
        
        var a = new Coordinate(0, 0);
        var beacon = new Coordinate(0, 5);
        var range = 5;

        var actual = a.ManhattanRange(beacon,range);

        actual.Should().BeEquivalentTo(expected);
    }
}