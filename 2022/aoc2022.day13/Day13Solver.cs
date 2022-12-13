using AoC.Core;
using aoc2022.day13.domain;

namespace aoc2022.day13;

public class Day13Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day13Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        throw new NotImplementedException();
    }
}
