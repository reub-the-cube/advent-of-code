using AoC.Core;
using aoc2020.day02.domain;

namespace aoc2020.day02;

public class Day02Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day02Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        throw new NotImplementedException();
    }
}
