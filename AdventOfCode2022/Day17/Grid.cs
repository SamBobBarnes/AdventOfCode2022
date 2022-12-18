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
        if (_rockList.Count > 50) CombRocks();
        SpawnRock();
        var falling = true;
        DropWindThree();
        while (falling)
        {
            WindStep();
            falling = DropStep();
        }
        
    }

    private void DropWindThree()
    {
        var total = 0;
        var canA = true;
        var canB = true;
        var canC = true;
        var a = _wind.NextJet() == '<' ? -1 : 1;
        var b = _wind.NextJet() == '<' ? -1 : 1;
        var c = _wind.NextJet() == '<' ? -1 : 1;

        foreach (var pebble in fallingRock.Item2)
        {
            if (pebble.X + a == _width || pebble.X + a < 0)
            {
                canA = false;
                break;
            }
        }
        if (canA) total += a;
        foreach (var pebble in fallingRock.Item2)
        {
            if (pebble.X + b + total == _width || pebble.X + b + total < 0)
            {
                canB = false;
                break;
            }
        }
        if (canB) total += b;
        foreach (var pebble in fallingRock.Item2)
        {
            if (pebble.X + c + total == _width || pebble.X + c + total < 0)
            {
                canC = false;
                break;
            }
        }
        if (canC) total += c;
        foreach (var pebble in fallingRock.Item2)
        {
            pebble.X = pebble.X + total;
            pebble.Y = pebble.Y - 3;
        }

    }

    private void CombRocks()
    {
        var zero = _rockList.FindLastIndex(x => x.Item2.Any(y => y.X == 0));
        var one = _rockList.FindLastIndex(x => x.Item2.Any(y => y.X == 1));
        var two = _rockList.FindLastIndex(x => x.Item2.Any(y => y.X == 2));
        var three = _rockList.FindLastIndex(x => x.Item2.Any(y => y.X == 3));
        var four = _rockList.FindLastIndex(x => x.Item2.Any(y => y.X == 4));
        var five = _rockList.FindLastIndex(x => x.Item2.Any(y => y.X == 5));
        var six = _rockList.FindLastIndex(x => x.Item2.Any(y => y.X == 6));

        var lowest = 51;
        if (zero < lowest) lowest = zero;
        if (one < lowest) lowest = one;
        if (two < lowest) lowest = two;
        if (three < lowest) lowest = three;
        if (four < lowest) lowest = four;
        if (five < lowest) lowest = five;
        if (six < lowest) lowest = six;
        _rockList.RemoveRange(0, lowest-1);
    }

    private void WindStep()
    {
        var wind = _wind.NextJet() == '<' ? -1 : 1;

        foreach (var pebble in fallingRock.Item2)
        {
            if (pebble.X + wind == _width || pebble.X + wind < 0 ||
                _rockList.FirstOrDefault(x => x.Item2.Contains(new Coordinate(pebble.X + wind, pebble.Y)) && x.Item1) != null)
            {
                return;
            }
        }
        foreach (var pebble in fallingRock.Item2)
        {
            pebble.X = pebble.X + wind;
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