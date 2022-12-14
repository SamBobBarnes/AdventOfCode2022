using AdventOfCode2022.Day14;
using FluentAssertions;

namespace UnitTests.Day14;

public class CellTests
{
    [Fact]
    public void MoveSand_ShouldSetContentToSand()
    {
        var cell1 = new Cell(0, 0);
        var cell2 = new Cell(0, 1);
        Cell.CreateSand(cell1);
        
        Cell.MoveSand(cell1,cell2);

        cell2.PrintContent().Should().Be("*");
    }
    
    [Fact]
    public void MoveSand_ShouldSetContentToAir()
    {
        var cell1 = new Cell(0, 0);
        var cell2 = new Cell(0, 1);
        Cell.CreateSand(cell1);
        
        Cell.MoveSand(cell1,cell2);

        cell1.PrintContent().Should().Be(".");
    }
    
    [Fact]
    public void SetSource_ShouldSetContentToSource()
    {
        var cell1 = new Cell(0, 0);
        
        cell1.SetSource();

        cell1.PrintContent().Should().Be("+");
    }

    [Fact]
    public void DrawRock_ShouldSetContentToSource()
    {
        var cell1 = new Cell(0, 0);
        
        cell1.DrawRock();

        cell1.PrintContent().Should().Be("#");
    }
}