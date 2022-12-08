using AoC.Core;
using aoc2022.day08.domain;

namespace aoc2022.day08;

public class Day08Solver : IDaySolver
{
    private readonly IParser<Forest> _parser;

    public Day08Solver(IParser<Forest> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var forest = _parser.ParseInput(input);

        var answerOne = forest.GetCountOfVisibleTrees();
        var answerTwo = forest.GetMaximumScenicScore();

        return (answerOne.ToString(), answerTwo.ToString());
    }
}
