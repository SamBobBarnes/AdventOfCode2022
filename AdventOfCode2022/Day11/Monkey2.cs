namespace AdventOfCode2022.Day11;

class Monkey2
{
    public Monkey2(List<string> worryString)
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
            .Select(x => new Hexadecimal(x))
            .ToList();

        var operationArray = worryString[2]
            .Split(": ")[1]
            .Split(" ");
        _operation = new Operation2(operationArray[3], operationArray[4] == "old" ? -1 : int.Parse(operationArray[4]));

        _test = int.Parse(worryString[3].Split(" ")[3]);

        _testPass = int.Parse(worryString[4].Split(" ")[5]);
        _testFail = int.Parse(worryString[5].Split(" ")[5]);
    }

    private readonly int _number;
    private List<Hexadecimal> Items;
    private readonly int _test;
    private readonly int _testPass;
    private readonly int _testFail;
    private readonly Operation2 _operation;
    public int ItemsInspected = 0;

    public Dictionary<int, List<Int64>> Inspect(List<int> monkeys)
    {
        var inspectedItems = new Dictionary<int, List<Int64>>();
        foreach (var monkey in monkeys)
        {
            inspectedItems.Add(monkey, new List<Int64>());
        }

        foreach (var item in Items)
        {
            var worry = item;
            worry = _operation.Act(worry);
            var test = worry % _test == 0;
            inspectedItems[test? _testPass : _testFail].Add(worry);
            ItemsInspected++;
        }
        
        Items.RemoveAll(x => true);
        return inspectedItems;
    }

    public void TakeItems(List<Hexadecimal> items)
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

class Operation2
{
    public Operation2(string operand, int actWith)
    {
        _operand = operand;
        _actWith = actWith;
    }

    private readonly string _operand;
    private readonly int _actWith;

    public Hexadecimal Act(Hexadecimal old)
    {
        if (_actWith < 0)
        {
            Hexadecimal actWith = old;
            
            if (_operand == "+")
            {
                return old.Add(actWith);
            }
            else
            {
                return old.Multiply(actWith);
            }
        }
        else
        {
            if (_operand == "+")
            {
                return old.Add(_actWith);
            }
            else
            {
                return old.Multiply(_actWith);
            }
        }
    }
}