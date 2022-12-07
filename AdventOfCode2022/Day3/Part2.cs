namespace AdventOfCode2022.Day3;

public class Part2 : BasePart
{
    public static int Run()
    {
        Start(3,2);
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
        var groups = CreateElfGroups(input);
        
        groups.ForEach(x =>
        {
            var duplicate = FindSimilarTypes(x);
            priority += priorities[duplicate];
        });
        
        return priority;
    }

    private static char FindSimilarTypes(ElfGroup group)
    {
        return group.Group1.Intersect(group.Group2).Intersect(group.Group3).First();
    }

    private static List<ElfGroup> CreateElfGroups(List<string> input)
    {
        var groups = new List<ElfGroup>();

        for (int i = 0; i < input.Count; i += 3)
        {
            groups.Add(new(
                input[i].ToCharArray().ToList(),
                input[i+1].ToCharArray().ToList(),
                input[i+2].ToCharArray().ToList()
            ));
        }

        return groups;
    }
}

record ElfGroup
{
    public ElfGroup(List<char> group1, List<char> group2, List<char> group3)
    {
        Group1 = group1;
        Group2 = group2;
        Group3 = group3;
    }
    public List<char> Group1 { get; set; }
    public List<char> Group2 { get; set; }
    public List<char> Group3 { get; set; }
}