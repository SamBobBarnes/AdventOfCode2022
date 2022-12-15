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
            return System.IO.File.ReadAllText($@"../../../Day{day}/ExampleInput.txt")
                .Split("\r\n")
                .ToList();
        }
        return System.IO.File.ReadAllText($@"../../../Day{day}/Input.txt")
            .Split("\r\n")
            .ToList();
    }
    
    protected static List<char> LoadInputChars(int day)
    {
        return System.IO.File.ReadAllText($@"../../../Day{day}/Input.txt")
            .ToCharArray()
            .ToList();
    }

    public static void WriteOutput(int day, string output)
    {
        System.IO.File.WriteAllText($@"../../../Day{day}/Output.txt",output);
    }
}