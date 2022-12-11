namespace AdventOfCode2022.Day11;

class SudoNumber
{
    public SudoNumber(string x)
    {
        Lower = Int64.Parse(x);
    }
    
    public SudoNumber(Int64 x)
    {
        Lower = x;
    }

    public Int64 Lower;
    public Int64 Upper;
    private readonly Int64 _cutoff = 2147483648;

    public SudoNumber Add(Int64 x)
    {
        Lower += x;
        while (Lower > _cutoff)
        {
            Upper += 1;
            Lower -= _cutoff;
        }

        return this;
    }

    public SudoNumber Add(SudoNumber x)
    {
        Upper += x.Upper;
        Add(x.Lower);
        
        return this;
    }

    public SudoNumber Multiply(Int64 x)
    {
        Int64 old = Lower;
        for (Int64 i = 0; i < x; i++)
        {
            Add(old);
        }

        return this;
    }
    
    public SudoNumber Multiply(SudoNumber x)
    {
        
    }

    public new string ToString()
    {
        return $"{Upper}, {Lower}";
    }
}