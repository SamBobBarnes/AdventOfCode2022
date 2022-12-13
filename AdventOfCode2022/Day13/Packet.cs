namespace AdventOfCode2022.Day13;

class Packet
{
    public Packet(string packet)
    {
        _packets = new List<Packet>();
        if (packet.Length > 1)
        {
            var internalPackets = packet
                .Substring(0,packet.Length - 1)
                .Substring(1)
                .Split(",");
        }
        else
        {
            Value = int.Parse(packet);
        }
    }

    public bool IsList => _packets.Count > 0;
    public int? Value;
    private List<Packet> _packets;
}