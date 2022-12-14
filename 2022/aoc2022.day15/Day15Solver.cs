using AoC.Core;
using aoc2022.day15.domain;

namespace aoc2022.day15;

public class Day15Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day15Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        throw new NotImplementedException();
    }
}
