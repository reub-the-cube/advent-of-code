using AoC.Core;
using aoc2022.day05.domain;

namespace aoc2022.day05;

public class Day05Solver : IDaySolver
{
    private readonly IParser<UnloadingYard> _parser;

    public Day05Solver(IParser<UnloadingYard> parser)
    {
        _parser = parser;
    }

    public (int AnswerOne, int AnswerTwo) CalculateAnswers(string[] input)
    {
        throw new NotImplementedException();
    }

    public (string AnswerOne, string AnswerTwo) CalculateNewAnswers(string[] input)
    {
        var unloadingYard = _parser.ParseInput(input);

        var topCrates = unloadingYard.RearrangeYard().GetTopCrateOfEachStack();

        var answerOne = string.Join(string.Empty, topCrates).Replace("[", string.Empty).Replace("]", string.Empty);

        return (answerOne, "");
    }
}
