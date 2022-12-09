using AoC.Core;
using aoc2022.day10.domain;

namespace aoc2022.day10;

public class Day10Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day10Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        throw new NotImplementedException();
    }
}
