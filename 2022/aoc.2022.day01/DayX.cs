using AoC.Core;
using aoc._2022.day01.models;

namespace aoc._2022.day01;
public class DayX :IDay
{
    private readonly IParser<Input> _parser;

    public DayX(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (int AnswerOne, int AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        throw new NotImplementedException();
    }
}
