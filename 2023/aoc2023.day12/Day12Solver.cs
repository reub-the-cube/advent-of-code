using AoC.Core;
using aoc2023.day12.domain;

namespace aoc2023.day12;

public class Day12Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day12Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var answerOne = CalculateAnswerOne(parsedInput.SpringConditions);
        var answerTwo = CalculateAnswerTwo();

        return (answerOne, answerTwo);
    }

    private static string CalculateAnswerOne(List<SpringConditionsRecord> springConditions)
    {
        try
        {
            long arrangementCount = 0;

            foreach (var springCondition in springConditions)
            {
                var arrangements = SpringArrangements.GetPossibleArrangements(springCondition.SpringConditions, springCondition.ContiguousCount);
                arrangementCount += arrangements.Count;
            }

            return $"{arrangementCount}";
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
