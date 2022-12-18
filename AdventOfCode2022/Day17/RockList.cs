namespace AdventOfCode2022.Day17;

public class RockList
{
    private List<List<Coordinate>> _rockList = new List<List<Coordinate>>()
    {
        new()
        {
            new(0,0),new(1,0),new(2,0),new(3,0)
        },
        new()
        {
            new(1,0),new(0,1),new(1,1),new(2,1),new(1,2)
        },
        new()
        {
            new(0,0),new(1,0),new(2,0),new(2,1),new(2,2)
        },
        new()
        {
            new(0,0),new(0,1),new(0,2),new(0,3)
        },
        new()
        {
            new(0,0),new(1,0),new(0,1),new(1,1)
        }
    };
    private int _position = 0;
    private int _maxPostion = 4;
    
    public List<Coordinate> NextRock()
    {
        var rock = _rockList[_position];
        if (_position == _maxPostion) _position = 0;
        else _position++;
        return rock;
    }
}