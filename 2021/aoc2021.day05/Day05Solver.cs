using AoC.Core;
using aoc2021.day05.domain;

namespace aoc2021.day05;

public class Day05Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day05Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var answerOne = CalculateAnswerOne();
        var answerTwo = CalculateAnswerTwo();

        return (answerOne, answerTwo);
    }

    private static string CalculateAnswerOne()
    {
        try
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }
}
