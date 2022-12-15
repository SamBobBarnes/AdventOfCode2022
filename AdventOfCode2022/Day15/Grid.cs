namespace AdventOfCode2022.Day15;

public class Grid
{
    public Grid(IEnumerable<Sensor> sensors)
    {
        _sensors = sensors.ToList();
        var sMinX = _sensors.Min(s => s.X);
        var sMinY = _sensors.Min(s => s.Y);
        var sMaxX = _sensors.Max(s => s.X);
        var sMaxY = _sensors.Max(s => s.Y);
        var bMinX = _sensors.Min(s => s.Beacon.X);
        var bMinY = _sensors.Min(s => s.Beacon.Y);
        var bMaxX = _sensors.Max(s => s.Beacon.X);
        var bMaxY = _sensors.Max(s => s.Beacon.Y);

        _minX = sMinX < bMinX ? sMinX : bMinX;
        _minY = sMinY < bMinY ? sMinY : bMinY;
        _maxX = sMaxX > bMaxX ? sMaxX : bMaxX;
        _maxY = sMaxY > bMaxY ? sMaxY : bMaxY;
        
        ExpandGrid();
    }

    private readonly List<Sensor> _sensors;
    private int _minX;
    private int _minY;
    private int _maxX;
    private int _maxY;

    public int GetImpossibilities(int y)
    {
        var count = 0;
        for (int i = _minX; i <= _maxX; i++)
        {
            var impossible = false;
            foreach (var sensor in _sensors)
            {
                if (sensor.ManhattanDistance(i, y) <= sensor.MinimumRadius)
                {
                    impossible = true;
                    break;
                }
            }
            if (impossible) count++;
        }

        var beaconList = new List<Coordinate>();
        foreach (var sensor in _sensors)
        {
            if (sensor.Beacon.Y == y && !beaconList.Contains(sensor.Beacon))
            {
                beaconList.Add(sensor.Beacon);
                count--;
            }
        }

        return count;
    }
    
    public int GetPossibilities(int y, int max)
    {
        var count = 0;
        for (int i = 0; i <= max; i++)
        {
            var impossible = false;
            foreach (var sensor in _sensors)
            {
                if (sensor.ManhattanDistance(i, y) <= sensor.MinimumRadius)
                {
                    impossible = true;
                    break;
                }
            }
            if (impossible) count++;
        }

        return max+1-count;
    }

    private void ExpandGrid()
    {
        foreach (var sensor in _sensors)
        {
            var range = sensor.ManhattanDistance();
            if (sensor.X - range < _minX) _minX = sensor.X - range;
            if (sensor.X + range > _maxX) _maxX = sensor.X + range;
            if (sensor.Y - range < _minY) _minY = sensor.Y - range;
            if (sensor.Y + range < _maxY) _maxY = sensor.Y + range;
        }
    }

    public UInt64 FindBeacon(int rangeFromZero)
    {
        var borders = new List<Coordinate>();
        foreach (var sensor in _sensors)
        {
            borders.AddRange(sensor.ManhattanBorder().Where(c => c.X >= 0 && c.X <= rangeFromZero && c.Y >= 0 && c.Y <= rangeFromZero));
        }

        var beacons = new List<Coordinate>(); 
        foreach (var coordinate in borders)
        {
            var withinRangeOfAnotherSensor = false;
            foreach (var sensor in _sensors)
            {
                if (sensor.WithinRange(coordinate))
                {
                    withinRangeOfAnotherSensor = true;
                    break;
                }
            }
            if(!withinRangeOfAnotherSensor) beacons.Add(coordinate);
        }

        var beacon = beacons.First();
        return Convert.ToUInt64(beacon.X) * Convert.ToUInt64(4000000) + Convert.ToUInt64(beacon.Y);
    }
}