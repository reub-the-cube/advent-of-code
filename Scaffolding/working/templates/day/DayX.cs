using AoC.Core;
using day.models;

namespace day;
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
