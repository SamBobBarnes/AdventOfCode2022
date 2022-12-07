namespace AdventOfCode2022.Day4;

public class Part1 : BasePart
{
    public static int Run()
    {
        Start(4,1);
        var input = LoadInput(4);
        var completeOverlaps = 0;
        
        var pairs = CreateAssignmentPairs(input);
        
        pairs.ForEach(x =>
        {
            if (x.CompleteOverlap()) completeOverlaps++;
        });
        
        return completeOverlaps;
    }

    private static List<AssignmentPair> CreateAssignmentPairs(List<string> input)
    {
        var pairs = new List<AssignmentPair>();

        input.ForEach(x =>
        {
            pairs.Add(new AssignmentPair(x));
        });
        
        return pairs;
    }
}

class Assignment
{
    public Assignment(string set)
    {
        var setArray = set.Split("-");
        Start = int.Parse(setArray[0]);
        End = int.Parse(setArray[1]);
    }
    public int Start { get; set; }
    public int End { get; set; }

    private bool IsBetween(int num)
    {
        if (num <= End && num >= Start) return true;
        return false;
    }

    private bool NumsWithin(int start, int end)
    {
        if (IsBetween(start) && IsBetween(end)) return true;
        return false;
    }

    public bool HasWithin(Assignment otherElf)
    {
        if (NumsWithin(otherElf.Start, otherElf.End)) return true;
        return false;
    }

    public new string ToString()
    {
        return $"{Start}-{End}";
    }
}

class AssignmentPair
{
    public AssignmentPair(string pair)
    {
        var pairArray = pair.Split(",");
        Elf1 = new Assignment(pairArray[0]);
        Elf2 = new Assignment(pairArray[1]);
    }
    
    public Assignment Elf1 { get; set; }
    public Assignment Elf2 { get; set; }

    public bool CompleteOverlap()
    {
        if (Elf1.HasWithin(Elf2) || Elf2.HasWithin(Elf1)) return true;
        return false;
    }

    public new string ToString()
    {
        return $"{Elf1.ToString()},{Elf2.ToString()}";
    }
}