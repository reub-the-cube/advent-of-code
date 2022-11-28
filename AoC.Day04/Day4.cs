using AoC.Core;
using aoc.day04.models;

namespace aoc.day04;
public class Day4 :IDay
{
    private readonly IParser<Input> _parser;

    public Day4(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (int AnswerOne, int AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        throw new NotImplementedException();
    }
}
