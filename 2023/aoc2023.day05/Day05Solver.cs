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
            var locations = new List<long>();

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

    private static string CalculateAnswerTwo(Map map, List<long> seeds)
    {
        try
        {
            List<Task<long>> minLocationTasks = new();

            for (var i = 0; i < seeds.Count; i += 2)
            {
                var seedMin = seeds[i];
                var seedMax = seedMin + seeds[i + 1];
                
                for (var j = seedMin; j < seedMax + 1; j += 10000000)
                {
                    minLocationTasks.Add(GetMinLocationAsync(map, j, Math.Min(j + 10000000, seedMax)));
                }
            }

            var minLocations = Task.Run(() => Task.WhenAll(minLocationTasks)).GetAwaiter().GetResult();

            return $"{minLocations.Min()}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }

    private static Task<long> GetMinLocationAsync(Map map, long from, long to)
    {
        var task = Task.Factory.StartNew(() =>
        {
            var minLocation = long.MaxValue;

            Console.WriteLine($"Starting seed range from {from} to {to}.");

            for (var j = from; j < to + 1; j++)
            {
                var location = map.GetDestination(j);
                minLocation = Math.Min(minLocation, location);
            }

            Console.WriteLine($"Finished seed range from {from} to {to}. Min location is {minLocation}.");

            return minLocation;
        });

        return task;
    }
}
