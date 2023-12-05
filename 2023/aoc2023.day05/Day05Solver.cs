using AoC.Core;
using aoc2023.day05.domain;

namespace aoc2023.day05;

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

        var mapChain = 
            parsedInput.Maps["seed-to-soil"].CreateNewMapWithDependency(
                parsedInput.Maps["soil-to-fertilizer"].CreateNewMapWithDependency(
                    parsedInput.Maps["fertilizer-to-water"].CreateNewMapWithDependency(
                        parsedInput.Maps["water-to-light"].CreateNewMapWithDependency(
                            parsedInput.Maps["light-to-temperature"].CreateNewMapWithDependency(
                                parsedInput.Maps["temperature-to-humidity"].CreateNewMapWithDependency(
                                    parsedInput.Maps["humidity-to-location"]))))));

        var answerOne = CalculateAnswerOne(mapChain, parsedInput.Seeds);
        var answerTwo = CalculateAnswerTwo();

        return (answerOne, answerTwo);
    }

    private static string CalculateAnswerOne(Map map, List<int> seeds)
    {
        try
        {
            var locations = new List<int>();

            foreach (var seed in seeds)
            {
                locations.Add(map.GetDestination(seed));
            }

            return $"{locations.Min()}";
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
