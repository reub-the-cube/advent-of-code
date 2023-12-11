using AoC.Core;
using aoc2023.day11.domain;

namespace aoc2023.day11;

public class Day11Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day11Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var answerOne = CalculateAnswerOne(parsedInput.GalaxyImageInput);
        var answerTwo = CalculateAnswerTwo(parsedInput.GalaxyImageInput);

        return (answerOne, answerTwo);
    }

    private static string CalculateAnswerOne(List<string> galaxyImageInput)
    {
        try
        {
            var expandedGalaxyImage = GalaxyImage.Build(galaxyImageInput);
            var sumOfShortestPaths = expandedGalaxyImage.GetSumOfShortestPaths(2);
            return $"{sumOfShortestPaths}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }

    private static string CalculateAnswerTwo(List<string> galaxyImageInput)
    {
        try
        {
            var expandedGalaxyImage = GalaxyImage.Build(galaxyImageInput);
            var sumOfShortestPaths = expandedGalaxyImage.GetSumOfShortestPaths(1000000);
            return $"{sumOfShortestPaths}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }
}
