using AoC.Core;
using aoc2023.day02.domain;

namespace aoc2023.day02;

public class Day02Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day02Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var answerOne = CalculateAnswerOne(parsedInput.Games);
        var answerTwo = CalculateAnswerTwo(parsedInput.Games);

        return (answerOne, answerTwo);
    }

    private static string CalculateAnswerOne(IEnumerable<Game> games)
    {
        try
        {
            return $"{games.Where(g => g.IsPossible()).Select(g => g.Id).Sum()}";
        }
        catch (Exception e)
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }

    private static string CalculateAnswerTwo(IEnumerable<Game> games)
    {
        try
        {
            return $"{games.Sum(g => g.PowerOfMinimumCubes())}";
        }
        catch (Exception e)
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }
}
