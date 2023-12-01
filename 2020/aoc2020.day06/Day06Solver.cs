using AoC.Core;
using aoc2020.day06.domain;

namespace aoc2020.day06;

public class Day06Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day06Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        return (CalculateAnswerOne(parsedInput.GroupAnswers), CalculateAnswerTwo(parsedInput.GroupAnswers));
    }

    public string CalculateAnswerOne(List<string[]> groupAnswers)
    {
        try
        {
            var totalNumberOfAllGroupsQuestionsAnswered = groupAnswers.Sum(AnswerAnalyser.NumberOfUniqueQuestionsAnsweredByAnyone);
            return $"{totalNumberOfAllGroupsQuestionsAnswered}";
        }
        catch (Exception ex)
        {
            return $"{ex.Message}: {ex.GetBaseException().Message}";
        }
    }

    public string CalculateAnswerTwo(List<string[]> groupAnswers)
    {
        try
        {
            var totalNumberOfAllGroupsQuestionsAnswered = groupAnswers.Sum(AnswerAnalyser.NumberOfUniqueQuestionsAnsweredByEveryone);
            return $"{totalNumberOfAllGroupsQuestionsAnswered}";
        }
        catch (Exception ex)
        {
            return $"{ex.Message}: {ex.GetBaseException().Message}";
        }
    }
}
