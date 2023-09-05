namespace AdventOfCode2022;

public class BasePart
{
    private static readonly string _path = "../../../../AdventOfCode2022";
    
    protected static void Start(int day, int part)
    {
        Console.WriteLine($"Day {day.ToString()}, Part {part.ToString()}");
    }

    protected static List<string> LoadInput(int day, bool example = false)
    {
        if (example)
        {
            return System.IO.File.ReadAllText($"{_path}/Day{day}/ExampleInput.txt")
                .Replace("\r","")
                .Split("\n")
                .ToList();
        }
        return System.IO.File.ReadAllText($"{_path}/Day{day}/Input.txt")
            .Replace("\r","")
            .Split("\n")
            .ToList();
    }
    
    protected static List<char> LoadInputChars(int day, bool example = false)
    {
        if (example)
        {
            return System.IO.File.ReadAllText($"{_path}/Day{day}/ExampleInput.txt")
                .ToCharArray()
                .ToList();
        }
        return System.IO.File.ReadAllText($"{_path}/Day{day}/Input.txt")
            .ToCharArray()
            .ToList();
    }

    public static void WriteOutput(int day, string output)
    {
        System.IO.File.WriteAllText($"{_path}/Day{day}/Output.txt",output);
    }
}