using AdventOfCode2022.Day17;

namespace UnitTests.Day17;

public class Day17
{
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
}