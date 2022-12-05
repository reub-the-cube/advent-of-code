using AoC.Core;
using aoc._2022.day04.domain;

namespace aoc._2022.day04;

public class Day04Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day04Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var numberOfFullOverlaps = parsedInput.AssignmentPairs.Count(pair => pair.HasFullRangeOverlap);
        var numberOfTotalOverlaps = parsedInput.AssignmentPairs.Count(pair => pair.HasSomeKindOfOverlap);

        return (numberOfFullOverlaps.ToString(), numberOfTotalOverlaps.ToString());
    }
}
