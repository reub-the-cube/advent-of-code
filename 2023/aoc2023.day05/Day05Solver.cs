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
        var answerTwo = CalculateAnswerTwo(mapChain, parsedInput.Seeds);

        return (answerOne, answerTwo);
    }

    private static string CalculateAnswerOne(Map map, List<long> seeds)
    {
        try
        {
            var minLocation = GetMinimumDestinationForSeedRanges(map, seeds.Select(s => (s, s)).ToList());

            return $"{minLocation}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }

    private static string CalculateAnswerTwo(Map map, List<long> seeds)
    {
        try
        { 
            var minLocation = GetMinimumDestinationForSeedRanges(map, GetSeedRangesFromSeeds(seeds));

            return $"{minLocation}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }

    private static long GetMinimumDestinationForSeedRanges(Map map, List<(long Min, long Max)> seedRanges)
    {
        return seedRanges.Min(r => GetMinimumDestinationForSeedRange(map, r.Min, r.Max));
    }

    private static long GetMinimumDestinationForSeedRange(Map map, long min, long max)
    {
        return map.GetDestinations(min, max).Min(d => d.From);
    }

    private static List<(long Min, long Max)> GetSeedRangesFromSeeds(List<long> seeds)
    {
        // Chunk into pairs -> first item is the min, second is the max, for the seed range
        return seeds.Chunk(2).Select(c => (c[0], c[0] + c[1])).ToList();
    }
}
