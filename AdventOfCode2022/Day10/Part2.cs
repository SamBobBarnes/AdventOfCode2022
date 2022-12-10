namespace AdventOfCode2022.Day10;

class Part2 : BasePart
{
	public static string Run()
	{
		Start(10,1);
		var input = LoadInput(10);
		var ops = input.Select(x => x.Split(" ").ToList()).ToList();

		var cpu = new Cpu2();

		ops.ForEach(x =>
		{
			if (x.Count > 1) cpu.Execute(x[0], int.Parse(x[1]));
			else cpu.Execute(x[0]);
		});

		return cpu.ToString();
	}
}