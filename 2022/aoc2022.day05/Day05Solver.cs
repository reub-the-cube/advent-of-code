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

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var unloadingYard = _parser.ParseInput(input);

        var topCratesAfterCrateMover9000 = unloadingYard
            .RearrangeYard(CraneTypes.CrateMover9000)
            .GetTopCrateOfEachStack();
        var topCratesAfterCrateMover9001 = unloadingYard
            .RearrangeYard(CraneTypes.CrateMover9001)
            .GetTopCrateOfEachStack();

        var answerOne = string.Join(string.Empty, topCratesAfterCrateMover9000).Replace("[", string.Empty).Replace("]", string.Empty);
        var answerTwo = string.Join(string.Empty, topCratesAfterCrateMover9001).Replace("[", string.Empty).Replace("]", string.Empty);

        return (answerOne, answerTwo);
    }
}
