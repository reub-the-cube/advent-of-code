using AoC.Core;
using aoc._2022.day01.models;

namespace aoc._2022.day01;
public class Day01Solver :IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day01Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        var answerOne = parsedInput.MostCaloriesHeldByAnElf();
        var answerTwo = parsedInput.TotalCaloriesHeldByElvesWithMostCalories(3);

        return (answerOne.ToString(), answerTwo.ToString());
    }
}
