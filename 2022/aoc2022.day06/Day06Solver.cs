using AoC.Core;
using aoc2022.day06.domain;

namespace aoc2022.day06;

public class Day06Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day06Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        throw new NotImplementedException();
    }
}
