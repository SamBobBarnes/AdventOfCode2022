namespace AdventOfCode2022.Day21;

public class Tribe2
{
    public List<Monkey2> Monkeys;
    public Tribe2(List<string> monkeys)
    {
        Monkeys = new List<Monkey2>();
        foreach (var monkeyString in monkeys)
        {
            var monkeyArray = monkeyString.Split(' ');
            var name = monkeyArray[0].Substring(0, monkeyArray[0].Length - 1);
            if (name == "root")
            {
                Monkeys.Add(new Monkey2(monkeyArray[1],monkeyArray[3],'=',name));
            }
            else if (monkeyArray.Length > 2)
            {
                Monkeys.Add(new Monkey2(monkeyArray[1],monkeyArray[3],monkeyArray[2][0],name));
            }
            else
            {
                if (name == "humn")
                {
                    Monkeys.Add(new Monkey2( null,name));
                }
                else
                {
                    Monkeys.Add(new Monkey2(Int64.Parse(monkeyArray[1]),name));
                }
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
    
    public Monkey2 Root => Monkeys.Find(m => m.Name == "root")!;
}

public class Monkey2
{
    public string Name = "";
    public int Type = 0;
    public Int64? Value;
    public string Operand1 = "";
    public Monkey2? OperandMonkey1 { get; set; }
    public Monkey2? OperandMonkey2 { get; set; }
    public string Operand2 = "";

    public Int64? GetValue()
    {
        if (Type == 0)
        {
            return Value;
        }
        
        var monkey1 = OperandMonkey1!.GetValue();
        var monkey2 = OperandMonkey2!.GetValue();
        
        if(monkey1 == null || monkey2 == null)
        {
            return null;
        }
        
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

    public long GetExpected(long expected)
    {
        if (Type == 0)
        {
            return expected;
        }
        
        var monkey1 = OperandMonkey1!.GetValue();
        var monkey2 = OperandMonkey2!.GetValue();
        var needed = (long)0;
        switch (Type)
        {
            case 1:
                needed = expected - (monkey1 ?? monkey2!.Value);
                break;
            case 2:
                if (monkey1 == null)
                {
                    needed = expected + monkey2!.Value;
                }
                else
                {
                    needed = -(expected - monkey1.Value);
                }
                break;
            case 3:
                needed = expected / (monkey1 ?? monkey2!.Value);
                break;
            case 4:
                if (monkey1 == null)
                {
                    needed = expected * monkey2!.Value;
                }
                else
                {
                    needed = monkey1.Value / expected;
                }
                break;
        }
        
        if (monkey1 == null)
        {
            return OperandMonkey1.GetExpected(needed);
        }
        return OperandMonkey2.GetExpected(needed);
    }

    public string GetRootValue()
    {
        
        var monkey1 = OperandMonkey1!.GetValue();
        var monkey2 = OperandMonkey2!.GetValue();
        
        

        return $"{monkey1} {monkey2}";
    }

    public Monkey2(){}
    
    public Monkey2(Int64? value, string name = "")
    {
        Name = name;
        Value = value;
    }

    public Monkey2(string operand1, string operand2, char operation, string name = "")
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
            '=' => 5,
            _ => 0
        };
    }
}