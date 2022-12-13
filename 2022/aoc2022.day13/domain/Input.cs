using System;

namespace aoc2022.day13.domain
{
    public readonly record struct Pair(string PacketOne, string PacketTwo, int Index)
    {
        public bool IsInCorrectOrder => Parser.ComparePacketData(PacketOne, PacketTwo) != 1;
    }

    public readonly record struct SinglePacket(string Packet, int Index);
}