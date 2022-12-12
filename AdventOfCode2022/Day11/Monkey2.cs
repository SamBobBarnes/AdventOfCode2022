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
            .Select(x => UInt64.Parse(x))
            .ToList();

        var operationArray = worryString[2]
            .Split(": ")[1]
            .Split(" ");
        _operation = operationArray[3];
        _actWith = operationArray[4] == "old" ? 0 : UInt64.Parse(operationArray[4]);

        Test = UInt64.Parse(worryString[3].Split(" ")[3]);

        _testPass = int.Parse(worryString[4].Split(" ")[5]);
        _testFail = int.Parse(worryString[5].Split(" ")[5]);
    }

    public readonly int _number;
    public List<UInt64> Items;
    public readonly UInt64 Test;
    public readonly int _testPass;
    public readonly int _testFail;
    public readonly string _operation;
    public UInt64 _actWith;
    public UInt64 ItemsInspected = 0;

    public new string ToString()
    {
        return $"Monkey {_number}";
    }
}