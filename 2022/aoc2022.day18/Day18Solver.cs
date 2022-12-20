using AoC.Core;
using aoc2022.day18.domain;

namespace aoc2022.day18;

public class Day18Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day18Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        throw new NotImplementedException();
    }
}
