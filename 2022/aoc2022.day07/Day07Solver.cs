using AoC.Core;
using aoc2022.day07.domain;

namespace aoc2022.day07;

public class Day07Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day07Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        throw new NotImplementedException();
    }
}
