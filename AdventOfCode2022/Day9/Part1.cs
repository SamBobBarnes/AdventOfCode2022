namespace AdventOfCode2022.Day9;

public class Part1 : BasePart
{
    public static int Run()
    {
        Start(9,1);
        var input = LoadInput(9);

        var moveList = input.Select(x => new Move(x)).ToList();
        var gridSize = CalculateGridSize(moveList);
        Console.WriteLine($"{gridSize.Item1},{gridSize.Item2}");
        var grid = new Grid(gridSize);
        // Console.WriteLine(grid.ToString());
        moveList.ForEach(m =>
        {
            grid.Move(m);
            // Console.WriteLine(grid.ToString());
        });
        
        return grid.VisitedPositions();
    }

    private static Tuple<int, int, int, int> CalculateGridSize(List<Move> moves)
    {
        var height = 0;
        var width = 0;
        var x = 0;
        var y = 0;
        var startX = 0;
        var startY = 0;

        moves.ForEach(m =>
        {
            switch (m.Direction)
            {
                case Direction.Up:
                    y += m.Spaces;
                    if (y > height) height = y;
                    break;
                case Direction.Down:
                    y -= m.Spaces;
                    if (y < 0)
                    {
                        height += -y;
                        startY += -y;
                        y = 0;
                    }
                    break;
                case Direction.Right:
                    x += m.Spaces;
                    if (x > width) width = x;
                    break;
                case Direction.Left:
                    x -= m.Spaces;
                    if (x < 0)
                    {
                        width += -x;
                        startX += -x;
                        x = 0;
                    }
                    break;
            }
        });
        
        return new Tuple<int, int, int, int>(width + 1, height + 1, startX, startY);
    }
}

