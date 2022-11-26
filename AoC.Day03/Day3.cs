using AoC.Core;
using AoC.Day03.Models;

namespace AoC.Day03;
public class Day3 : IDay
{
    private readonly IParser<Input> _parser;

    public Day3(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (int AnswerOne, int AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        throw new NotImplementedException();
    }
}
