namespace AdventOfCode2022.Day17;

public class Part2 : BasePart
{
    public static int Run()
    {
        Start(17,2);
        // var rocksToDrop = 1000000000000;
        var rocksToDrop = 2022;
        
        var input = LoadInputChars(17, true);
        var length = input.Count;
        var inputIndex = 0;
        var towerTop = -1;
        var rockIndex = 3; //bottom of rock
        var rocksDropped = 0;
        var grid = new Grid2();
        
        while(rocksDropped <= rocksToDrop)
        {
            var rock = grid.GetRock();
            grid.ShiftThree(rock, new[] { input[inputIndex], input[inputIndex + 1], input[inputIndex + 2] });
            inputIndex += 3;
        }


        return 0;
    }
}