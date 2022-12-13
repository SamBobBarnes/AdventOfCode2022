namespace AdventOfCode2022.Day11;

class Monkey
{
    public Monkey(List<string> worryString)
    {
        _number = int.Parse(
            worryString[0]
                .Split(" ")[1]
                .ToCharArray()[0]
                .ToString()
            );

        Items = worryString[1]
            .Split(": ")[1]
            .Split(", ")
            .Select(x => int.Parse(x))
            .ToList();

        var operationArray = worryString[2]
            .Split(": ")[1]
            .Split(" ");
        _operation = new Operation(operationArray[3], operationArray[4] == "old" ? -1 : int.Parse(operationArray[4]));

        _test = int.Parse(worryString[3].Split(" ")[3]);

        _testPass = int.Parse(worryString[4].Split(" ")[5]);
        _testFail = int.Parse(worryString[5].Split(" ")[5]);
    }

    private readonly int _number;
    private List<int> Items;
    private readonly int _test;
    private readonly int _testPass;
    private readonly int _testFail;
    private readonly Operation _operation;
    public int ItemsInspected = 0;

    public Dictionary<int, List<int>> Inspect(List<int> monkeys)
    {
        var inspectedItems = new Dictionary<int, List<int>>();
        foreach (var monkey in monkeys)
        {
            inspectedItems.Add(monkey, new List<int>());
        }

        foreach (var item in Items)
        {
            var worry = item;
            worry = _operation.Act(worry);
            worry = (int)Math.Floor((double)worry / (double)3);
            var test = worry % _test == 0;
            inspectedItems[test? _testPass : _testFail].Add(worry);
            ItemsInspected++;
        }
        
        Items.RemoveAll(x => true);
        return inspectedItems;
    }

    public void TakeItems(List<int> items)
    {
        Items.AddRange(items);
    }

    public new string ToString()
    {
        var result = $"Monkey {_number}: ";

        foreach (var item in Items)
        {
            result += item + ", ";
        }

        return result;
    }
}

class Operation
{
    public Operation(string operand, int actWith)
    {
        _operand = operand;
        _actWith = actWith;
    }

    private readonly string _operand;
    private readonly int _actWith;

    public int Act(int old)
    {
        var actWith = _actWith;
        if (actWith < 0)
        {
            actWith = old;
        }
        
        if (_operand == "+")
        {
            return old + actWith;
        }
        else
        {
            return old * actWith;
        }
    }
}