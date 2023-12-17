using AoC.Core;
using aoc2023.day17.domain;

namespace aoc2023.day17;

public class Day17Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day17Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var answerOne = CalculateAnswerOne(parsedInput.HeatLossMap);
        var answerTwo = CalculateAnswerTwo();

        return (answerOne, answerTwo);
    }

    private static string CalculateAnswerOne(List<List<int>> heatLossMap)
    {
        try
        {
            var trafficMap = new TrafficPattern(heatLossMap);
            var leastHeatLoss = trafficMap.GetLeastHeatLossPath(new Position(0, 0), new Position(heatLossMap.Count - 1, heatLossMap[0].Count - 1));
            return $"{leastHeatLoss}";
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
