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
}