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

        var answerTwo = CalculateAnswerTwo();

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

    private static string CalculateAnswerTwo()
    {
        try
        {
            return "TODO";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }
}
