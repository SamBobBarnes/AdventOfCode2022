using System.Drawing;
using AdventOfCode2022.Day22;

namespace UnitTests.Day22;

public class RoomTests
{
    [Fact]
    public void Room_InitializeDirections()
    {
        var input = new List<string> { "map", "", "10R5L5R10L4R5L5" };
        
        var expectedSteps = new[] { 10, 5, 5, 10, 4, 5, 5 };
        var expectedRotations = new[] { 'R', 'L', 'R', 'L', 'R', 'L' };

        var actual = new Room(input);

        actual.Steps.Should().BeEquivalentTo(expectedSteps);
        actual.Steps.SequenceEqual(expectedSteps).Should().BeTrue();
        actual.Rotations.Should().BeEquivalentTo(expectedRotations);
        actual.Rotations.SequenceEqual(expectedRotations).Should().BeTrue();
    }

    [Fact]
    public void Room_InitializeMap()
    {
        var input = new List<string>
        {
            "        ...#",
            "        .#..",
            "        #...",
            "        ....",
            "...#.......#",
            "........#...",
            "..#....#....",
            "..........#.",
            "        ...#....",
            "        .....#..",
            "        .#......",
            "        ......#.", 
            "", 
            "10R5L5R10L4R5L5"
        };

        var expectedMap = new Tiles[,]
        {
            {Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall},
            {Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall},
            {Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Wall,Tiles.Floor,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall},
            {Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall},
            {Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall},
            {Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall},
            {Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall},
            {Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Wall,Tiles.Floor,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall},
            {Tiles.Floor,Tiles.Floor,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor},
            {Tiles.Floor,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Wall,Tiles.Floor},
            {Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor},
            {Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Floor},
            {Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor},
            {Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Floor,Tiles.Wall,Tiles.Floor,Tiles.Floor},
            {Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Wall},
            {Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor},
        };
        
        var actual = new Room(input);
        
        for(int i = 0; i < actual.Grid.GetLength(0); i++)
        {
            for(int j = 0; j < actual.Grid.GetLength(1); j++)
            {
                actual.Grid[i, j].Should().Be(expectedMap[i, j]);
            }
        }
    }

    [Fact]
    public void Room_InitializeCharacter()
    {
        var input = new List<string>
        {
            "        ...#",
            "        .#..",
            "        #...",
            "        ....",
            "...#.......#",
            "........#...",
            "..#....#....",
            "..........#.",
            "        ...#....",
            "        .....#..",
            "        .#......",
            "        ......#.", 
            "", 
            "10R5L5R10L4R5L5"
        };

        var actual = new Room(input);
        
        actual.Position.Should().BeEquivalentTo(new Point(8, 0));
        actual.Facing.Should().Be(Direction.Right);
    }
}