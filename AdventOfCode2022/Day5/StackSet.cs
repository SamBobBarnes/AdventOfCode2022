namespace AdventOfCode2022.Day5;

class StackSet
{
    public StackSet(List<List<char>> stacks)
    {
        Stacks = new List<CrateStack>();
        stacks.ForEach(s =>
        {
            Stacks.Add(new CrateStack(s));
        });
    }
    public List<CrateStack> Stacks { get; set; }

    public new string ToString()
    {
        var result = "";
        var rows = new List<string>();
        var tallestStackCount = GetTallestStackCount();

        for (int i = 0; i < tallestStackCount; i++)
        {
            var row = "";
            for (int j = 0; j < Stacks.Count; j++)
            {
                if (i < Stacks[j].Count) row += $"[{Stacks[j].Index(i)}] ";
                else row += "    ";
            }
            rows.Add(row);
        }
        
        rows.ForEach(r =>
        {
            if (result != "") result = r + "\r\n" + result;
            else result = r;
        });
        return result;
    }

    public string StackTop()
    {
        var stackTop = "";
        Stacks.ForEach(s =>
        {
            try
            {
                stackTop += s.Pop();
            }
            catch
            {
                stackTop += " ";
            }
        });
        return stackTop;
    }

    private int GetTallestStackCount()
    {
        var tallestStackCount = 0;

        for (int i = 0; i < Stacks.Count; i++)
        {
            if (Stacks[i].Count > tallestStackCount)
            {
                tallestStackCount = Stacks[i].Count;
            }
        }

        return tallestStackCount;
    }

    public void ExecuteMove(Move move)
    {
        for (int i = 0; i < move.Amount; i++)
        {
            var crate = Stacks[move.Start].Pop();
            Stacks[move.End].Push(crate);
        }
    }
    
    public void ExecuteMoveMany(Move move)
    {
        var crates = Stacks[move.Start].Pop(move.Amount);
        Stacks[move.End].Push(crates);
    }
}