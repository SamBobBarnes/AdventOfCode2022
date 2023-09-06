namespace AdventOfCode2022.Day20;

public class Part1 : BasePart
{
    public static int Run()
    {
        var input = LoadInput(20,false);

        var coordinateList = new CoordinateList(input);
        
        coordinateList.MixAll();
        
        return coordinateList.FindIndexFromZero(1000) + coordinateList.FindIndexFromZero(2000) + coordinateList.FindIndexFromZero(3000);
    }
}