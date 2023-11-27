using AoC.Core;
using aoc2020.day03.domain;

namespace aoc2020.day03;

public class Day03Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day03Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        throw new NotImplementedException();
    }
}
