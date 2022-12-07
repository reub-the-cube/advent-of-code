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

        var directories = parsedInput.GetDirectoriesBySize();

        var answerOne = directories.Values.Sum(d => d <= 100000 ? d : 0);

        var unusedSpace = 70000000 - directories.Values.FirstOrDefault();
        var deltaToFreeUpSpace = 30000000 - unusedSpace;
        var answerTwo = directories.Values.Order().FirstOrDefault(v => v > deltaToFreeUpSpace);
        
        return (answerOne.ToString(), answerTwo.ToString());
    }
}