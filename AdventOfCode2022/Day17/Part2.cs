﻿namespace AdventOfCode2022.Day17;

public class Part2 : BasePart
{
    public static int Run()
    {
        Start(17,2);
        var rocksToDrop = 1000000000000;
        //var rocksToDrop = 2022;
        
        var input = LoadInputChars(17, true).ToArray();
        var inputIndex = 0;
        var towerTop = -1;
        var rocksDropped = 0;
        var grid = new Grid2();
        
        while(rocksDropped < rocksToDrop)
        {
            var array = grid.DropRock(input,inputIndex, towerTop);
            inputIndex = array[0];
            towerTop = array[1];
            rocksDropped++;
        }


        return towerTop + 1;
    }
}