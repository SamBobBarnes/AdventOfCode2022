namespace AdventOfCode2022.Day17;

public class Grid2
{
    private int _listLength;
    private byte[] _tower;
    private byte _fullRow = 0x7f;

    public Grid2()
    {
        _listLength = 10;
        _tower = new byte[_listLength];
    }

    public Grid2(byte[] array)
    {
        _tower = array;
        _listLength = array.Length;
    }

    public int TowerLength { get => _tower.Length; }
    public int ListLength { get => _listLength; }
    public byte[] Tower { get => _tower; }

    public void DoubleTower()
    {
        _listLength *= 2;
        var newTower = new byte[_listLength];
        for (int i = 0; i < _tower.Length; i++)
        {
            newTower[i] = _tower[i];
        }

        _tower = newTower;
    }

    public bool DoubleNeeded()
    {
        for (int i = _listLength-1; i > _listLength-5; i--)
        {
            if (_tower[i] != 0x00)
            {
                return true;
            }
        }

        return false;
    }

    public void TrimTower()
    {
        var fullIndex = -1;
        for (int i = 0; i < _tower.Length; i++)
        {
            if (_tower[i] == _fullRow)
            {
                fullIndex = i;
                break;
            }
        }

        if (fullIndex >= 0)
        {
            _listLength -= fullIndex + 1;
            var newTower = new byte[_listLength];
            for(int i = fullIndex + 1; i < _tower.Length; i++)
            {
                newTower[i - fullIndex - 1] = _tower[i];
            }
            _tower = newTower;
        }
    }

    public bool CheckForCollision(byte[] rock, int rockIndex)
    {
        for(int i = 0; i < rock.Length; i++)
        {
            if ((rock[i] & _tower[rockIndex + i]) != 0x00)
            {
                return true;
            }
        }

        return false;
    }
}