namespace AdventOfCode2022.Day1;

public class Part2 : BasePart
{
    public static int Run()
    {
        Start(1,2);

        var textArray = LoadInput(1);
        var index = 0;
        var elves = new List<int>(){0};
        
        textArray.ForEach(x =>
        {
            if (string.IsNullOrEmpty(x))
            {
                elves.Add(0);
                index++;
            }
            else
            {
                elves[index] += Int32.Parse(x);
            }
        });
        
        var max1 = elves.Max(x => x);
        elves.Remove(max1);
        var max2 = elves.Max(x => x);
        elves.Remove(max2);
        var max3 = elves.Max(x => x);
        elves.Remove(max3);
        
        return max1 + max2 + max3;
    }
}