using AoC.Core;
using aoc._2022.day01.models;

namespace aoc._2022.day01;
public class Day01Solver :IDay
{
    private readonly IParser<Input> _parser;

    public Day01Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (int AnswerOne, int AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        var answerOne = parsedInput.MostCaloriesHeldByAnElf();

        return (answerOne, 0);
    }
}
