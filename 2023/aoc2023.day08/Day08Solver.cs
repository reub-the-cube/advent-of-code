using AoC.Core;
using aoc2023.day08.domain;

namespace aoc2023.day08;

public class Day08Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day08Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var answerOne = CalculateAnswerOne(parsedInput.NodeNetwork, parsedInput.NodeSelectorSequence);

        var answerTwo = CalculateAnswerTwo(parsedInput.NodeNetwork, parsedInput.NodeSelectorSequence);

        return (answerOne, answerTwo);
    }

    private static string CalculateAnswerOne(Dictionary<string, Node> network, char[] nodeSelectorSequence)
    {
        try
        {
            var navigator = new Navigator(network);
            var numberOfSteps = navigator.GetSteps("AAA", "ZZZ", nodeSelectorSequence);
            return $"{numberOfSteps}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }

    private static string CalculateAnswerTwo(Dictionary<string, Node> network, char[] nodeSelectorSequence)
    {
        try
        {
            // Starter nodes start with A
            // Finisher nodes end with Z
            // They combine on the lower common multiple - of the sequence index and number of steps
            var navigator = new Navigator(network);
            var destinations = network.Where(n => n.Key.EndsWith("Z")).Select(n => n.Key).ToList();
            var numberOfStepsForEachStartingNode = new List<int>();

            foreach (KeyValuePair<string, Node> startingNode in network.Where(n => n.Key.EndsWith("A")))
            {
                var numberOfSteps = navigator.GetSteps(startingNode.Key, destinations, nodeSelectorSequence);
                numberOfStepsForEachStartingNode.Add(numberOfSteps);
            }
            return $"{GetLowestCommonMultiple(numberOfStepsForEachStartingNode.Select(n => (long)n).ToArray())}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }

    private static long GetLowestCommonMultiple(long[] numbers)
    {
        return numbers.Aggregate(GetLowestCommonMultiple);
    }
    private static long GetLowestCommonMultiple(long a, long b)
    {
        return Math.Abs(a * b) / GetGreatestCommonDivisor(a, b);
    }
    private static long GetGreatestCommonDivisor(long a, long b)
    {
        return b == 0 ? a : GetGreatestCommonDivisor(b, a % b);
    }
}
