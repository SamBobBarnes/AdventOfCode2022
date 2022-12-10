namespace AdventOfCode2022.Day10;

class Cpu2 : Cpu
{
	public Cpu2()
	{
        Screen = new List<List<bool>>();
        for(int i = 0; i < 6; i++)
        {
            Screen.Add(new List<bool>());
            for (int j = 0; j < 40; j++)
            {
                Screen[i].Add(false);
            }
        }
        DrawPixel();
    }

    private List<List<bool>> Screen;

    public new void Execute(string operation, int value = 0)
    {
        if (operation == "noop")
        {
            IncrementCycle();
        }
        if (operation == "addx")
        {
            IncrementCycle();

            
            X += value;
            IncrementCycle();
        }
    }

    private void IncrementCycle()
    {
        Cycle++;
        DrawPixel();
    }

    private void DrawPixel()
    {
        var i = (int)Math.Floor((double)Cycle / (double)40);
        var j = Cycle % 40;
        if (X == (Cycle % 40) || X - 1 == (Cycle % 40) || X + 1 == (Cycle % 40))
        {
            Screen[i][j] = true;
        }
    }

    public new string ToString()
    {
        var screen = "";
        for (int i = 0; i < 6; i++)
        {
            var row = "";
            for (int j = 0; j < 40; j++)
            {
                if (Screen[i][j]) row += "#";
                else row += ".";
            }
            screen += row + "\r\n";
        }

        return screen;
    }
}

