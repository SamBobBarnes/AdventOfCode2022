using AdventOfCode2022.Day17;
using Xunit.Abstractions;

namespace UnitTests.Day17;

public class Day17
{
    private readonly ITestOutputHelper _output;
    public Day17(ITestOutputHelper outputHelper)
    {
        _output = outputHelper;
    }
    
    
    #region TrimTower
    
    [Fact]
    public void Grid2_TrimTower_NeedsTrim()
    {
        var expected = new byte[]{0x0e, 0x05};
        var grid = new Grid2(new byte[5]{0x10, 0x02,0x7f, 0x0e, 0x05});
        
        grid.TrimTower();

        var actualLength = grid.TowerLength;
        var actualTower = grid.Tower;
        
        actualLength.Should().Be(2);
        actualTower.Should().BeEquivalentTo(expected);
    }
    
    [Fact]
    public void Grid2_TrimTower_TrimNotNeeded()
    {
        var expected = new byte[] {0x05, 0x02,0x08, 0x40, 0x30};
        var grid = new Grid2(new byte[5]{0x05, 0x02,0x08, 0x40, 0x30});
        
        grid.TrimTower();

        var actualLength = grid.TowerLength;
        var actualTower = grid.Tower;
        
        actualLength.Should().Be(5);
        actualTower.Should().BeEquivalentTo(expected);
    }
    
    #endregion
    
    #region DoubleTower

    [Fact]
    public void Grid2_DoubleTower()
    {
        var expected = new byte[]{0x04, 0x02, 0x01, 0x00, 0x00, 0x00};
        var grid = new Grid2(new byte[]{0x04, 0x02, 0x01});
        
        grid.DoubleTower();
        
        var actualLength = grid.TowerLength;
        var actualTower = grid.Tower;
        
        actualLength.Should().Be(6);
        actualTower.Should().BeEquivalentTo(expected);
    }
    
    #endregion
    
    #region DoubleNeeded

    [Fact]
    public void Grid2_DoubleNeeded_Needed()
    {
        var grid = new Grid2(new byte[] { 0x00, 0x00, 0x00, 0x10, 0x00 });
        
        var actual = grid.DoubleNeeded();

        actual.Should().Be(true);
    }

    [Fact]
    public void Grid2_DoubleNeeded_NotNeeded()
    {
        var grid = new Grid2(new byte[] { 0x10, 0x00, 0x00, 0x00, 0x00 });
        
        var actual = grid.DoubleNeeded();

        actual.Should().Be(false);
    }
    
    #endregion
    
    #region CheckForCollision

    [Fact]
    public void Grid2_CheckForCollision_NoCollision()
    {
        var rock = new byte[]
        {
            0x10,0x10,0x10,0x10
        };

        var grid = new Grid2(new byte[]{0x10,0x00,0x00,0x00,0x00,0x00,0x00,0x00});
        
        var actual = grid.CheckForCollision(rock, 1);
        
        actual.Should().Be(false);
    }

    [Fact]
    public void Grid2_CheckForCollision_Collision()
    {
        var rock = new byte[]
        {
            0x10,0x10,0x10,0x10
        };

        var grid = new Grid2(new byte[]{0x10,0x00,0x00,0x00,0x00,0x00,0x00,0x00});
        
        var actual = grid.CheckForCollision(rock, 0);
        
        actual.Should().Be(true);
    }

    [Fact]
    public void Grid2_CheckForCollision_CollideWithGround()
    {
        var rock = new byte[]
        {
            0x10,0x10,0x10,0x10
        };

        var grid = new Grid2();
        
        var actual = grid.CheckForCollision(rock, -1);
        
        actual.Should().Be(true);
    }

    [Fact]
    public void Grid2_CheckForCollision_Collision_MidRock()
    {
        var rock = new byte[]
        {
            0x10,0x10,0x10,0x10
        };

        var grid = new Grid2(new byte[]{0x00,0x00,0x10,0x00,0x00,0x00,0x00,0x00});
        
        var actual = grid.CheckForCollision(rock, 0);
        
        actual.Should().Be(true);
    }
    
    #endregion
    
    #region ShiftRock

