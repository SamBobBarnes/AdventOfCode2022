namespace AdventOfCode2022.Day5;

public class Part2 : BasePart
{
    public static string Run()
    {
        Start(5,2);
        var input = LoadInput(5);
        var stackTops = new List<char>();

        var cratesInput = new List<string>();
        var moveInput = new List<string>();
        var isCrates = true;
        input.ForEach(x =>
        {
            if (string.IsNullOrEmpty(x))
            {
                isCrates = false;
            }
            else
            {
                if(isCrates) cratesInput.Add(x);
                else moveInput.Add(x);
            }
            
        });

        var crates = DecompileStack(cratesInput);
        var moves = moveInput.Select(m => new Move(m)).ToList();
        
        // Console.WriteLine(crates.ToString());
        moves.ForEach(m =>
        {
            // Console.WriteLine();
            // Console.WriteLine(m.ToString());
            crates.ExecuteMoveMany(m);
            // Console.WriteLine(crates.ToString());
        });
        
        return crates.StackTop();
    }

    private static StackSet DecompileStack(List<string> stack)
    {
        var stackRows = new List<List<char>>();
        stack.ForEach(pile =>
        {
            var row = pile.ToCharArray().ToList();
            row.Add(' ');
            stackRows.Add(row);
        });

        var stackCount = (stackRows[0].Count + 1) / 4;

        var singleStackRows = new List<List<char>>();
        
        for (int i = stackRows.Count-2; i >= 0; i--)
        {
            var row = stack[i];
            var rowArray = new List<char>();
            for (int j = 0; j < row.Length; j += 4)
            {
                rowArray.Add(row[j+1]);
            }
            singleStackRows.Add(rowArray);
        }

        var stacks = new List<List<char>>();
        for (int i = 0; i < singleStackRows[0].Count; i++)
        {
            var singleStack = new List<char>();
            for (int j = 0; j < singleStackRows.Count; j++)
            {
                if(singleStackRows[j][i] != ' ')
                    singleStack.Add(singleStackRows[j][i]);
            }
            stacks.Add(singleStack);
        }

        return new StackSet(stacks);
    }
}