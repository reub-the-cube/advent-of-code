using AoC.Core;
using aoc._2022.day03.domain;
using aoc._2022.day03.Domain;

namespace aoc._2022.day03;

public class Day03Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day03Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var commonItemsPerRucksack = parsedInput.Rucksacks.Select(r => r.CommonItem);

        var elfGroups = parsedInput.Rucksacks.Chunk(3);
        var commonItemsPerGroup = elfGroups.Select(elfGroup => CompartmentChecker.FindFirstCommonItem(elfGroup.Select(e => e.AllItems).ToArray()));

        var answerOne = PriorityCalculator.CalculatePriorityOfItems(commonItemsPerRucksack);
        var answerTwo = PriorityCalculator.CalculatePriorityOfItems(commonItemsPerGroup);

        return (answerOne.ToString(), answerTwo.ToString());
    }
}