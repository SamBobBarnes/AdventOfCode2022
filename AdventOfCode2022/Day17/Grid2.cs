namespace AdventOfCode2022.Day17;

public class Grid2
{
    private int _listLength;
    private byte[] _tower;
    private const byte FullRow = 0x7f;
    private int _currentRock = 0;

    private List<byte[]> _rocks = new ()
    {
        new []{ (byte)0b00011110 },
        new []{ (byte)0b00001000, (byte)0b00011100, (byte)0b00001000 },
        new []{ (byte)0b00011100, (byte)0b00000100, (byte)0b00000100 },
        new []{ (byte)0b00010000, (byte)0b00010000, (byte)0b00010000, (byte)0b00010000 },
        new []{ (byte)0b00011000, (byte)0b00011000 }
        
    };

    private readonly byte[] _reverse = new byte[]
    {
        0x00,0x40,0x20,0x60,0x10,0x50,0x30,0x70,
        0x08,0x48,0x28,0x68,0x18,0x58,0x38,0x78,
        0x04,0x44,0x24,0x64,0x14,0x54,0x34,0x74,
        0x0c,0x4c,0x2c,0x6c,0x1c,0x5c,0x3c,0x7c,
        0x02,0x42,0x22,0x62,0x12,0x52,0x32,0x72,
        0x0a,0x4a,0x2a,0x6a,0x1a,0x5a,0x3a,0x7a,
        0x06,0x46,0x26,0x66,0x16,0x56,0x36,0x76,
        0x0e,0x4e,0x2e,0x6e,0x1e,0x5e,0x3e,0x7e,
        0x01,0x41,0x21,0x61,0x11,0x51,0x31,0x71,
        0x09,0x49,0x29,0x69,0x19,0x59,0x39,0x79,
        0x05,0x45,0x25,0x65,0x15,0x55,0x35,0x75,
        0x0d,0x4d,0x2d,0x6d,0x1d,0x5d,0x3d,0x7d,
        0x03,0x43,0x23,0x63,0x13,0x53,0x33,0x73,
        0x0b,0x4b,0x2b,0x6b,0x1b,0x5b,0x3b,0x7b,
        0x07,0x47,0x27,0x67,0x17,0x57,0x37,0x77,
        0x0f,0x4f,0x2f,0x6f,0x1f,0x5f,0x3f,0x7f
    };

    public byte[] GetRock()
    {
        var rock = _rocks[_currentRock];
        
        if(_currentRock == 4) _currentRock = 0;
        else _currentRock++;

        return rock;
    }
    
    
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
            if (_tower[i] == FullRow)
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

    public byte[] ShiftThree(byte[] rock, char[] directions)
    {
        var left = directions.Count(x => x == '<');
        var right = directions.Count(x => x == '>');
        var dominantDirection = right > left ? '>' : '<';
        var amount = right > left ? right : left;

        var shiftThree = amount >= 3;
        var shiftTwo = amount >= 2;
        var shiftOne = true;
        
        if (dominantDirection == '>')
        {
            
            for (int i = 0; i < rock.Length; i++)
            {
                if (shiftThree && (rock[i] % 8) != 0) shiftThree = false;
                if (shiftTwo && (rock[i] % 4) != 0) shiftTwo = false;
                if (shiftOne && (rock[i] % 2) != 0) shiftOne = false;
            }
        } 
        else if (dominantDirection == '<')
        {
            for (int i = 0; i < rock.Length; i++)
            {
                var reverse = _reverse[rock[i]];
                if (shiftThree && (reverse % 8) != 0) shiftThree = false;
                if (shiftTwo && (reverse % 4) != 0) shiftTwo = false;
                if (shiftOne && (reverse % 2) != 0) shiftOne = false;
            }
        }
        
        if (shiftThree) return Shift(rock,dominantDirection,3);
        if (shiftTwo) return Shift(rock,dominantDirection,2);
        if (shiftOne) return Shift(rock,dominantDirection,1);
        return rock;
    }

    public byte[] ShiftRock(byte[] rock, char direction)
    {
        switch (direction)
        {
            case '>':
                for (int i = 0; i < rock.Length; i++)
                {
                    if ((rock[i] & 0x01) == 0x01) return rock;
                }
                
                return Shift(rock, '>');
            case '<':
                for (int i = 0; i < rock.Length; i++)
                {
                    if ((rock[i] & 0x40) == 0x40) return rock;
                }
                
                return Shift(rock, '<');
            default: return rock;
        }
    }

    private byte[] Shift(byte[] rock, char direction, int amount = 1)
    {
        if (direction == '>')
        {
            for (int i = 0; i < rock.Length; i++)
            {
                rock[i] = unchecked((byte)(rock[i] >> amount));
            }
        }
        else
        {
            for (int i = 0; i < rock.Length; i++)
            {
                rock[i] = unchecked((byte)(rock[i] << amount));
            }
        }

        return rock;
    }
}