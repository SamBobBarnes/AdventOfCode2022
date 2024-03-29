﻿using Microsoft.VisualBasic.CompilerServices;

namespace AdventOfCode2022.Day1;

public class Part1 : BasePart
{
    public static int Run()
    {
        Start(1,1);

        List<string> textArray = LoadInput(1);
        var index = 0;
        var elves = new List<int>(){0};
        
        textArray.ForEach(x =>
        {
            if (string.IsNullOrEmpty(x))
            {
                elves.Add(0);
                index++;
            }
            else
            {
                elves[index] += Int32.Parse(x);
            }
        });

        var max = elves.Max(x => x);
        
        return max;
    }
}