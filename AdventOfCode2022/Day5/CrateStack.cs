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

    public void Push(char crate)
    {
        Stack.Add(crate);
        LastIndex++;
    }
}