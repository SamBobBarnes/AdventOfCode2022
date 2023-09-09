using System.Drawing;
using AdventOfCode2022.Day22;

namespace UnitTests.Day22;

public class RoomTests
{
    #region Initialize
    
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
    
    #endregion

    #region MoveCharacter

    #region WithoutObstruction

    [Theory, CombinatorialData]
    public void Room_MoveCharacter_WithoutObstruction([CombinatorialValues(Direction.Right,Direction.Left,Direction.Down,Direction.Up)] Direction direction)
    {
        var across = new List<string>
        {
            ".............",
            "", 
            "10R1"
        };
        
        var down = new List<string>
        {
            ".............",
            ".............",
            ".............",
            ".............",
            ".............",
            "", 
            "3R1"
        };
        
        var input = new List<string>();
        
        switch (direction)
        {
            case Direction.Right:
                input.AddRange(across);
                break;
            case Direction.Left:
                input.AddRange(across);
                break;
            case Direction.Down:
                input.AddRange(down);
                break;
            case Direction.Up:
                input.AddRange(down);
                break;
        }
        
        var actual = new Room(input)
        {
            Facing = direction
        };

        switch (direction)
        {
            case Direction.Left:
                actual.Position = new Point(12, 0);
                break;
            case Direction.Up:
                actual.Position = new Point(0, 4);
                break;
        }
        
        actual.MoveCharacter();

        Point expected = new Point();
        
        switch (direction)
        {
            case Direction.Right:
                expected = new Point(10, 0);
                break;
            case Direction.Left:
                expected = new Point(2, 0);
                break;
            case Direction.Down:
                expected = new Point(0, 3);
                break;
            case Direction.Up:
                expected = new Point(0, 1);
                break;
        }
        
        actual.Position.Should().BeEquivalentTo(expected);
    }

    #endregion
    
    #region WithObstruction

    [Theory, CombinatorialData]
    public void Room_MoveCharacter_WithObstruction([CombinatorialValues(Direction.Right,Direction.Down,Direction.Left,Direction.Up)]Direction direction)
    {
        var input = new List<string>
        {
            ".........",
            ".........",
            ".........",
            ".........",
            "....#....",
            ".........",
            ".........",
            ".........",
            ".........",
            "", 
            "10R1"
        };
        
        var actual = new Room(input)
        {
            Facing = direction
        };
        
        switch (direction)
        {
            case Direction.Right:
                actual.Position = new Point(0,4);
                break;
            case Direction.Down:
                actual.Position = new Point(4, 0);
                break;
            case Direction.Left:
                actual.Position = new Point(8, 4);
                break;
            case Direction.Up:
                actual.Position = new Point(4, 8);
                break;
        }
        
        actual.MoveCharacter();
        
        var expected = new Point();
        
        switch (direction)
        {
            case Direction.Right:
                expected = new Point(3, 4);
                break;
            case Direction.Left:
                expected = new Point(5, 4);
                break;
            case Direction.Down:
                expected = new Point(4, 3);
                break;
            case Direction.Up:
                expected = new Point(4, 5);
                break;
        }
        
        actual.Position.Should().BeEquivalentTo(expected);
    }
    
    #endregion

    #region Rebound
    
    [Theory, CombinatorialData]
    public void Room_MoveCharacter_TeleportWithoutReboundFloor([CombinatorialValues(Direction.Right, Direction.Left, Direction.Up, Direction.Down)] Direction direction)
    {
        var input = new List<string>
        {
            ".......",
            ".......",
            ".......",
            ".......",
            ".......",
            ".......",
            ".......",
            ".......",
            "",
            "10R1"
        };
        
        var actual = new Room(input)
        {
            Facing = direction
        };
        
        Point expected = new Point();

        switch (direction)
        {
            case Direction.Right:
                expected = new Point(3, 0);
                break;
            case Direction.Left:
                actual.Position = new Point(4, 0);
                expected = new Point(1, 0);
                break;
            case Direction.Down:
                expected = new Point(0, 2);
                break;
            case Direction.Up:
                actual.Position = new Point(0, 3);
                expected = new Point(0, 1);
                break;
        }
        
        actual.MoveCharacter();
        
        actual.Position.Should().BeEquivalentTo(expected);
    }

