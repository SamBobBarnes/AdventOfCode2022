namespace AdventOfCode2022.Day14;

class Grid2 : Grid
{
    public Grid2(IEnumerable<IEnumerable<Coordinate>> map, int width, int height) : base(map, width, height)
    {
        
        for (int i = _height; i < _height + 2; i++)
        {
            for (int j = 0; j < _width; j++)
            {
                _cells.Add(new(j,i));
            }
        }
        
        _height += 2;
        DrawLine(new Coordinate(0, _height - 1), new Coordinate(_width - 1, _height - 1));
    }

    private void AddToRight()
    {
        _width++;

        for (int i = 0; i < _height; i++)
        {
            _cells.Add(new(_width-1,i));
        }
        DrawLine(new Coordinate(_width - 1, _height - 1), new Coordinate(_width - 1, _height - 1));
    }
    
    public new int SimulateSand()
    {
        var source = GetSandSource();
        var continueDropping = true;
        var count = 0;
        Cell.CreateSand(source);
        while (continueDropping)
        {
            count++;
            var sand = DropSand(source);
            if (sand.Position.X == source.Position.X && sand.Position.Y == source.Position.Y) continueDropping = false;
        }
        return count;
    }
    
    private Cell DropSand(Cell source)
    {
        var sand = source;
        var noFloor = false;
        Cell.CreateSand(sand);
        while (!noFloor)
        {
            if (!CheckForFloorBelow(sand!))
            {
                noFloor = true;
                break;
            }
            var nextValid = NextValidCell(sand);
            if (nextValid == null) break;
            Cell.MoveSand(sand,nextValid!);
            sand = nextValid;
        }

        return sand;
    }
    
    private Cell? NextValidCell(Cell a)
    {
        var down = GetCell(a.Position.X, a.Position.Y + 1);
        if (down != null && !down.isSolid) return down;
        var left = GetCell(a.Position.X - 1, a.Position.Y + 1);
        if (left != null && !left.isSolid) return left;
        if(a.Position.X + 1 == _width) AddToRight();
        var right = GetCell(a.Position.X + 1, a.Position.Y + 1);
        if (right != null && !right.isSolid) return right;
        return null;
    }
}