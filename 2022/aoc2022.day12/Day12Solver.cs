using AoC.Core;
using aoc2022.day12.domain;

namespace aoc2022.day12;

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
        throw new NotImplementedException();
    }
}
