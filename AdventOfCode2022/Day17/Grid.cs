namespace AdventOfCode2022.Day17;

public class Grid
{
    public Grid(List<char> wind)
    {
        _wind = new Wind(wind);
        _rockList = new List<Tuple<bool, List<Coordinate>>>();
    }

    private Wind _wind;
    private RockList _rocks = new RockList();
    private List<Tuple<bool, List<Coordinate>>> _rockList;
    private int _width = 7;
    private int _height = 5;
    private int _spawnYOffset = 4;
    private int _spawnXOffset = 2;
    private int _highestObject = 0;
    public int TowerHeight => _highestObject;

    private Tuple<bool, List<Coordinate>> fallingRock => _rockList.Last();

    public void DropRock()
    {
        SpawnRock();
        var falling = true;
        while (falling)
        {
            WindStep();
            falling = DropStep();
        }
        
    }

    private void WindStep()
    {
        var wind = _wind.NextJet();

        switch (wind)
        {
            case '<':
                MoveLeft();
                break;
            case '>':
                MoveRight();
                break;
        }
    }

    private void MoveRight()
    {
        foreach (var pebble in fallingRock.Item2)
        {
            if (pebble.X + 1 == _width ||
                _rockList.FirstOrDefault(x => x.Item2.Contains(new Coordinate(pebble.X + 1, pebble.Y)) && x.Item1) != null)
            {
                return;
            }
        }
        foreach (var pebble in fallingRock.Item2)
        {
            pebble.X = pebble.X + 1;
        }
    }

    private void MoveLeft()
    {
        foreach (var pebble in fallingRock.Item2)
        {
            if (pebble.X - 1 < 0 ||
                _rockList.FirstOrDefault(x => x.Item2.Contains(new Coordinate(pebble.X - 1, pebble.Y)) && x.Item1) != null)
            {
                return;
            }
        }
        foreach (var pebble in fallingRock.Item2)
        {
            pebble.X = pebble.X - 1;
        }
    }

    private bool DropStep()
    {
        if (RockAtRest())
        {
            _rockList[_rockList.Count - 1] = new(true, _rockList[_rockList.Count - 1].Item2);
            return false;
        }
        foreach(var pebble in fallingRock.Item2)
        {
            pebble.Y = pebble.Y - 1;
        }
        return true;
    }

    private void SpawnRock()
    {
        if(_highestObject + _spawnYOffset > _height - 1) ExtendGrid();
        var rock = _rocks.NextRock();
        foreach (var pebble in rock)
        {
            pebble.X = pebble.X + _spawnXOffset;
            pebble.Y = pebble.Y + _highestObject + _spawnYOffset;
        }
        _rockList.Add(new Tuple<bool, List<Coordinate>>(false,rock));
    }

    private bool RockAtRest()
    {
        var landBelow = false;
        foreach(var pebble in fallingRock.Item2)
        {
            if (_rockList.FirstOrDefault(x => x.Item2.Contains(new Coordinate(pebble.X, pebble.Y - 1)) && x.Item1) != null || pebble.Y == 1)
            {
                landBelow = true;
                break;
            }
        }
        if (landBelow)
        {
            foreach (var pebble in fallingRock.Item2)
            {
                if (pebble.Y > _highestObject) _highestObject = pebble.Y;
            }
        }

        return landBelow;
    }

    private void ExtendGrid()
    {
        _height *= 2;
    }

    public new string ToString()
    {
        var result = "";

        for (int i = _height - 1; i >= 0; i--)
        {
            for (int j = 0; j < _width; j++)
            {
                if (_rockList.FirstOrDefault(x => x.Item2.Contains(new Coordinate(j, i)) && x.Item1) != null) result += '#';
                else if (_rockList.FirstOrDefault(x => x.Item2.Contains(new Coordinate(j, i)) && !x.Item1) != null) result += '@';
                else result += '.';
            }

            result += "\r\n";
        }

        return result;
    }
}