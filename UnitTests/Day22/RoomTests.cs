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
            {Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound},
            {Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound},
            {Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Floor,Tiles.Floor,Tiles.Wall,Tiles.Floor,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound},
            {Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound},
            {Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound},
            {Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound},
            {Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound},
            {Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Floor,Tiles.Floor,Tiles.Wall,Tiles.Floor,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound},
            {Tiles.Floor,Tiles.Floor,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor},
            {Tiles.Floor,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Wall,Tiles.Floor},
            {Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor},
            {Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Wall,Tiles.Floor,Tiles.Floor,Tiles.Floor},
            {Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor},
            {Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Floor,Tiles.Wall,Tiles.Floor,Tiles.Floor},
            {Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Wall},
            {Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Rebound,Tiles.Floor,Tiles.Floor,Tiles.Floor,Tiles.Floor},
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

    #region MoveCharacter

    #region WithoutObstruction

    [Fact]
    public void Room_MoveCharacter_WithoutObstruction_Right()
    {
        var input = new List<string>
        {
            ".............",
            "", 
            "10R1"
        };
        
        var actual = new Room(input);
        actual.MoveCharacter();
        actual.Position.Should().BeEquivalentTo(new Point(10, 0));
    }

    [Fact]
    public void Room_MoveCharacter_WithoutObstruction_Left()
    {
        var input = new List<string>
        {
            ".............",
            "", 
            "10R1"
        };
        
        var actual = new Room(input);
        actual.Position = new Point(12, 0);
        actual.Facing = Direction.Left;
        actual.MoveCharacter();
        actual.Position.Should().BeEquivalentTo(new Point(2, 0));
    }

    [Fact]
    public void Room_MoveCharacter_WithoutObstruction_Down()
    {
        var input = new List<string>
        {
            ".............",
            ".............",
            ".............",
            ".............",
            ".............",
            "", 
            "3R1"
        };
        
        var actual = new Room(input);
        actual.Facing = Direction.Down;
        actual.MoveCharacter();
        actual.Position.Should().BeEquivalentTo(new Point(0, 3));
    }

    [Fact]
    public void Room_MoveCharacter_WithoutObstruction_Up()
    {
        var input = new List<string>
        {
            ".............",
            ".............",
            ".............",
            ".............",
            ".............",
            "", 
            "3R1"
        };
        
        var actual = new Room(input);
        actual.Position = new Point(0, 4);
        actual.Facing = Direction.Up;
        actual.MoveCharacter();
        actual.Position.Should().BeEquivalentTo(new Point(0, 1));
    }

    #endregion
    
    #region WithObstruction

    [Fact]
    public void Room_MoveCharacter_WithObstruction()
    {
        var input = new List<string>
        {
            "........#....",
            "", 
            "10R"
        };
        
        var actual = new Room(input);
        actual.MoveCharacter();
        actual.Position.Should().BeEquivalentTo(new Point(7, 0));
    }
    
    #endregion

    #region Rebound
    
    [Fact]
    public void Room_MoveCharacter_TeleportWithoutReboundFloor_Right()
    {
        var input = new List<string>
        {
            ".......",
            "", 
            "10R1"
        };
        
        var actual = new Room(input);
        actual.MoveCharacter();
        actual.Position.Should().BeEquivalentTo(new Point(3, 0));
    }
    
    [Fact]
    public void Room_MoveCharacter_TeleportWithoutReboundFloor_Left()
    {
        var input = new List<string>
        {
            ".......",
            "", 
            "10R1"
        };
        
        var actual = new Room(input);
        actual.Facing = Direction.Left;
        actual.Position = new Point(4, 0);
        actual.MoveCharacter();
        actual.Position.Should().BeEquivalentTo(new Point(1, 0));
    }
    
    [Fact]
    public void Room_MoveCharacter_TeleportWithoutReboundFloor_Down()
    {
        var input = new List<string>
        {
            ".",
            ".",
            ".",
            ".",
            ".",
            ".",
            ".",
            ".",
            "", 
            "10R1"
        };
        
        var actual = new Room(input);
        actual.Facing = Direction.Down;
        actual.MoveCharacter();
        actual.Position.Should().BeEquivalentTo(new Point(0, 2));
    }
    
    [Fact]
    public void Room_MoveCharacter_TeleportWithoutReboundFloor_Up()
    {
        var input = new List<string>
        {
            ".",
            ".",
            ".",
            ".",
            ".",
            ".",
            ".",
            ".",
            "", 
            "10R1"
        };
        
        var actual = new Room(input);
        actual.Facing = Direction.Up;
        actual.Position = new Point(0, 3);
        actual.MoveCharacter();
        actual.Position.Should().BeEquivalentTo(new Point(0, 1));
    }

    [Fact]
    public void Room_MoveCharacter_TeleportWithReboundFloorAtEnd()
    {
        var input = new List<string>
        {
            "....... ",
            "", 
            "10R1"
        };
        
        var actual = new Room(input);
        actual.MoveCharacter();
        actual.Position.Should().BeEquivalentTo(new Point(3, 0));
    }

    [Fact]
    public void Room_MoveCharacter_TeleportWithReboundFloorAtBeginning()
    {
        var input = new List<string>
        {
            " .......",
            "", 
            "10R1"
        };
        
        var actual = new Room(input);
        actual.MoveCharacter();
        actual.Position.Should().BeEquivalentTo(new Point(4, 0));
    }

    [Fact]
    public void Room_MoveCharacter_TeleportWithReboundFloorAtEnds()
    {
        var input = new List<string>
        {
            " ....... ",
            "", 
            "10R1"
        };
        
        var actual = new Room(input);
        actual.MoveCharacter();
        actual.Position.Should().BeEquivalentTo(new Point(4, 0));
    }
    
    #endregion
    
    #endregion
}