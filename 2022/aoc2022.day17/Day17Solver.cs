using AoC.Core;
using aoc2022.day17.domain;

namespace aoc2022.day17;

public class Day17Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day17Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        throw new NotImplementedException();
    }
}
