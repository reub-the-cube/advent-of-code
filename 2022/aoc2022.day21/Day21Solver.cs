using AoC.Core;
using aoc2022.day21.domain;

namespace aoc2022.day21;

public class Day21Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day21Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        throw new NotImplementedException();
    }
}
