﻿namespace AdventOfCode2022.Day11;

public class Part1 : BasePart
{
    public static int Run()
    {
        Start(11,1);
        var input = LoadInput(11);
        var bunch = new MonkeyBunch(input);
        for (int i = 0; i < 20; i++)
        {
            bunch.ExecuteRound();
        }
        
        Console.WriteLine(bunch.ToString());

        return bunch.GetMonkeyBusiness();
    }
}