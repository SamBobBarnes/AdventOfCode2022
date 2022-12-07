namespace AdventOfCode2022.Day6;

public class Part1 : BasePart
{
    public static int Run()
    {
        Start(6,1);
        var input = LoadInputChars(6);
        var marker = -1;
        
        for (int i = 3; i < input.Count; i++)
        {
            var lastFour = new List<char>()
            {
                input[i-3],
                input[i-2],
                input[i-1],
                input[i],
            };
            var duplicates = lastFour.GroupBy(x => x)
                .Where(g => g.Count() > 1)
                .Select(x => x.Key).ToList();
            if (duplicates.Count == 0)
            {
                marker = i + 1;
                break;
            }
        }

        return marker;
    }
}