namespace AdventOfCode2022.Day13;

public class Part1 : BasePart
{
    public static int Run()
    {
        Start(13,1);
        var input = LoadInput(13);
        var packetPairs = new List<Tuple<string,string>>();
        for (int i = 0; i < input.Count; i += 3)
        {
            packetPairs.Add(new Tuple<string, string>(input[i],input[i+1]));
        }
        
        return 0;
    }
}