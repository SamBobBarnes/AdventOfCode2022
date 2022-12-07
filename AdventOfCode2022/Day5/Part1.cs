namespace AdventOfCode2022.Day5;

public class Part1 : BasePart
{
    public static string Run()
    {
        Start(5,1);
        var input = LoadInput(5);
        var stackTops = new List<char>();

        var cratesInput = new List<string>();
        var moveInput = new List<string>();
        var crates = true;
        input.ForEach(x =>
        {
            if (string.IsNullOrEmpty(x)) crates = false;
            if(crates) cratesInput.Add(x);
            else moveInput.Add(x);
        });
        
        
        return CompileStackTop(stackTops);
    }

    private static string CompileStackTop(List<char> stackTops)
    {
        var result = "";
        stackTops.ForEach(x =>
        {
            result += x.ToString();
        });
        return result;
    }
}

class CrateStack
{
    public CrateStack(List<char> stack)
    {
        Stack = stack;
    }
    public List<char> Stack { get; set; }
}

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
}