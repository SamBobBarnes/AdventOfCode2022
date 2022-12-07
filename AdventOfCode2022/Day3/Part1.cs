namespace AdventOfCode2022.Day3;

public class Part1 : BasePart
{
    public static int Run()
    {
        Start(3,1);
        var input = LoadInput(3);

        var priorities = new Dictionary<char, int>()
        {
            {'a', 1}, {'b', 2}, {'c', 3}, {'d', 4}, {'e', 5}, {'f', 6}, {'g', 7}, {'h', 8}, {'i', 9}, {'j', 10},
            {'k', 11}, {'l', 12}, {'m', 13}, {'n', 14}, {'o', 15}, {'p', 16}, {'q', 17}, {'r', 18}, {'s', 19}, {'t', 20},
            {'u', 21}, {'v', 22}, {'w', 23}, {'x', 24}, {'y', 25}, {'z', 26}, {'A', 27}, {'B', 28}, {'C', 29}, {'D', 30},
            {'E', 31}, {'F', 32}, {'G', 33}, {'H', 34}, {'I', 35}, {'J', 36}, {'K', 37}, {'L', 38}, {'M', 39}, {'N', 40},
            {'O', 41}, {'P', 42}, {'Q', 43}, {'R', 44}, {'S', 45}, {'T', 46}, {'U', 47}, {'V', 48}, {'W', 49}, {'X', 50},
            {'Y', 51}, {'Z', 52}
        };

        var priority = 0;
        var sacks = CreateRuckSacks(input);
        
        sacks.ForEach(x =>
        {
            var duplicate = FindSimilarTypes(x);
            priority += priorities[duplicate];
        });
        
        return priority;
    }

    private static char FindSimilarTypes(RuckSack sack)
    {
        return sack.Compartment1.Intersect(sack.Compartment2).First();
    }

    private static List<RuckSack> CreateRuckSacks(List<string> input)
    {
        var sacks = new List<RuckSack>();
        input.ForEach(sack =>
        {
            var count = sack.Length;
            var halfCount = count / 2;
            var ruckSack = new RuckSack(
                sack.Substring(0, halfCount).ToCharArray().ToList(),
                sack.Substring(halfCount).ToCharArray().ToList()
            );
            sacks.Add(ruckSack);
        });

        return sacks;
    }
}

record RuckSack
{
    public RuckSack(List<char> compartment1,List<char> compartment2)
    {
        Compartment1 = compartment1;
        Compartment2 = compartment2;
    }
    public List<char> Compartment1 { get; set; }
    public List<char> Compartment2 { get; set; }
}