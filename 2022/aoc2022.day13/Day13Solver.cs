using AoC.Core;
using aoc2022.day13.domain;

namespace aoc2022.day13;

public class Day13Solver : IDaySolver
{
    private readonly IParser<List<Pair>> _parser;

    public Day13Solver(IParser<List<Pair>> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var answerOnePairsInOrder = parsedInput.Where(pair => pair.IsInCorrectOrder);

        // Order parsed input
        var answerTwoOrderedPackets = OrderPackets(parsedInput);
        var dividerPacketIndexOne = answerTwoOrderedPackets.IndexOf("[[2]]") + 1;
        var dividerPacketIndexTwo = answerTwoOrderedPackets.IndexOf("[[6]]") + 1;

        var answerOne = answerOnePairsInOrder.Aggregate(0, (a, b) => a + b.Index);
        var answerTwo = dividerPacketIndexOne * dividerPacketIndexTwo;

        return (answerOne.ToString(), answerTwo.ToString());
    }

    private static List<string> OrderPackets(List<Pair> input)
    {
        var allPackets = input
            .SelectMany(s => new List<string> { s.PacketOne, s.PacketTwo })
            .Union(new[] { "[[2]]", "[[6]]" })
            .ToList();

        var runningPackets = new List<string>
        {
            allPackets[0]
        };

        foreach (var packet in allPackets.Skip(1))
        {
            var indexToInsert = -1;
            for (int i = 0; i < runningPackets.Count; i++)
            {
                var outcome = Parser.ComparePacketData(packet, runningPackets[i]);
                if (outcome == -1)
                {
                    indexToInsert = i;
                    break;
                }
            }

            if (indexToInsert == -1)
            {
                runningPackets.Add(packet);
            }
            else
            {
                runningPackets.Insert(indexToInsert, packet);
            }
        }

        return runningPackets;
    }
}
