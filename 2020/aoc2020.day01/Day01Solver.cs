using AoC.Core;
using aoc2020.day01.domain;

namespace aoc2020.day01;

public class Day01Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day01Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        throw new NotImplementedException();
    }
}
