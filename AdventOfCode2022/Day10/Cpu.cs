namespace AdventOfCode2022.Day10;

class Cpu
{
	public Cpu(int x)
	{
		X = x;
		Cycle = 0;
		SignalStrength = new Dictionary<int, int>();
	}

	public Cpu()
	{
		X = 1;
		Cycle = 0;
        SignalStrength = new Dictionary<int, int>();
    }

	protected int X;
    protected int Cycle;
	private Dictionary<int, int> SignalStrength;

	public void Execute(string operation, int value = 0)
	{
		if (operation == "noop")
		{
			IncrementCycle();
        }
		if (operation == "addx")
		{
			IncrementCycle();

			IncrementCycle();
            X += value;
		}
	}

	public string Status()
	{
		return $"X:{X}\r\nCycle:{Cycle}";
	}

	private void IncrementCycle()
	{
		Cycle++;
		LogSignal();
	}

	private void LogSignal()
	{
		if ((Cycle-20) % 40 == 0)
		{
			SignalStrength.Add(Cycle, X);
		}
	}

	public int GetSum()
	{
        var sum = 0;

        foreach (var signal in SignalStrength)
        {
            sum += signal.Key * signal.Value;
        }

        return sum;
    }

	public new string ToString()
	{
		var signals = "";

		foreach(var signal in SignalStrength)
		{
			signals += $"{signal.Key} x {signal.Value} = {signal.Key*signal.Value}\r\n";
		}

		return signals;
	}
}

