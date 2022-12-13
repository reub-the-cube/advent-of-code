using AoC.Core;
using aoc2022.day13.domain;
using System.Diagnostics;

namespace aoc2022.day13
{
    public class Parser : IParser<List<Pair>>
    {
        public List<Pair> ParseInput(string[] input)
        {
            var packetChunks = input.Chunk(3).ToList();
            var packetPairs = new List<Pair>();
            for (int i = 0; i < packetChunks.Count; i++)
            {
                packetPairs.Add(new Pair(packetChunks[i][0], packetChunks[i][1], i + 1));
            }
            return packetPairs;
        }

        /// <summary>
        /// Compare a list of packets with another list of packets.
        /// </summary>
        /// <param name="packetOne"></param>
        /// <param name="packetTwo"></param>
        /// <returns>If packets are in the correct order, -1 will be returned. If packets are in the wrong order, 1 will be returned. Otherwise, 0.</returns>
        public static int ComparePacketData(string packetOne, string packetTwo)
        {
            var packetOneAsList = MapStringToList(packetOne);
            var packetTwoAsList = MapStringToList(packetTwo);

            var lengthOfShortestList = Math.Min(packetOneAsList.Count, packetTwoAsList.Count);

            for (int i = 0; i < lengthOfShortestList; i++)
            {
                var packetOnePartIsInt = int.TryParse(packetOneAsList[i], out int leftSide);
                var packetTwoPartIsInt = int.TryParse(packetTwoAsList[i], out int rightSide);

                if (!packetOnePartIsInt || !packetTwoPartIsInt)
                {
                    var outcome = ComparePacketData(packetOneAsList[i], packetTwoAsList[i]);
                    if (outcome != 0) return outcome;
                }
                else if (leftSide < rightSide)
                {
                    return -1;
                }
                else if (rightSide < leftSide)
                {
                    return 1;
                }
            }

            if (packetOneAsList.Count > lengthOfShortestList)
            {
                return 1;
            }

            if (packetTwoAsList.Count > lengthOfShortestList)
            {
                return -1;
            }

            return 0;
        }

        public static List<string> MapStringToList(string flatString)
        {
            if (flatString.StartsWith('['))
            {
                flatString = flatString[1..];
            }

            if (flatString.EndsWith(']'))
            {
                flatString = flatString[..^1];
            }

            var items = new List<string>();

            // Walk the string
            var insideBracketCount = 0;
            var itemStartIndex = -1;
            for (int i = 0; i < flatString.Length; i++)
            {
                if (flatString[i] == '[') insideBracketCount++;
                if (flatString[i] == ']') insideBracketCount--;

                if (insideBracketCount == 0 && flatString[i] == ',')
                {
                    var itemToAdd = flatString[(itemStartIndex + 1)..i];
                    if (!string.IsNullOrEmpty(itemToAdd))
                    {
                        items.Add(itemToAdd);
                    }
                    itemStartIndex = i;
                }
                else if (i == flatString.Length - 1)
                {
                    var itemToAdd = flatString[(itemStartIndex + 1)..];
                    if (!string.IsNullOrEmpty(itemToAdd))
                    {
                        items.Add(itemToAdd);
                    }
                }
            }
            
            return items;
        }
    }
}
