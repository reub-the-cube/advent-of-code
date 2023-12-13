using AoC.Core;
using aoc2023.day13.domain;

namespace aoc2023.day13;

public class Day13Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day13Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var answerOne = CalculateAnswerOne(parsedInput.Patterns);
        var answerTwo = CalculateAnswerTwo(parsedInput.Patterns);

        return (answerOne, answerTwo);
    }

    private static string CalculateAnswerOne(List<Pattern> patterns)
    {
        try
        {
            var sumOfSummarizeScores = patterns.Sum(p => p.SummarizeScore());
            return $"{sumOfSummarizeScores}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }

    private static string CalculateAnswerTwo(List<Pattern> patterns)
    {
        try
        {
            var sumOfSummarizeScores = patterns.Sum(p => p.SummarizeScore(true));
            return $"{sumOfSummarizeScores}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }
}
