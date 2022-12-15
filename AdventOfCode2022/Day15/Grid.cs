namespace AdventOfCode2022.Day15;

public class Grid
{
    public Grid(IEnumerable<Sensor> sensors)
    {
        Console.WriteLine("Mapping sensors...");
        _sensors = sensors.ToList();
        var sMinX = _sensors.Min(s => s.Position.X);
        var sMinY = _sensors.Min(s => s.Position.Y);
        var sMaxX = _sensors.Max(s => s.Position.X);
        var sMaxY = _sensors.Max(s => s.Position.Y);
        var bMinX = _sensors.Min(s => s.Beacon.X);
        var bMinY = _sensors.Min(s => s.Beacon.Y);
        var bMaxX = _sensors.Max(s => s.Beacon.X);
        var bMaxY = _sensors.Max(s => s.Beacon.Y);

        _minX = sMinX < bMinX ? sMinX : bMinX;
        _minY = sMinY < bMinY ? sMinY : bMinY;
        _maxX = sMaxX > bMaxX ? sMaxX : bMaxX;
        _maxY = sMaxY > bMaxY ? sMaxY : bMaxY;
        _width = Math.Abs(_minX) + Math.Abs(_maxX) + 1;
        _height = Math.Abs(_minY) + Math.Abs(_maxY) + 1;
        _xOffset = Math.Abs(_minX);
        _yOffset = Math.Abs(_minY);

        Console.WriteLine("Detecting beacons...");
        _beaconRange = new List<List<bool>>();
        for (int i = _minY; i <= _maxY; i++)
        {
            _beaconRange.Add(new List<bool>(new bool[_width]));
        }
        MarkImpossibilities();
    }

    private readonly List<Sensor> _sensors;
    private int _minX;
    private int _minY;
    private int _maxX;
    private int _maxY;
    private int _xOffset;
    private int _yOffset;
    private int _width;
    private int _height;
    private List<List<bool>> _beaconRange;

    private void MarkImpossibilities()
    {
        foreach (var sensor in _sensors)
        {
            var impossibilities = sensor.Position.ManhattanRange(sensor.Beacon,sensor.MinimumRadius);
            foreach (var position in impossibilities)
            {
                if (position.X + _xOffset < 0 || position.X + _xOffset >= _beaconRange[0].Count()) {TripleX();}
                if (position.Y + _yOffset < 0 ||  position.Y + _yOffset >= _beaconRange.Count()) TripleY();
                _beaconRange[position.Y + _yOffset][position.X + _xOffset] = true;
            }
        }
    }

    private void TripleY()
    {
        Console.WriteLine("Tripling Y...");
        var tempList = new List<List<bool>>();
        for (int i = 0; i < _height; i++)
        {
            tempList.Add(new List<bool>(new bool[_width]));
        }
        tempList.AddRange(_beaconRange);
        for (int i = 0; i < _height; i++)
        {
            tempList.Add(new List<bool>(new bool[_width]));
        }

        _beaconRange = tempList;
        _minY -= _height;
        _maxY += _height;
        _yOffset += _height;
        _height *= 3;
        Console.WriteLine("Back to it...");
    }

    private void TripleX()
    {
        Console.WriteLine("Tripling X...");
        var tempList = new List<List<bool>>();
        for (int i = 0; i < _height; i++)
        {
            var tempRow = new List<bool>(new bool[_width]);
            tempRow.AddRange(_beaconRange[i]);
            tempRow.AddRange(new bool[_width]);
            tempList.Add(tempRow);
        }

        _beaconRange = tempList;
        _minX -= _width;
        _maxX += _width;
        _xOffset += _width;
        _width *= 3;
        Console.WriteLine("Back to it...");
    }

    public int GetImpossibilities(int row)
    {
        return _beaconRange[row + _yOffset].Count(b => b);
    }
    
    public new string ToString()
    {
        var result = "";
        for (int i = _minY; i <= _maxY; i++)
        {
            for (int j = _minX; j <= _maxX; j++)
            {
                var sensor = _sensors.FirstOrDefault(s => s.Position.X == j && s.Position.Y == i);
                if (sensor != null) result += "S";
                else if (_beaconRange[i + _yOffset][j + _xOffset]) result += "#";
                else result += ".";
            }

            result += "\r\n";
        }

        return result;
    }
}