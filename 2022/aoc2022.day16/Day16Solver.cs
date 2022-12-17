using AoC.Core;
using aoc2022.day16.domain;

namespace aoc2022.day16;

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

        var shortestPaths = CalculateShortestPaths(parsedInput.ValveTunnels);

        // Starting point AA, 30 minutes
        var maximumReleasablePressureFromTargetValves = PressureCounter.CalculateMaximumRemainingPressure("AA", 30, shortestPaths, parsedInput.ValveFlowRates);
        var maximumReleasablePressure = maximumReleasablePressureFromTargetValves.Max(kvp => kvp.Value);

        // Starting point (AA, AA), 26 minutes
        maximumReleasablePressureFromTargetValves = PressureCounter.CalculateMaximumRemainingPressure(new[] { "AA", "AA" }, new[] { 26, 26 }, shortestPaths, parsedInput.ValveFlowRates);
        var maximumReleasablePressureWithElephant = maximumReleasablePressureFromTargetValves.Max(kvp => kvp.Value);

        return (maximumReleasablePressure.ToString(), maximumReleasablePressureWithElephant.ToString());
    }

    private static Dictionary<(string From, string To), int> CalculateShortestPaths(Dictionary<string, List<string>> valveTunnels)
    {
        var shortestPaths = new Dictionary<(string From, string To), int>();
        var tunnelNetwork = new TunnelNetwork(valveTunnels);

        foreach (var from in valveTunnels.Keys)
        {
            foreach (var to in valveTunnels.Keys)
            {
                // It can't contain key from, to (because that's what we're looping but 
                if (!shortestPaths.ContainsKey((to, from)))
                {
                    shortestPaths.Add((from, to), tunnelNetwork.GetShortestPath(from, to));
                }
            }
        }

        return shortestPaths;
    }
}