    [Fact]
    public void Grid2_ShiftRock_ShiftRight()
    {
        var rock = new byte[]
        {
            0x10, 0x38, 0x10
        };

        var expected = new byte[]
        {
            0x08,0x1c,0x08
        };

        var grid = new Grid2();
        var actual = grid.ShiftRock(rock, '>');

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Grid2_ShiftRock_ShiftLeft()
    {
        var rock = new byte[]
        {
            0x10, 0x38, 0x10
        };

        var expected = new byte[]
        {
            0x20,0x70,0x20
        };

        var grid = new Grid2();
        var actual = grid.ShiftRock(rock, '<');

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Grid2_ShiftRock_ShiftRight_Blocked()
    {
        var rock = new byte[]
        {
            0x02,0x07,0x02
        };
        
        var expected = new byte[]
        {
            0x02,0x07,0x02
        };

        var grid = new Grid2();
        var actual = grid.ShiftRock(rock, '>');

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Grid2_ShiftRock_ShiftLeft_Blocked()
    {
        var rock = new byte[]
        {
            0x20,0x70,0x20
        };
        
        var expected = new byte[]
        {
            0x20,0x70,0x20
        };

        var grid = new Grid2();
        var actual = grid.ShiftRock(rock, '<');

        actual.Should().BeEquivalentTo(expected);
    }

    #endregion
    
    #region ShiftThree
    
    [Fact]
    public void Grid2_ShiftThree_AllLeft()
    {
        var rock = new byte[]
        {
            0x02,0x07,0x02
        };
        
        var expected = new byte[]
        {
            0x10,0x38,0x10
        };

        var grid = new Grid2();
        var actual = grid.ShiftThree(rock, new char[] {'<','<','<'});

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Grid2_ShiftThree_AllLeftIntoWall()
    {
        var rock = new byte[]
        {
            0x10,0x38,0x10
        };
        
        var expected = new byte[]
        {
            0x20,0x70,0x20
        };

        var grid = new Grid2();
        var actual = grid.ShiftThree(rock, new char[] {'<','<','<'});

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Grid2_ShiftThree_AllRight()
    {
        var expected = new byte[]
        {
            0x02,0x07,0x02
        };
        
        var rock = new byte[]
        {
            0x10,0x38,0x10
        };

        var grid = new Grid2();
        var actual = grid.ShiftThree(rock, new char[] {'>','>','>'});

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Grid2_ShiftThree_AllRightIntoWall()
    {
        var expected = new byte[]
        {
            0x02,0x07,0x02
        };
        
        var rock = new byte[]
        {
            0x08,0x1c,0x08
        };

        var grid = new Grid2();
        var actual = grid.ShiftThree(rock, new char[] {'>','>','>'});

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Grid2_ShiftThree_TwoRight()
    {
        var expected = new byte[]
        {
            0x04,0x0e,0x04
        };
        
        var rock = new byte[]
        {
            0x08,0x1c,0x08
        };

        var grid = new Grid2();
        var actual = grid.ShiftThree(rock, new char[] {'>','>','<'});

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Grid2_ShiftThree_TwoLeft()
    {
        var rock = new byte[]
        {
            0x02,0x07,0x02
        };
        
        var expected = new byte[]
        {
            0x04,0x0e,0x04
        };

        var grid = new Grid2();
        var actual = grid.ShiftThree(rock, new char[] {'<','<','>'});

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Grid2_ShiftThree_TwoRightIntoWall()
    {
        var rock = new byte[]
        {
            0x04,0x0e,0x04
        };
        
        var expected = new byte[]
        {
            0x04,0x0e,0x04
        };

        var grid = new Grid2();
        var actual = grid.ShiftThree(rock, new char[] {'>','>','<'});

        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Grid2_ShiftThree_TwoLeftIntoWall()
    {
        var rock = new byte[]
        {
            0x10,0x38,0x10
        };
        
        var expected = new byte[]
        {
            0x10,0x38,0x10
        };

        var grid = new Grid2();
        var actual = grid.ShiftThree(rock, new char[] {'<','<','>'});

        actual.Should().BeEquivalentTo(expected);
    }
    #endregion
    
    #region WriteToTower

    [Fact]
    public void Grid2_WriteToTower()
    {
        var rock = new byte[]
        {
            0x10, 0x38, 0x10
        };
        
        var expected = new byte[]
        {
            0x00,0x10,0x38,0x10,0x00,0x00,0x00,0x00,0x00,0x00
        };

        var grid = new Grid2();
        
        grid.WriteToTower(rock, 1);
        
        var actual = grid.Tower;
        
        actual.Should().BeEquivalentTo(expected);
    }
    
    #endregion
    
    #region DropRock

    [Fact]
    public void Grid2_DropRock()
    {
        var expected = new byte[]
        {
            0x08,0x1c,0x0f,0x79,0x01,0x00,0x00,0x00,0x00,0x00
        };
        
        var input = new char[] {'<','>','>','>','<','<','<','<','<','<'};
        
        
        var grid = new Grid2(new byte[]{0x08,0x1c,0x08,0x78,0x00,0x00,0x00,0x00,0x00,0x00}, 2);
        
        var actualIndex = grid.DropRock(input, 0, 3);

        grid.Tower.Should().BeEquivalentTo(expected);
        actualIndex[0].Should().Be(6);
        actualIndex[1].Should().Be(4);
        
    }

    [Fact]
    public void Grid2_DropRock_UsingExample()
    {
        var expected = new byte[]
        {
            0b_0001_1110,
            0b_0000_1000,
            0b_0001_1100,
            0b_0111_1100,
            0b_0001_0100,
            0b_0001_0100,
            0b_0000_0100,
            0b_0000_0110,
            0b_0000_0110,
            0b_0011_1100,
            0b_0001_0000,
            0b_0011_1000,
            0b_0001_1110,
            0b_0000_0010,
            0b_0000_0010,
            0b_0000_0000,
            0b_0000_0000,
            0b_0000_0000,
            0b_0000_0000,
            0b_0000_0000,
        };
        
        var input = new char[] {'>','>','>','<','<','>','<','>','>','<','<','<','>','>','<','>','>','>','<','<','<','>','>','>','<','<','<','>','<','<','<','>','>','<','>','>','<','<','>','>'};
        var index = 0;
        var towerTop = -1;
        var grid = new Grid2();
        int[] array;
        
        for (int i = 0; i < 8; i++)
        {
            array = grid.DropRock(input, index, towerTop);
            index = array[0];
            towerTop = array[1];
        }
        
        Log(grid.ToString());
        grid.Tower.Should().BeEquivalentTo(expected);
    }
    
    // 0010000 0000000 6
    // 0010000 0010000 5
    // 1110000 0010000 4
    // 0010000 1111000 3
    // 0111000 0011100 2
    // 0010000 0001000 1
    // 0011110 0011110 0
    
    #endregion
    
    private void Log(string actual)
    {
        _output.WriteLine(actual);
    }
}