using AoC.Core;
using aoc2020.day01.domain;

namespace aoc2020.day01;

public class Day01Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day01Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        var answerOne = CalculateAnswerOne(parsedInput.ReportEntries.ToList());
        var answerTwo = CalculateAnswerTwo(parsedInput.ReportEntries.ToList());

        return (answerOne, answerTwo);
    }

    private static string CalculateAnswerOne(List<int> reportEntries)
    {
        var startingValues = reportEntries.ToDictionary(k => (k, k), v => new List<int> { v });
        var matchingValue = FindMatchingValue(reportEntries.ToDictionary(k => (k, k), v => new List<int> { v }), reportEntries);
        return $"{matchingValue}";
    }

    private static int FindMatchingValue(Dictionary<(int Sum, int Product), List<int>> startingValues, List<int> reportEntries)
    {
        foreach (var item in startingValues)
        {
            var remainingEntries = reportEntries.Except(item.Value).ToList();
            var pairedEntry = remainingEntries.FirstOrDefault(e => e + item.Key.Sum == 2020);

            if (pairedEntry > 0)
            {
                return pairedEntry * item.Key.Product;
            }
        }

        return 0;
    }

    private static string CalculateAnswerTwo(List<int> reportEntries)
    {
        try
        {

            var checkedEntries = new List<int>();
            var newPartialEntries = new List<KeyValuePair<(int Sum, int Product), List<int>>>();

            foreach (var item in reportEntries)
            {
                var remainingEntries = reportEntries.Except(new List<int> { item }).Except(checkedEntries).ToList();
                newPartialEntries.AddRange(remainingEntries
                    .Where(e => e + item < 2020)
                    .Select(e => new KeyValuePair<(int Sum, int Product), List<int>>((e + item, e * item), new List<int> { item, e })));
                checkedEntries.Add(item);
            }

            var partialEntriesDictionary = newPartialEntries.Distinct().ToDictionary(k => k.Key, v => v.Value);

            foreach (var item in partialEntriesDictionary)
            {
                var matchingValue = FindMatchingValue(partialEntriesDictionary, reportEntries);
                if (matchingValue > 0)
                {
                    return $"{matchingValue}";
                }
            }

            return "";
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}
