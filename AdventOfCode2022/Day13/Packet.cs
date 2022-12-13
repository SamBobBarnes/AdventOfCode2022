﻿namespace AdventOfCode2022.Day13;

class Packet
{
    public Packet(string packet) : this()
    {
        if (packet.Length > 1)
        {
            var packetChars = packet.ToCharArray().ToList();
            packetChars.RemoveAt(0);
            packetChars.RemoveAt(packetChars.Count-1);

            var packetList = new List<string>();
            var inList = false;
            var index = 0;
            var depth = 0;
            foreach (var c in packetChars)
            {
                if (c == '[')
                {
                    if (inList)
                    {
                        packetList[index] += c;
                    }
                    else
                    {
                        inList = true;
                        packetList.Add("[");
                    }
                    depth++;
                }
                else if (c == ']')
                {
                    packetList[index] += c;
                    if (depth == 1)
                    {
                        index++;
                        inList = false;
                    }
                    depth--;
                }
                else if (c == ',')
                {
                    if (!inList) continue;
                    packetList[index] += c;
                }
                else
                {
                    if (!inList)
                    {
                        packetList.Add(c.ToString());
                        index++;
                    }
                    else
                    {
                        packetList[index] += c;
                    }
                }
            }

            foreach (var item in packetList)
            {
                _packets.Add(new Packet(item));
            }
        }
        else
        {
            Value = int.Parse(packet);
            IsList = false;
        }
    }

    private Packet()
    {
        _packets = new List<Packet>();
        IsList = true;
    }

    public bool IsList;
    public int Value;
    private List<Packet> _packets;

    public new string ToString()
    {
        if (!IsList) return Value.ToString();
        var result = "[";
        foreach (var packet in _packets)
        {
            result += packet.ToString();
            result += ",";
        }
        if(result.Length > 1)result = result.Substring(0, result.Length - 1);
        result += "]";
        return result;
    }
    
    // public Packet(IEnumerable<Packet> packets) : this()
    // {
    //     _packets.AddRange(packets);
    // }
    //
    // public Packet(IEnumerable<string> packets) : this()
    // {
    //     
    // }
    //
    // public Packet(int x) : this()
    // {
    //     _packets = new List<Packet>();
    //     Value = x;
    // }
    
    // public void AddPacket(int x)
    // {
    //     _packets.Add(new Packet(x));
    // }
    //
    // public void AddPacket(string x)
    // {
    //     _packets.Add(new Packet(x));
    // }
    //
    // public void AddPacket(IEnumerable<Packet> x)
    // {
    //     _packets.Add(new Packet(x));
    // }
    //
    // public void AddPacket(IEnumerable<string> x)
    // {
    //     _packets.Add(new Packet(x));
    // }
    
    
}