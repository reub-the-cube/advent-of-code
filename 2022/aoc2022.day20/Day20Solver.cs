using AoC.Core;
using aoc2022.day20.domain;

namespace aoc2022.day20;

public class Day20Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day20Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        throw new NotImplementedException();
    }
}
