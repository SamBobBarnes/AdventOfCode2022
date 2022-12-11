namespace AdventOfCode2022.Day11;

public class Part2 : BasePart
{
    public static int Run()
    {
        Start(11,1);
        var input = LoadInput(11);
        // var bunch = new MonkeyBunch2(input);
        // for (int i = 0; i < 20; i++)
        // {
        //     bunch.ExecuteRound();
        // }
        //
        // Console.WriteLine(bunch.ToString());
        
        //return bunch.GetMonkeyBusiness();

        var hex1 = new Hexadecimal(675);
        Console.WriteLine(hex1.ToString());
        var hex2 = new Hexadecimal(26);
        Console.WriteLine(hex2.ToString());
        var hex3 = Hexadecimal.Modulus(hex1, hex2);
        Console.WriteLine(hex3.ToString());
        return 0;
    }
}