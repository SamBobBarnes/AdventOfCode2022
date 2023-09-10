namespace AdventOfCode2022.Day22;

public class Part1: BasePart
{
    public static int Run()
    {
        var input = LoadInput(22, true);
        
        var room = new Room(input);
        
        var keepMoving = true;
        
        while (keepMoving)
        {
            room.MoveCharacter();
            keepMoving = room.Rotate();
        }
        
        room.MoveCharacter();
        
        return 0;
    }
}