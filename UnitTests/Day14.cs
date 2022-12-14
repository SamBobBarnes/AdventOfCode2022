using AdventOfCode2022.Day14;
using FluentAssertions;
using System.Runtime.CompilerServices;

namespace UnitTests;

public class Day14
{
    [Fact]
    public void CoordinateBetween_ShouldReturnTrueIfCIsBetweenAAndBYAxis()
    {
        var a = new Coordinate(0, 0);
        var b = new Coordinate(0, 2);
        var c = new Coordinate(0, 1);

        var actual = Coordinate.Between(a, b, c);

        actual.Should().BeTrue();
    }

    [Fact]
    public void CoordinateBetween_ShouldReturnTrueIfCIsBetweenAAndBYAxisAHigh()
    {
        var a = new Coordinate(0, 2);
        var b = new Coordinate(0, 0);
        var c = new Coordinate(0, 1);

        var actual = Coordinate.Between(a, b, c);

        actual.Should().BeTrue();
    }

    [Fact]
    public void CoordinateBetween_ShouldReturnTrueIfCIsAYAxis()
    {
        var a = new Coordinate(0, 0);
        var b = new Coordinate(0, 2);
        var c = new Coordinate(0, 0);

        var actual = Coordinate.Between(a, b, c);

        actual.Should().BeTrue();
    }

    [Fact]
    public void CoordinateBetween_ShouldReturnTrueIfCIsBYAxis()
    {
        var a = new Coordinate(0, 0);
        var b = new Coordinate(0, 2);
        var c = new Coordinate(0, 2);

        var actual = Coordinate.Between(a, b, c);

        actual.Should().BeTrue();
    }

    [Fact]
    public void CoordinateBetween_ShouldReturnTrueIfCIsBetweenAAndBXAxis()
    {
        var a = new Coordinate(0, 0);
        var b = new Coordinate(2, 0);
        var c = new Coordinate(1, 0);

        var actual = Coordinate.Between(a, b, c);

        actual.Should().BeTrue();
    }

    [Fact]
    public void CoordinateBetween_ShouldReturnTrueIfCIsBetweenAAndBXAxisAHigh()
    {
        var a = new Coordinate(2, 0);
        var b = new Coordinate(1, 0);
        var c = new Coordinate(1, 0);

        var actual = Coordinate.Between(a, b, c);

        actual.Should().BeTrue();
    }

    [Fact]
    public void CoordinateBetween_ShouldReturnTrueIfCIsAXAxis()
    {
        var a = new Coordinate(0, 0);
        var b = new Coordinate(2, 0);
        var c = new Coordinate(0, 0);

        var actual = Coordinate.Between(a, b, c);

        actual.Should().BeTrue();
    }

    [Fact]
    public void CoordinateBetween_ShouldReturnTrueIfCIsBXAxis()
    {
        var a = new Coordinate(0, 0);
        var b = new Coordinate(2, 0);
        var c = new Coordinate(2, 0);

        var actual = Coordinate.Between(a, b, c);

        actual.Should().BeTrue();
    }

    [Fact]
    public void CoordinateBetween_ShouldReturnFalseIfCIsNotBetweenAAndBXAxis()
    {
        var a = new Coordinate(0, 0);
        var b = new Coordinate(2, 0);
        var c = new Coordinate(3, 0);

        var actual = Coordinate.Between(a, b, c);

        actual.Should().BeFalse();
    }

    [Fact]
    public void CoordinateBetween_ShouldReturnFalseIfCIsNotBetweenAAndBYAxis()
    {
        var a = new Coordinate(0, 0);
        var b = new Coordinate(0, 2);
        var c = new Coordinate(0, 3);

        var actual = Coordinate.Between(a, b, c);

        actual.Should().BeFalse();
    }

    [Fact]
    public void CoordinateBetween_ShouldReturnFalseIfCIsNotOnAxisOfAAndB()
    {
        var a1 = new Coordinate(0, 0);
        var b1 = new Coordinate(0, 2);
        var c1 = new Coordinate(1, 1);
        var a2 = new Coordinate(0, 0);
        var b2 = new Coordinate(2, 0);
        var c2 = new Coordinate(1, 1);

        var actual1 = Coordinate.Between(a1, b1, c1);
        var actual2 = Coordinate.Between(a2, b2, c2);

        actual1.Should().BeFalse();
        actual2.Should().BeFalse();
    }

    [Fact]
    public void CoordinateBetwen_ShouldThrowExceptionWhenNoCommonAxis()
    {
        var a = new Coordinate(0, 0);
        var b = new Coordinate(2, 2);
        var c = new Coordinate(1, 3);

        Action act = () => Coordinate.Between(a, b, c);

        act.Should()
            .Throw<InvalidOperationException>()
            .WithMessage("A and B must have a common axis.");
    }
}