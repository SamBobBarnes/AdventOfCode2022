namespace AdventOfCode2022.Day11;

class MonkeyBunch2
{
    public MonkeyBunch2(List<string> input)
    {
        MonkeyList = new List<Monkey2>();
        var singleMonkey = new List<string>();
        foreach (var row in input)
        {
            if (string.IsNullOrEmpty(row))
            {
                MonkeyList.Add(new Monkey2(singleMonkey));
                singleMonkey = new List<string>();
            }
            else
            {
                singleMonkey.Add(row.Trim());
            }
        }
        MonkeyList.Add(new Monkey2(singleMonkey));
    }

    private List<Monkey2> MonkeyList;
    
    public void ExecuteRound()
    {
        var monkeyList = new List<int>();
        for (int i = 0; i < MonkeyList.Count; i++)
        {
            monkeyList.Add(i);
        }
        
        foreach (var monkey in MonkeyList)
        {
            var itemsToPass = monkey.Inspect(monkeyList);
            foreach (var item in itemsToPass)
            {
                MonkeyList[item.Key].TakeItems(item.Value);
            }
        }
    }
    
    public new string ToString()
    {
        var monkeyString = "";

        foreach (var monkey in MonkeyList)
        {
            monkeyString += monkey.ToString() + $": {monkey.ItemsInspected} items inpsected" + "\r\n";
        }

        return monkeyString;
    }
    
    public int GetMonkeyBusiness()
    {
        var topMonkey = 0;
        var secondMonkey = 0;

        foreach (var monkey in MonkeyList)
        {
            if (monkey.ItemsInspected > topMonkey) topMonkey = monkey.ItemsInspected;
        }
        
        foreach (var monkey in MonkeyList)
        {
            if (monkey.ItemsInspected > secondMonkey && monkey.ItemsInspected != topMonkey) secondMonkey = monkey.ItemsInspected;
        }

        return topMonkey * secondMonkey;
    }
}