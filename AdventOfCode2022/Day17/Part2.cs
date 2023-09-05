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
        var rocksDropped = 0;
        var grid = new Grid2();
        
        while(rocksDropped < rocksToDrop)
        {
            if(grid.DoubleNeeded()) grid.DoubleTower();
            var rockIndex = towerTop + 4;
            var rock = grid.GetRock();
            var one = inputIndex %= length;
            var two = inputIndex %= length;
            var three = inputIndex %= length;
            grid.ShiftThree(rock, new[] { input[one], input[two], input[three] });
            inputIndex += 3;
            if (inputIndex >= input.Count) inputIndex %= input.Count;
            rockIndex -= 3;
            var collided = false;
            while (!collided)
            {
                rock = grid.ShiftRock(rock, input[inputIndex]);
                
                
                if(grid.CheckForCollision(rock, rockIndex))
                {
                    rock = grid.ShiftRock(rock, grid.ReverseDirection(input[inputIndex]));
                }
                
                rockIndex--;
                collided = grid.CheckForCollision(rock, rockIndex);
                
                if (collided)
                {
                    grid.WriteToTower(rock,rockIndex + 1);
                    towerTop = Math.Max(towerTop, rockIndex + rock.Length - 1);
                }
                
                inputIndex++;
                if (inputIndex >= length) inputIndex %= length;
            }
            rocksDropped++;
        }


        return towerTop + 1;
    }
}