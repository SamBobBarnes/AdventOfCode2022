using AdventOfCode2022.Day15;
using FluentAssertions;

namespace UnitTests.Day15;

public class CoordinateTests
{
    [Fact]
    public void ManhattanDistance_ShouldReturnZeroIfPointsArTheSame()
    {
        var a = new Coordinate(5, 5);
        var b = new Coordinate(5, 5);

        var actual1 = a.ManhattanDistance(b);
        var actual2 = a.ManhattanDistance(b.X,b.Y);

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
        

        var actual1 = a.ManhattanDistance(b);
        var actual2 = c.ManhattanDistance(d);
        var actual3 = c.ManhattanDistance(d.X,d.Y);
        
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

        var actual1 = a.ManhattanDistance(b);
        var actual2 = c.ManhattanDistance(d);
        var actual3 = c.ManhattanDistance(d.X,d.Y);

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

        var actual1 = a.ManhattanDistance(b);
        var actual2 = c.ManhattanDistance(d);
        var actual3 = c.ManhattanDistance(d.X,d.Y);

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

        var actual1 = a.ManhattanDistance(b);
        var actual2 = c.ManhattanDistance(d);
        var actual3 = c.ManhattanDistance(d.X,d.Y);

        actual1.Should().Be(8);
        actual2.Should().Be(12);
        actual3.Should().Be(12);
    }

    [Fact]
    public void ManhattanBorder_ShouldReturnCorrectManhattanBorder()
    {
        var a = new Coordinate(0, 0);
        var range = 5;

        var expected = new List<Coordinate>
        {
            new(0, 6),
            new(1,5),
            new(2,4),
            new(3,3),
            new(4,2),
            new(5,1),
            new(6, 0),
            new(5,-1),
            new(4,-2),
            new(3,-3),
            new(2,-4),
            new(1,-5),
            new(0, -6),
            new(-1,-5),
            new(-2,-4),
            new(-3,-3),
            new(-4,-2),
            new(-5,-1),
            new(-6, 0),
            new(-5,1),
            new(-4,2),
            new(-3,3),
            new(-2,4),
            new(-1,5),
        };
        
        var actual = a.ManhattanBorder(range);

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void WithinRange_ShouldReturnTrueIfXYIsWithinRange()
    {
        var a = new Coordinate(0, 0);

        var actual = a.WithinRange(2, 2, 5);

        actual.Should().BeTrue();
    }
    
    [Fact]
    public void WithinRange_ShouldReturnFalseIfXYIsNotWithinRange()
    {
        var a = new Coordinate(0, 0);

        var actual = a.WithinRange(5, 3, 5);

        actual.Should().BeFalse();
    }
}