using Xunit.Abstractions;
using Xunit.Sdk;

namespace UnitTests;

public class ProgramRun
{
    private readonly ITestOutputHelper _output;
    public ProgramRun(ITestOutputHelper outputHelper)
    {
        _output = outputHelper;
    }
    
    [Fact]
    public void Day1Part1()
    {
        Log(AdventOfCode2022.Day1.Part1.Run());
    }
    
    [Fact]
    public void Day1Part2()
    {
        Log(AdventOfCode2022.Day1.Part2.Run());
    }
    
    [Fact]
    public void Day2Part1()
    {
        Log(AdventOfCode2022.Day2.Part1.Run());
    }
    
    [Fact]
    public void Day2Part2()
    {
        Log(AdventOfCode2022.Day2.Part2.Run());
    }
    
    [Fact]
    public void Day3Part1()
    {
        Log(AdventOfCode2022.Day3.Part1.Run());
    }
    
    [Fact]
    public void Day3Part2()
    {
        Log(AdventOfCode2022.Day3.Part2.Run());
    }
    
    [Fact]
    public void Day4Part1()
    {
        Log(AdventOfCode2022.Day4.Part1.Run());
    }
    
    [Fact]
    public void Day4Part2()
    {
        Log(AdventOfCode2022.Day4.Part2.Run());
    }
    
    [Fact]
    public void Day5Part1()
    {
        Log(AdventOfCode2022.Day5.Part1.Run());
    }
    
    [Fact]
    public void Day5Part2()
    {
        Log(AdventOfCode2022.Day5.Part2.Run());
    }
    
    [Fact]
    public void Day6Part1()
    {
        Log(AdventOfCode2022.Day6.Part1.Run());
    }
    
    [Fact]
    public void Day6Part2()
    {
        Log(AdventOfCode2022.Day6.Part2.Run());
    }
    
    [Fact]
    public void Day7Part1()
    {
        Log(AdventOfCode2022.Day7.Part1.Run());
    }
    
    [Fact]
    public void Day7Part2()
    {
        Log(AdventOfCode2022.Day7.Part2.Run());
    }
    
    [Fact]
    public void Day8Part1()
    {
        Log(AdventOfCode2022.Day8.Part1.Run());
    }
    
    [Fact]
    public void Day8Part2()
    {
        Log(AdventOfCode2022.Day8.Part2.Run());
    }
    
    [Fact]
    public void Day9Part1()
    {
        Log(AdventOfCode2022.Day9.Part1.Run());
    }
    
    [Fact]
    public void Day9Part2()
    {
        Log(AdventOfCode2022.Day9.Part2.Run());
    }
    
    [Fact]
    public void Day10Part1()
    {
        Log(AdventOfCode2022.Day10.Part1.Run());
    }
    
    [Fact]
    public void Day10Part2()
    {
        Log(AdventOfCode2022.Day10.Part2.Run());
    }
    
    [Fact]
    public void Day11Part1()
    {
        Log(AdventOfCode2022.Day11.Part1.Run());
    }
    
    [Fact]
    public void Day11Part2()
    {
        Log(AdventOfCode2022.Day11.Part2.Run());
    }
    
    [Fact]
    public void Day12Part1()
    {
        Log(AdventOfCode2022.Day12.Part1.Run());
    }
    
    [Fact (Skip = "Takes too long")]
    public void Day12Part2()
    {
        Log(AdventOfCode2022.Day12.Part2.Run());
    }
    
    [Fact]
    public void Day13Part1()
    {
        Log(AdventOfCode2022.Day13.Part1.Run());
    }
    
    [Fact (Skip = "Takes too long")]
    public void Day14Part1()
    {
        Log(AdventOfCode2022.Day14.Part1.Run());
    }
    
    [Fact (Skip = "Takes too long")]
    public void Day14Part2()
    {
        Log(AdventOfCode2022.Day14.Part2.Run());
    }
    
    [Fact]
    public void Day15Part1()
    {
        Log(AdventOfCode2022.Day15.Part1.Run());
    }
    
    [Fact]
    public void Day15Part2()
    {
        Log(AdventOfCode2022.Day15.Part2.Run());
    }
    
    [Fact (Skip = "Takes too long")]
    public void Day16Part1()
    {
        Log(AdventOfCode2022.Day16.Part1.Run());
    }
    
    [Fact]
    public void Day17Part1()
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        Log(AdventOfCode2022.Day17.Part1.Run());
        watch.Stop();
        Log($"{(double)watch.ElapsedMilliseconds/1000} sec");
    }
    
    [Fact(Skip = "Dangerous to run")]
    public void Day17Part2()
    {
        var watch = System.Diagnostics.Stopwatch.StartNew();
        Log(AdventOfCode2022.Day17.Part2.Run());
        watch.Stop();
        Log($"{(double)watch.ElapsedMilliseconds/1000} sec");
    }
    
    [Fact]
    public void Day18Part1()
    {
        Log(AdventOfCode2022.Day18.Part1.Run());
    }

    private void Log(int actual)
    {
        _output.WriteLine(actual.ToString());
    }

    private void Log(long actual)
    {
        _output.WriteLine(actual.ToString());
    }

    private void Log(ulong actual)
    {
        _output.WriteLine(actual.ToString());
    }

    private void Log(string actual)
    {
        _output.WriteLine(actual);
    }
}