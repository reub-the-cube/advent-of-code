using AoC.Core;
using aoc2023.day16.domain;

namespace aoc2023.day16;

public class Day16Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day16Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var answerOne = CalculateAnswerOne(parsedInput.ContraptionLayout);
        var answerTwo = CalculateAnswerTwo();

        return (answerOne, answerTwo);
    }

    private static string CalculateAnswerOne(List<string> contraptionLayout)
    {
        try
        {
            var contraption = new Contraption(contraptionLayout);
            contraption.FillWithLight(0, 0, Enums.Direction.Right);
            var energisedTiles = contraption.UniqueEnergisedTiles;
            return $"{energisedTiles.Count}";
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
