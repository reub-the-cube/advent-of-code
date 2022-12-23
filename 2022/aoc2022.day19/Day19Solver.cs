using AoC.Core;
using aoc2022.day19.domain;

namespace aoc2022.day19;

public class Day19Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day19Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        throw new NotImplementedException();
    }
}
