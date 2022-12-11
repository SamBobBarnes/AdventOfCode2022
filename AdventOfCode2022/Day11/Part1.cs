namespace AdventOfCode2022.Day11;

public class Part1 : BasePart
{
    public static int Run()
    {
        Start(11,1);
        var input = LoadInput(11);
        var bunch = new MonkeyBunch(input);
        for (int i = 0; i < 20; i++)
        {
            bunch.ExecuteRound();
        }
        
        Console.WriteLine(bunch.ToString());

        return bunch.GetMonkeyBusiness();
    }

    private static List<Monkey> CreateWorryList(List<string> input)
    {
        var monkeyList = new List<List<string>>();
        var singleMonkey = new List<string>();
        for (int i = 0; i < input.Count; i++)
        {
            if (string.IsNullOrEmpty(input[i]))
            {
                monkeyList.Add(singleMonkey);
                singleMonkey = new List<string>();
            }
            else
            {
                singleMonkey.Add(input[i].Trim());
            }
        }
        monkeyList.Add(singleMonkey);

        return monkeyList.Select(x => new Monkey(x)).ToList();
    }
}