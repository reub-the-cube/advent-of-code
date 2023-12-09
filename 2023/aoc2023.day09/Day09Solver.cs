using AoC.Core;
using aoc2023.day09.domain;

namespace aoc2023.day09;

public class Day09Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day09Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var answerOne = CalculateAnswerOne(parsedInput.OasisHistoryRecords);
        var answerTwo = CalculateAnswerTwo();

        return (answerOne, answerTwo);
    }

    private static string CalculateAnswerOne(List<List<int>> oasisHistoryRecords)
    {
        try
        {
            var sumOfNextValues = oasisHistoryRecords.Sum(GetNextValue);
            return $"{sumOfNextValues}";
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

    private static int GetNextValue(List<int> oasisHistoryRecord)
    {
        var predictor = new OasisHistoryPredictor(oasisHistoryRecord);
        return predictor.GetNextValue();
    }
}
