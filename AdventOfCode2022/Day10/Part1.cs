namespace AdventOfCode2022.Day10;

public class Part1 : BasePart
{
	public static int Run()
	{
		Start(10,1);
		var input = LoadInput(10);
		var ops = input.Select(x => x.Split(" ").ToList()).ToList();

		var cpu = new Cpu();

		ops.ForEach(x =>
		{
			if (x.Count > 1) cpu.Execute(x[0], int.Parse(x[1]));
			else cpu.Execute(x[0]);
		});

		Console.WriteLine(cpu.ToString());

		return cpu.GetSum();
	}
}