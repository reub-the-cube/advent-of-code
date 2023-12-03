using AoC.Core;
using aoc2023.day03.domain;

namespace aoc2023.day03;

public class Day03Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day03Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var answerOne = CalculateAnswerOne(parsedInput.EngineParts);
        var answerTwo = CalculateAnswerTwo(parsedInput.EngineParts);

        return (answerOne, answerTwo);
    }

    private static string CalculateAnswerOne(List<EnginePart> engineParts)
    {
        try
        {
            var partsWithAdjacentSymbol = engineParts
                .Where(e => PartChecker.IsPartAdjacentToASymbol(e, engineParts))
                .ToList();

            var sumOfPartsWithAdjacentSymbol = partsWithAdjacentSymbol
                .Sum(e => int.Parse(e.PartValue));

            return $"{sumOfPartsWithAdjacentSymbol}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }

    private static string CalculateAnswerTwo(List<EnginePart> engineParts)
    {
        try
        {
            var gearRatios = engineParts
                .Select(e => PartChecker.GetGearRatio(e, engineParts))
                .Where(r => r > 0);

            return $"{gearRatios.Sum()}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }
}
