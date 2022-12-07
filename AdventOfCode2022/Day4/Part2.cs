namespace AdventOfCode2022.Day4;

public class Part2 : BasePart
{
    public static int Run()
    {
        Start(4,2);
        var input = LoadInput(4);
        var overlaps = 0;
        
        var pairs = CreateAssignmentPairs(input);
        
        pairs.ForEach(x =>
        {
            if (x.Overlap()) overlaps++;
        });
        
        return overlaps;
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