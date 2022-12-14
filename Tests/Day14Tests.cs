using AdventOfCode2022.Day14;
using FluentAssertions;
using Xunit;

namespace Tests;

public class Day14Tests
{
    [Fact]
    public void CoordinateBetween_ShouldFindCoordinateBetweenTwoPoints()
    {
        var a = new Coordinate(0, 0);
        var b = new Coordinate(0, 2);
        var c = new Coordinate(0, 1);

        var actual = Coordinate.Between(a, b, c);

        actual.Should().BeTrue();
    }
}
