using AoC.Core;
using aoc2023.day04.domain;

namespace aoc2023.day04;

public class Day04Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day04Solver(IParser<Input> parser)
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
            return "TODO";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }
}
