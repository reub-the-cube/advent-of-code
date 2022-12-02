using AoC.Core;
using aoc._2022.day02.domain;

namespace aoc._2022.day02;
public class Day02Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day02Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (int AnswerOne, int AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        return (parsedInput.GetMyGameScore(0), parsedInput.GetMyGameScore(1));
    }
}
