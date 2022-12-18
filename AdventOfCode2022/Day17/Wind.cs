namespace AdventOfCode2022.Day17;

public class Wind
{
    public Wind(List<char> wind)
    {
        _windList = wind;
        _maxPostion = wind.Count - 1;
    }
    
    private List<char> _windList;
    private int _position = 0;
    private int _maxPostion;
    
    public char NextJet()
    {
        var jet = _windList[_position];
        if (_position == _maxPostion) _position = 0;
        else _position++;
        return jet;
    }
}