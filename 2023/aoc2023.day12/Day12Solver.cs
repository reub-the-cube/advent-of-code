using AoC.Core;
using aoc2023.day12.domain;
using System.Diagnostics;

namespace aoc2023.day12;

public class Day12Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day12Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var answerOne = CalculateAnswerOne(parsedInput.SpringConditions);
        var answerTwo = CalculateAnswerTwo(parsedInput.SpringConditions);

        return (answerOne, answerTwo);
    }

    private static string CalculateAnswerOne(List<SpringConditionsRecord> springConditions)
    {
        try
        {
            long arrangementCount = 0;

            foreach (var springCondition in springConditions)
            {
                var springArrangements = new SpringArrangements();
                var arrangements = springArrangements.GetPossibleArrangements(springCondition.SpringConditions, springCondition.ContiguousCount);
                arrangementCount += arrangements;
            }

            return $"{arrangementCount}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }

    private static string CalculateAnswerTwo(List<SpringConditionsRecord> springConditions)
    {
        try
        {
            long arrangementCount = 0;
            int recordCount = 1;

            foreach (var springCondition in springConditions)
            {
                var unfoldedRecord = SpringArrangements.Unfold(springCondition.SpringConditions, springCondition.ContiguousCount);
                Console.WriteLine($"Unfolded record {recordCount}: '{springCondition.SpringConditions}'.");
                var springArrangements = new SpringArrangements();
                var arrangements = springArrangements.GetPossibleArrangements(unfoldedRecord.SpringConditions, unfoldedRecord.ContiguousCount);
                arrangementCount += arrangements;
                Console.WriteLine($"After {recordCount} records: '{arrangementCount}' (another {arrangements}).");
                recordCount++;
            }

            return $"{arrangementCount}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }
}
