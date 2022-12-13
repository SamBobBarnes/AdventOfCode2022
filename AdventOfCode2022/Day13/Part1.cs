﻿namespace AdventOfCode2022.Day13;

public class Part1 : BasePart
{
    public static int Run()
    {
        Start(13,1);
        var input = LoadInput(13);
        var packetPairs = new List<Tuple<Packet,Packet>>();
        for (int i = 0; i < input.Count; i += 3)
        {
            packetPairs.Add(new Tuple<Packet, Packet>(new(input[i]),new(input[i+1])));
        }

        foreach (var pair in packetPairs)
        {
            Console.WriteLine(pair.Item1.ToString());
            Console.WriteLine(pair.Item2.ToString());
        }
        
        return 0;
    }
}