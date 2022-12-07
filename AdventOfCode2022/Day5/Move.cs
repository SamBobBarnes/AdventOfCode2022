namespace AdventOfCode2022.Day5;

class Move
{
    public Move(string move)
    {
        var moveParams = move.Split(" ");
        Amount = int.Parse(moveParams[1]);
        Start = int.Parse(moveParams[3])-1;
        End = int.Parse(moveParams[5])-1;
    }
    public int Start { get; }
    public int End { get; }
    public int Amount { get; }

    public new string ToString()
    {
        return $"move {Amount} from {Start + 1} to {End + 1}";
    }
}