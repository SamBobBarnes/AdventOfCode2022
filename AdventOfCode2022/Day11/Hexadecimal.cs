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

    public Hexadecimal(string x)
    {
        Number = IntToHex(int.Parse(x));
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
            if (i == a.Number.Count)
            {
                a.Number.Add(0);
            }
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

    public static Hexadecimal Subtract(Hexadecimal a, Hexadecimal b)
    {
        for (int i = b.Number.Count-1; i >= 0; i--)
        {
            var sum = a.Number[i] - b.Number[i];
            if (sum < 0)
            {
                a = CarryReverse(a, 1, i + 1);
                sum = sum + 16;
            }
            a.Number[i] = sum;
        }

        return RemoveLeadingZeros(a);
    }

    private static Hexadecimal CarryReverse(Hexadecimal a, int b, int indexA = 0)
    {
        var sum = a.Number[indexA] - b;
        if (sum < 0)
        {
            a = CarryReverse(a, 1, indexA + 1);
            sum = sum + 16;
        }

        a.Number[indexA - 1] = 15;
        a.Number[indexA] = sum;
        return a;
    }

    private static Hexadecimal RemoveLeadingZeros(Hexadecimal x)
    {
        for (int i = x.Number.Count - 1; i >= 0; i--)
        {
            if (x.Number[i] > 0) break;
            x.Number.RemoveAt(i);
        }

        return x;
    }

    public static Hexadecimal Multiply(Hexadecimal a, Hexadecimal b)
    {
        var x = a.Number.Count >= b.Number.Count ? a.Number : b.Number;
        var y = a.Number.Count >= b.Number.Count ? b.Number : a.Number;

        var numbersToAdd = new List<Hexadecimal>();
        var sum = new Hexadecimal(0);
        
        for (int i = 0; i < y.Count; i++) //index y
        {
            for (int j = 0; j < x.Count; j++)//index x
            {
                numbersToAdd.Add(MultiplyHexDigits(x[j],y[i],j + i));
            }        
        }

        foreach (var number in numbersToAdd)
        {
            sum = Add(sum, number);
        }

        return sum;
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

    public static long Modulo(Hexadecimal a, long m)
    {
        long Base = 1;
        long ans = 0;
        
        for(int i = 0; i < a.Number.Count; i++)
        {
         
            // Stores i-th digit of N
            long n = a.Number[i] % m;
 
            // Update ans
            ans = (ans + (Base % m * n % m) % m) % m;
 
            // Update base
            Base = (Base % m * 16 % m) % m;
        }

        return ans;
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