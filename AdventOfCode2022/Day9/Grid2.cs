namespace AdventOfCode2022.Day9;

class Grid2 : Grid
{
    private readonly int _tailLength = 9;
    
    public Grid2(Tuple<int, int, int, int> gridSize): base(gridSize)
    {
        Tail = new List<Position>();
        for (int i = 0; i < _tailLength; i++)
        {
            Tail.Add(new Position(gridSize.Item3, gridSize.Item4));
        }
    }

    private List<Position> Tail;
    
    public new string ToString()
    {
        var grid = "";
        for (int i = 0; i < Height; i++)
        {
            var row = "";
            for (int j = 0; j < Width; j++)
            {
                if (Head.Locate(j, i)) row += "H";
                else if (Tail[0].Locate(j, i)) row += "1";
                else if (Tail[1].Locate(j, i)) row += "2";
                else if (Tail[2].Locate(j, i)) row += "3";
                else if (Tail[3].Locate(j, i)) row += "4";
                else if (Tail[4].Locate(j, i)) row += "5";
                else if (Tail[5].Locate(j, i)) row += "6";
                else if (Tail[6].Locate(j, i)) row += "7";
                else if (Tail[7].Locate(j, i)) row += "8";
                else if (Tail[8].Locate(j, i)) row += "9";
                else if (GridCells[i][j].Used) row += "#";
                else row += ".";
            }

            grid = row + "\r\n" + grid;
        }
        return grid;
    }
    
    public void Move(Move move)
    {
        while (move.Remaining() > 0)
        {
            switch (move.Where().Item1)
            {
                case Direction.Up:
                    Head.Y += move.Where().Item2;
                    MoveTail(Head, 0);
                    break;
                case Direction.Right:
                    Head.X += move.Where().Item2;
                    MoveTail(Head, 0);
                    break;
            }

            GridCells[Tail[8].Y][Tail[8].X].Use();
            // Console.WriteLine(ToString());
        }
    }

    private void MoveTail(Position head, int tail)
    {
        //dont move tail
        if (Tail[tail].X == head.X && Tail[tail].Y == head.Y) return;
        else if (Tail[tail].X + 1 == head.X && Tail[tail].Y + 1 == head.Y) return;
        else if (Tail[tail].X + 1 == head.X && Tail[tail].Y == head.Y) return;
        else if (Tail[tail].X + 1 == head.X && Tail[tail].Y - 1 == head.Y) return;
        else if (Tail[tail].X == head.X && Tail[tail].Y - 1 == head.Y) return;
        else if (Tail[tail].X - 1 == head.X && Tail[tail].Y - 1 == head.Y) return;
        else if (Tail[tail].X - 1 == head.X && Tail[tail].Y == head.Y) return;
        else if (Tail[tail].X - 1 == head.X && Tail[tail].Y + 1 == head.Y) return;
        else if (Tail[tail].X == head.X && Tail[tail].Y + 1 == head.Y) return;
        
        //move tail
        
        ChaseHead(head, tail);

        if (tail < _tailLength-1)
        {
            MoveTail(Tail[tail], tail + 1);
        }
    }

    private void ChaseHead(Position head, int tail)
    {
        if ((Tail[tail].X - head.X >= 1 && Tail[tail].Y - head.Y >= 2) 
            || (Tail[tail].X - head.X >= 2 && Tail[tail].Y - head.Y >= 1))// lower left
        {
            Tail[tail].Y--;
            Tail[tail].X--;
        }
        else if ((head.X - Tail[tail].X >= 1 && head.Y - Tail[tail].Y >= 2) 
                || (head.X - Tail[tail].X >= 2 && head.Y - Tail[tail].Y >= 1))// upper right
        {
            Tail[tail].Y++;
            Tail[tail].X++;
        }
        else if ((head.X - Tail[tail].X >= 1 && Tail[tail].Y - head.Y >= 2) 
                 || (head.X - Tail[tail].X >= 2 && Tail[tail].Y - head.Y >= 1))// lower right
        {
            Tail[tail].Y--;
            Tail[tail].X++;
        }
        else if ((Tail[tail].X - head.X >= 1 && head.Y - Tail[tail].Y >= 2) 
                 || (Tail[tail].X - head.X >= 2 && head.Y - Tail[tail].Y >= 1))// upper left
        {
            Tail[tail].Y++;
            Tail[tail].X--;
        }
        else if (Tail[tail].X - head.X >= 2) Tail[tail].X--;
        else if (head.X - Tail[tail].X >= 2) Tail[tail].X++;
        else if (head.Y - Tail[tail].Y >= 2) Tail[tail].Y++;
        else if (Tail[tail].Y - head.Y >= 2) Tail[tail].Y--;
    }
    
}