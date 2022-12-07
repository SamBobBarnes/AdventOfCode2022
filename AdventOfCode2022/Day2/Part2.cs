namespace AdventOfCode2022.Day2;

public class Part2 : BasePart
{
    public static int Run()
    {
        Start(2,2);
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
            case "X": //Lose
                score += 0;
                switch (them)
                {
                    case "A": //Rock
                        score += 3; 
                        break;
                    case "B": //Paper
                        score += 1; 
                        break;
                    case "C": //Scissors
                        score += 2; 
                        break;
                }
                break;
            case "Y": //Draw
                score += 3;
                switch (them)
                {
                    case "A": //Rock
                        score += 1; 
                        break;
                    case "B": //Paper
                        score += 2; 
                        break;
                    case "C": //Scissors
                        score += 3; 
                        break;
                }
                break;
            case "Z": //Win
                score += 6;
                switch (them)
                {
                    case "A": //Rock
                        score += 2; 
                        break;
                    case "B": //Paper
                        score += 3; 
                        break;
                    case "C": //Scissors
                        score += 1; 
                        break;
                }
                break;
        }
        return score;
    }
}