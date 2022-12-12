namespace AdventOfCode2022.Day11;

public class Part2 : BasePart
{
    public static UInt64 Run()
    {
        Start(11,1);
        var input = LoadInput(11);
        var bunch = new MonkeyBunch2(input);
        for (int i = 0; i < 10000; i++)
        { 
            bunch.ExecuteRound(i+1);
            Console.WriteLine($"Round {i}");
        }
        
        Console.WriteLine(bunch.ToString());
        
        return bunch.GetMonkeyBusiness();
    }
}