using AoC.Core;
using aoc2022.day16.domain;

namespace aoc2022.day16;

public class Day16Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day16Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        throw new NotImplementedException();
    }
}
