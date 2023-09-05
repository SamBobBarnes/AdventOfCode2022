namespace AdventOfCode2022;

public class BasePart
{
    protected static void Start(int day, int part)
    {
        Console.WriteLine($"Day {day.ToString()}, Part {part.ToString()}");
    }

    protected static List<string> LoadInput(int day, bool example = false)
    {
        if (example)
        {
            return System.IO.File.ReadAllText($@"../../../../AdventOfCode2022/Day{day}/ExampleInput.txt")
                .Replace("\r","")
                .Split("\n")
                .ToList();
        }
        return System.IO.File.ReadAllText($@"../../../../AdventOfCode2022/Day{day}/Input.txt")
            .Replace("\r","")
            .Split("\n")
            .ToList();
    }
    
    protected static List<char> LoadInputChars(int day, bool example = false)
    {
        if (example)
        {
            return System.IO.File.ReadAllText($@"../../../Day{day}/ExampleInput.txt")
                .ToCharArray()
                .ToList();
        }
        return System.IO.File.ReadAllText($@"../../../Day{day}/Input.txt")
            .ToCharArray()
            .ToList();
    }

    public static void WriteOutput(int day, string output)
    {
        System.IO.File.WriteAllText($@"../../../Day{day}/Output.txt",output);
    }
}