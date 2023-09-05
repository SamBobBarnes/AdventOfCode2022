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

    private void Log(int actual)
    {
        _output.WriteLine(actual.ToString());
    }

    private void Log(string actual)
    {
        _output.WriteLine(actual);
    }
}