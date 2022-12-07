namespace AdventOfCode2022.Day2;

public class Part1 : BasePart
{
    public static int Run()
    {
        Start(2,1);
        var input = System.IO.File.ReadAllText(@"C:\Users\sb17057\Repos\AdventOfCode\2022\AdventOfCode2022\AdventOfCode2022\Day2\Input.txt").Split("\r\n").ToList();

        var score = 0;
        input.ForEach(round =>
        {
            var moves = round.Split(" ");
            score += ScoreRound(moves[0], moves[1]);
        });
        
        return score;
    }

    private static int ScoreRound(string them, string me)
    {
        var score = 0;

        switch (me)
        {
            case "X": //Rock
                score += 1;
                switch (them)
                {
                    case "A": //Rock
                        score += 3; //Draw
                        break;
                    case "B": //Paper
                        score += 0; //Lose
                        break;
                    case "C": //Scissors
                        score += 6; //Win
                        break;
                }
                break;
            case "Y": //Paper
                score += 2;
                switch (them)
                {
                    case "A": //Rock
                        score += 6; //Win
                        break;
                    case "B": //Paper
                        score += 3; //Draw
                        break;
                    case "C": //Scissors
                        score += 0; //Lose
                        break;
                }
                break;
            case "Z": //Scissors
                score += 3;
                switch (them)
                {
                    case "A": //Rock
                        score += 0; //Lose
                        break;
                    case "B": //Paper
                        score += 6; //Win
                        break;
                    case "C": //Scissors
                        score += 3; //Draw
                        break;
                }
                break;
        }
        return score;
    }
}