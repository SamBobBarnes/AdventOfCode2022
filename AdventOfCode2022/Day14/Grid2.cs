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
}