    [Theory, CombinatorialData]
    public void Room_MoveCharacter_TeleportWithReboundFloorAtEnd([CombinatorialValues(Direction.Right, Direction.Left, Direction.Up, Direction.Down)] Direction direction)
    {
        var input = new List<string>();
        
        var rd = new List<string>
        {
            "...... ",
            "...... ",
            "...... ",
            "...... ",
            "...... ",
            "...... ",
            "       ",
            "",
            "10R1"
        };
        var lu = new List<string>
        {
            " .     ",
            " ......",
            " ......",
            " ......",
            " ......",
            " ......",
            " ......",
            "",
            "10R1"
        };

        switch (direction)
        {
            case Direction.Right:
                input = rd;
                break;
            case Direction.Left:
                input = lu;
                break;
            case Direction.Down:
                input = rd;
                break;
            case Direction.Up:
                input = lu;
                break;
        }
        
        var actual = new Room(input)
        {
            Facing = direction
        };
        
        Point expected = new Point();

        switch (direction)
        {
            case Direction.Right:
                expected = new Point(4, 0);
                break;
            case Direction.Left:
                actual.Position = new Point(6, 6);
                expected = new Point(2, 6);
                break;
            case Direction.Down:
                expected = new Point(0, 4);
                break;
            case Direction.Up:
                actual.Position = new Point(6, 6);
                expected = new Point(6, 2);
                break;
        }
        
        actual.MoveCharacter();
        
        actual.Position.Should().BeEquivalentTo(expected);
    }

    [Theory, CombinatorialData]
    public void Room_MoveCharacter_TeleportWithReboundFloorAtBeginning([CombinatorialValues(Direction.Right, Direction.Left, Direction.Up, Direction.Down)] Direction direction)
    {
        var input = new List<string>();
        
        var lu = new List<string>
        {
            "...... ",
            "...... ",
            "...... ",
            "...... ",
            "...... ",
            "...... ",
            "       ",
            "",
            "10R1"
        };
        var rd = new List<string>
        {
            ".      ",
            " ......",
            " ......",
            " ......",
            " ......",
            " ......",
            " ......",
            "",
            "10R1"
        };

        switch (direction)
        {
            case Direction.Right:
                input = rd;
                break;
            case Direction.Left:
                input = lu;
                break;
            case Direction.Down:
                input = rd;
                break;
            case Direction.Up:
                input = lu;
                break;
        }
        
        var actual = new Room(input)
        {
            Facing = direction
        };
        
        Point expected = new Point();

        switch (direction)
        {
            case Direction.Right:
                actual.Position = new Point(1, 1);
                expected = new Point(5, 1);
                break;
            case Direction.Left:
                actual.Position = new Point(5, 5);
                expected = new Point(1, 5);
                break;
            case Direction.Down:
                actual.Position = new Point(1, 1);
                expected = new Point(1, 5);
                break;
            case Direction.Up:
                actual.Position = new Point(5, 5);
                expected = new Point(5, 1);
                break;
        }
        
        actual.MoveCharacter();
        
        actual.Position.Should().BeEquivalentTo(expected);
    }

    [Theory, CombinatorialData]
    public void Room_MoveCharacter_TeleportWithReboundFloorAtEnds([CombinatorialValues(Direction.Right, Direction.Left, Direction.Up, Direction.Down)] Direction direction)
    {
        var input = new List<string>
        {
            "      .",
            " ..... ",
            " ..... ",
            " ..... ",
            " ..... ",
            " ..... ",
            "       ",
            "",
            "4R1"
        };
        
        var actual = new Room(input)
        {
            Facing = direction
        };
        
        actual.Position = new Point(3, 3);
        
        Point expected = new Point();

        switch (direction)
        {
            case Direction.Right:
                expected = new Point(2, 3);
                break;
            case Direction.Left:
                expected = new Point(4, 3);
                break;
            case Direction.Down:
                expected = new Point(3, 2);
                break;
            case Direction.Up:
                expected = new Point(3, 4);
                break;
        }
        
        actual.MoveCharacter();
        
        actual.Position.Should().BeEquivalentTo(expected);
    }
    
    #endregion
    
    #endregion

    [Fact]
    public void Rotate_CanRotate()
    {
        var input = new List<string>
        {
            ".........",
            "", 
            "10R1"
        };
    }
}