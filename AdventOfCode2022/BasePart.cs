namespace AdventOfCode2022;

public class BasePart
{
    public static void Start(int day, int part)
    {
        Console.WriteLine($"Day {day.ToString()}, Part {part.ToString()}");
    }

    public static List<string> LoadInput(int day)
    {
        return System.IO.File.ReadAllText($@"C:\Users\sb17057\Repos\AdventOfCode\2022\AdventOfCode2022\AdventOfCode2022\Day{day}\Input.txt")
            .Split("\r\n")
            .ToList();
    }
    public static List<char> LoadInputChars(int day)
    {
        return System.IO.File.ReadAllText($@"C:\Users\sb17057\Repos\AdventOfCode\2022\AdventOfCode2022\AdventOfCode2022\Day{day}\Input.txt")
            .ToCharArray()
            .ToList();
    }
}