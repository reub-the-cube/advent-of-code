using AoC.Core;
using aoc2023.day07.domain;
using System.Reflection.Metadata;

namespace aoc2023.day07;

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

        var answerOne = CalculateAnswerOne(parsedInput.Hands);
        var answerTwo = CalculateAnswerTwo(parsedInput.Hands);

        return (answerOne, answerTwo);
    }

    private static string CalculateAnswerOne(List<(string Cards, int Bid)> hands)
    {
        try
        {
            var game = new CamelCardsGame(new StandardScoringRules());
            hands.ForEach(h => game.AddHand(h.Cards, h.Bid));

            return $"{game.CalculateTotalWinnings()}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }

    private static string CalculateAnswerTwo(List<(string Cards, int Bid)> hands)
    {
        try
        {
            var game = new CamelCardsGame(new JokerScoringRules());
            hands.ForEach(h => game.AddHand(h.Cards, h.Bid));

            return $"{game.CalculateTotalWinnings()}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }
}
