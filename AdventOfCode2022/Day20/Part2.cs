namespace AdventOfCode2022.Day20;

public class Part2 : BasePart
{
    public static long Run()
    {
        var input = LoadInput(20,false);

        var coordinateList = new CoordinateList(input);
        coordinateList.MultiplyAll(811589153);

        for (int i = 0; i < 10; i++)
        {
            coordinateList.MixAll();
            coordinateList.UnVisitAll();
        }
        
        return coordinateList.FindIndexFromZero(1000) + coordinateList.FindIndexFromZero(2000) + coordinateList.FindIndexFromZero(3000);
    }
    
}