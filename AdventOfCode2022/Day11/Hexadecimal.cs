namespace AdventOfCode2022.Day11;

class Hexadecimal
{
    public Hexadecimal(long x)
    {
        Number = IntToHex(x);
    }

    public Hexadecimal(List<char> x)
    {
        Number = CharListToHex(x);
    }

    public List<int> Number;

    private List<int> IntToHex(long x)
    {
        var hexList = new List<int>();
        
        var quotient = x;
        while (quotient > 15)
        {
            hexList.Add((int)quotient%16);
            quotient = (int)Math.Floor((double)quotient / 16);
        }
        hexList.Add((int)quotient);

        return hexList;
    }

    private List<int> CharListToHex(List<char> x)
    {
        var hexList = new List<int>();
        
        for (int i = x.Count - 1; i >= 0; i--)
        {
            switch (x[i])
            {
                case '0': hexList.Add(0); break;
                case '1': hexList.Add(1); break;
                case '2': hexList.Add(2); break;
                case '3': hexList.Add(3); break;
                case '4': hexList.Add(4); break;
                case '5': hexList.Add(5); break;
                case '6': hexList.Add(6); break;
                case '7': hexList.Add(7); break;
                case '8': hexList.Add(8); break;
                case '9': hexList.Add(9); break;
                case 'A': hexList.Add(10); break;
                case 'B': hexList.Add(11); break;
                case 'C': hexList.Add(12); break;
                case 'D': hexList.Add(13); break;
                case 'E': hexList.Add(14); break;
                case 'F': hexList.Add(15); break;
            }
        }

        return hexList;
    }

    public static Hexadecimal Add(Hexadecimal a, Hexadecimal b)
    {
        for (int i = 0; i < b.Number.Count; i++)
        {
            var sum = a.Number[i] + b.Number[i];
            if (sum > 15)
            {
                a = Carry(a, 1, i + 1);
            }
            a.Number[i] = sum % 16;
        }

        return a;
    }

    private static Hexadecimal Carry(Hexadecimal a, int b, int indexA = 0)
    {
        if (indexA == a.Number.Count)
        {
            a.Number.Add(0);
        }
        var sum = a.Number[indexA] + b;
        if (sum > 15)
        {
            a = Carry(a, 1, indexA + 1);
        }
        a.Number[indexA] = sum % 16;
        return a;
    }

    public static Hexadecimal Multiply(Hexadecimal a, Hexadecimal b)
    {
        
    }

    private static Hexadecimal MultiplyHexDigits(int a, int b, int index)
    {
        var result = new Hexadecimal(a * b);
        for (int i = 0; i < index; i++)
        {
            result.Number.Insert(0,0);
        }
        return result;
    }

    public new string ToString()
    {
        var result = "";

        for (int i = Number.Count - 1; i >= 0; i--)
        {
            switch (Number[i])
            {
                case 0: result += "0";  break;
                case 1: result += "1"; break;
                case 2: result += "2"; break;
                case 3: result += "3"; break;
                case 4: result += "4"; break;
                case 5: result += "5"; break;
                case 6: result += "6"; break;
                case 7: result += "7"; break;
                case 8: result += "8"; break;
                case 9: result += "9"; break;
                case 10: result += "A"; break;
                case 11: result += "B"; break;
                case 12: result += "C"; break;
                case 13: result += "D"; break;
                case 14: result += "E"; break;
                case 15: result += "F"; break;
            }
        }
        return result;
    }
    
    public List<char> ToCharList()
    {
        var result = "";

        for (int i = 0; i < Number.Count; i++)
        {
            switch (Number[i])
            {
                case 0: result += "0";  break;
                case 1: result += "1"; break;
                case 2: result += "2"; break;
                case 3: result += "3"; break;
                case 4: result += "4"; break;
                case 5: result += "5"; break;
                case 6: result += "6"; break;
                case 7: result += "7"; break;
                case 8: result += "8"; break;
                case 9: result += "9"; break;
                case 10: result += "A"; break;
                case 11: result += "B"; break;
                case 12: result += "C"; break;
                case 13: result += "D"; break;
                case 14: result += "E"; break;
                case 15: result += "F"; break;
            }
        }
        return result.ToCharArray().ToList();
    }
}