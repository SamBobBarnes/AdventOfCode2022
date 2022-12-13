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

        _superModulus = 1;
        foreach (var monkey in MonkeyList)
        {
            _superModulus *= monkey.Test;
        }
    }

    private List<Monkey2> MonkeyList;
    private readonly UInt64 _superModulus;
    
    public void ExecuteRound(int round)
    {
        foreach (var monkey in MonkeyList){
            for (int i = 0; i < monkey.Items.Count; i++)
            {
                monkey.ItemsInspected++;
                var tempActWith = monkey._actWith;
                
                if (tempActWith == (UInt64)0) tempActWith = monkey.Items[i];

                switch (monkey._operation) 
                {
                    case "+":
                        monkey.Items[i] += tempActWith;
                        break;
                    case "*":
                        monkey.Items[i] *= tempActWith;
                        break;
                }
            
                monkey.Items[i] %= _superModulus;
                if (monkey.Items[i] % monkey.Test == 0)
                {
                    MonkeyList[monkey._testPass].Items.Add(monkey.Items[i]);
                }
                else
                {
                    MonkeyList[monkey._testFail].Items.Add(monkey.Items[i]);
                }
            }

            monkey.Items.Clear();
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
    
    public UInt64 GetMonkeyBusiness()
    {
        var monkeys = MonkeyList.OrderByDescending(m => m.ItemsInspected).ToList();


        return monkeys[0].ItemsInspected * monkeys[1].ItemsInspected;
    }
}