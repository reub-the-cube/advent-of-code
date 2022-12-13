using AoC.Core;
using aoc2022.day14.domain;

namespace aoc2022.day14;

public class Day14Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day14Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        throw new NotImplementedException();
    }
}
