namespace AdventOfCode2022.Day21;

public class Tribe
{
    public List<Monkey> Monkeys;
    public Tribe(List<string> monkeys)
    {
        Monkeys = new List<Monkey>();
        foreach (var monkeyString in monkeys)
        {
            var monkeyArray = monkeyString.Split(' ');
            var name = monkeyArray[0].Substring(0, monkeyArray[0].Length - 1);
            if (monkeyArray.Length > 2)
            {
                Monkeys.Add(new Monkey(monkeyArray[1],monkeyArray[3],monkeyArray[2][0],name));
            }
            else
            {
                Monkeys.Add(new Monkey(Int64.Parse(monkeyArray[1]),name));
            }
        }
        
        foreach (var monkey in Monkeys)
        {
            if (monkey.Operand1 != "")
            {
                monkey.OperandMonkey1 = Monkeys.Find(m => m.Name == monkey.Operand1);
            }
            if (monkey.Operand2 != "")
            {
                monkey.OperandMonkey2 = Monkeys.Find(m => m.Name == monkey.Operand2);
            }
        }
    }
    
    public Monkey Root => Monkeys.Find(m => m.Name == "root")!;
}

public class Monkey
{
    public string Name = "";
    public int Type = 0;
    public Int64 Value = 0;
    public string Operand1 = "";
    public Monkey? OperandMonkey1 { get; set; }
    public Monkey? OperandMonkey2 { get; set; }
    public string Operand2 = "";

    public Int64 GetValue()
    {
        switch (Type)
        {
            case 1:
                return OperandMonkey1!.GetValue() + OperandMonkey2!.GetValue();
            case 2:
                return OperandMonkey1!.GetValue() - OperandMonkey2!.GetValue();
            case 3:
                return OperandMonkey1!.GetValue() * OperandMonkey2!.GetValue();
            case 4:
                return OperandMonkey1!.GetValue() / OperandMonkey2!.GetValue();
            default:
                return Value;
        }
    }

    public Monkey(){}
    
    public Monkey(Int64 value, string name = "")
    {
        Name = name;
        Value = value;
    }

    public Monkey(string operand1, string operand2, char operation, string name = "")
    {
        Name = name;
        Operand1 = operand1;
        Operand2 = operand2;
        Type = operation switch
        {
            '+' => 1,
            '-' => 2,
            '*' => 3,
            '/' => 4,
            _ => 0
        };
    }
}