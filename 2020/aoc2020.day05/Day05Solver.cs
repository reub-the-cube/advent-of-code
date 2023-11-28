using AoC.Core;
using aoc2020.day05.domain;

namespace aoc2020.day05;

public class Day05Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day05Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        throw new NotImplementedException();
    }
}
