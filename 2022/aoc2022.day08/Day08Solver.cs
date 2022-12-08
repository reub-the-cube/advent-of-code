using AoC.Core;
using aoc2022.day08.domain;

namespace aoc2022.day08;

public class Day08Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day08Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        throw new NotImplementedException();
    }
}
