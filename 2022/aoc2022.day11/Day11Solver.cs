using AoC.Core;
using aoc2022.day11.domain;

namespace aoc2022.day11;

public class Day11Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day11Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        throw new NotImplementedException();
    }
}
