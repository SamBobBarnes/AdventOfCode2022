using System.Linq;

namespace AdventOfCode2022.Day13;

class Comparisons
{
    private static readonly int  _right = 1;
    private static readonly int _wrong = -1;
    private static readonly int _tied = 0;

    public static int ComparePackets(Packet a, Packet b)
    {
        if (!a.IsList && !b.IsList)
        {
            return a.Value.CompareTo(b.Value);
        }

        // From this point on, AT LEAST ONE of the two packets is a list.
        var leftList = ConvertToList(a);
        var rightList = ConvertToList(b);
        var lowerBoundLimit = Math.Min(leftList.Packets.Count, rightList.Packets.Count);

        // Both lists were empty, there's nothing to compare against.
        if (leftList.Packets.Count == rightList.Packets.Count && lowerBoundLimit == 0)
        {
            return _tied;
        }

        // From this point on, both lists have numbers in them, so let's compare each number.
        for (var i = 0; i < lowerBoundLimit; ++i)
        {
            var comparisonResult = ComparePackets(leftList.Packets[i], rightList.Packets[i]);
            if (comparisonResult != 0)
            {
                return comparisonResult;
            }
        }

        // We've reached the end of the shortest list. Comparing both lists' length will return 0 if both had the same length.
        return leftList.Packets.Count.CompareTo(rightList.Packets.Count);
    }

    private static Packet ConvertToList(Packet x)
    {
        if (x.IsList) return x;
        return new Packet($"[{x.Value}]");
    }
}

