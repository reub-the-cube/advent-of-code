using AoC.Core;
using aoc2022.day09.domain;

namespace aoc2022.day09;

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
        throw new NotImplementedException();
    }
}
