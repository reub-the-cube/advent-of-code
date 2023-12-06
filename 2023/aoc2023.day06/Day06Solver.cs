using AoC.Core;
using aoc2023.day06.domain;

namespace aoc2023.day06;

public class Day06Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day06Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        var answerOne = CalculateAnswerOne(parsedInput.RaceEvents);

        // Remove spaces before parsing
        var newParsedInput = Parser.ReformInput(input);
        var answerTwo = CalculateAnswerTwo(newParsedInput.RaceEvents);

        return (answerOne, answerTwo);
    }

    private static string CalculateAnswerOne(List<RaceEvent> raceEvents)
    {
        try
        {
            var waysToWinEachRace = new List<long>();

            foreach (var raceEvent in raceEvents)
            {
                var race = new BoatRace(raceEvent.Duration);
                var waysToWin = race.GetNumberOfScenariosToBeatADistance(raceEvent.RecordDistance);
                waysToWinEachRace.Add(waysToWin);
            }

            var aggregate = waysToWinEachRace.Aggregate((accumulatedValue, w) => accumulatedValue * w);
            return $"{aggregate}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }

    private static string CalculateAnswerTwo(List<RaceEvent> raceEvents)
    {
        try
        {
            var waysToWinEachRace = new List<long>();

            foreach (var raceEvent in raceEvents)
            {
                var race = new BoatRace(raceEvent.Duration);
                var waysToWin = race.GetNumberOfScenariosToBeatADistance(raceEvent.RecordDistance, false);
                waysToWinEachRace.Add(waysToWin);
            }

            var aggregate = waysToWinEachRace.Aggregate((accumulatedValue, w) => accumulatedValue * w);
            return $"{aggregate}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }
}
