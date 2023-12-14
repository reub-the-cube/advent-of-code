using AoC.Core;
using aoc2023.day14.domain;

namespace aoc2023.day14;

public class Day14Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day14Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var answerOne = CalculateAnswerOne(parsedInput.RockFormation);
        var answerTwo = CalculateAnswerTwo(parsedInput.RockFormation);

        return (answerOne, answerTwo);
    }

    private static string CalculateAnswerOne(List<string> rockFormation)
    {
        try
        {
            var platform = new Platform(rockFormation);
            platform.TiltNorth();
            var load = platform.CalculateLoad();
            return $"{load}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }

    private static string CalculateAnswerTwo(List<string> rockFormation)
    {
        try
        {
            var platform = new Platform(rockFormation);
            platform.RunCycles(1000000000);
            var load = platform.CalculateLoad();
            return $"{load}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }
}
