using AoC.Core;
using day.domain;

namespace day;

public class DayXSolver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public DayXSolver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        throw new NotImplementedException();
    }
}