namespace AdventOfCode2022.Day5;

class CrateStack
{
    public CrateStack(List<char> stack)
    {
        Stack = stack;
        LastIndex = Stack.Count - 1;
    }

    private List<char> Stack;
    private int LastIndex;

    public int Count => Stack.Count;

    public char Index(int index)
    {
        return Stack[index];  
    } 

    public char Pop()
    {
        if (LastIndex < 0)
        {
            throw new IndexOutOfRangeException("Stack is empty!");
        }
        var last = Stack[LastIndex];
        Stack.RemoveAt(LastIndex);
        LastIndex--;
        return last;
    }

    public List<char> Pop(int amount)
    {
        var popped = new List<char>();
        for (int i = 0; i < amount; i++)
        {
            popped.Add(Pop());
        }

        return popped;
    }

    public void Push(char crate)
    {
        Stack.Add(crate);
        LastIndex++;
    }

    public void Push(List<char> crates)
    {
        for (int i = crates.Count - 1; i >= 0; i--)
        {
            Push(crates[i]);
        }
    }
}