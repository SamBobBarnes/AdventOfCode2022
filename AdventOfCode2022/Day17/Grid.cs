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
    private int _highestObject = -1;

    private Tuple<bool, List<Coordinate>> fallingRock => _rockList.Last();
    
    public void DropRock()
    {
        SpawnRock();
    }

    private void WindStep()
    {
        
    }

    private void DropStep()
    {
        
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

    private bool RockAtRest(List<Coordinate> rock)
    {
        return false;
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
                if (_rockList.FirstOrDefault(x => x.Item2.Contains(new Coordinate(j, i)) && !x.Item1) != null) result += '@';
                else result += '.';
            }

            result += "\r\n";
        }

        return result;
    }
}