namespace AdventOfCode2022.Day6;

public class Part2 : BasePart
{
    public static int Run()
    {
        Start(6,1);
        var input = LoadInputChars(6);
        var marker = -1;
        
        for (int i = 13; i < input.Count; i++)
        {
            var lastForteen = new List<char>()
            {
                input[i-13],
                input[i-12],
                input[i-11],
                input[i-10],
                input[i-9],
                input[i-8],
                input[i-7],
                input[i-6],
                input[i-5],
                input[i-4],
                input[i-3],
                input[i-2],
                input[i-1],
                input[i],
            };
            var duplicates = lastForteen.GroupBy(x => x)
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