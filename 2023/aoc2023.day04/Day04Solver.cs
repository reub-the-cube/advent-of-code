using AoC.Core;
using aoc2023.day04.domain;
using System.Collections.Generic;

namespace aoc2023.day04;

public class Day04Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day04Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var answerOne = CalculateAnswerOne(parsedInput.Scratchcards);
        var answerTwo = CalculateAnswerTwo(parsedInput.Scratchcards);

        return (answerOne, answerTwo);
    }

    private static string CalculateAnswerOne(List<Scratchcard> scratchcards)
    {
        try
        {
            var totalScores = scratchcards.Select(CalculateCardScore);
            return $"{totalScores.Sum()}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }

    private static string CalculateAnswerTwo(List<Scratchcard> scratchcards)
    {
        try
        {
            var copyCounter = new ScratchcardCopyCounter(scratchcards.Select(s => s.Id).ToList());
            foreach (Scratchcard card in scratchcards)
            {
                copyCounter.AddCopies(card);
            }

            return $"{copyCounter.TotalNumberOfScratchcards()}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }

    private static double CalculateCardScore(Scratchcard scratchcard)
    {
        var matchingNumbers = scratchcard.CardNumbers.Intersect(scratchcard.WinningNumbers).ToList();

        return matchingNumbers.Any() ? Math.Pow(2, matchingNumbers.Count - 1) : 0;
    }
}
