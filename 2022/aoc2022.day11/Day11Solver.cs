using AoC.Core;
using aoc2022.day11.domain;
using System.Diagnostics;
using System.Text;

namespace aoc2022.day11;

public class Day11Solver : IDaySolver
{
    private readonly IParser<Input> _parser;
    private List<string> _roundStandings = new();
    private List<string> _secondPartStandings = new();

    public Day11Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var worryLevelReducerPhaseOne = (long worryValue) => { return (decimal)worryValue / 3; };
        for (int round = 0; round < 20; round++)
        {
            for (int monkeyIndex = 0; monkeyIndex < parsedInput.Monkeys.Count; monkeyIndex++)
            {
                while (parsedInput.Monkeys[monkeyIndex].Items.Any())
                {
                    var inspectedItem = parsedInput.Monkeys[monkeyIndex].InspectItem(worryLevelReducerPhaseOne);
                    var nextMonkeyIndex = parsedInput.Monkeys[monkeyIndex].GetNextMonkey(inspectedItem.GetWorryLevel());

                    parsedInput.Monkeys[nextMonkeyIndex].AddItem(inspectedItem);
                }
            }

            _roundStandings.Add(BuildRoundStandings(parsedInput.Monkeys));
        }

        // Calculate monkey business for answer one
        var busiestMonkeysPartOne = parsedInput.Monkeys.Select(m => m.InspectionCount).Order().TakeLast(2).ToList();

        // Second part
        parsedInput = _parser.ParseInput(input);
        var totalDivisor = parsedInput.Monkeys.Select(m => m.GetTestDivisor()).Aggregate((a, b) => a * b);
        var worryLevelReducerPhaseTwo = (long worryLevel) => { return (decimal)worryLevel % totalDivisor; };
        for (int round = 0; round < 10000; round++)
        {
            for (int monkeyIndex = 0; monkeyIndex < parsedInput.Monkeys.Count; monkeyIndex++)
            {
                while (parsedInput.Monkeys[monkeyIndex].Items.Any())
                {
                    var inspectedItem = parsedInput.Monkeys[monkeyIndex].InspectItem(worryLevelReducerPhaseTwo);
                    var nextMonkeyIndex = parsedInput.Monkeys[monkeyIndex].GetNextMonkey(inspectedItem.GetWorryLevel());

                    parsedInput.Monkeys[nextMonkeyIndex].AddItem(inspectedItem);
                }
            }

            if (round % 1000 == 0)
            {
                _secondPartStandings.Add(BuildSecondPartStandings(parsedInput.Monkeys));
            }

            Debug.WriteLine($"Round {round} completed.");
        }

        // Calculate monkey business for answer one
        var busiestMonkeysPartTwo = parsedInput.Monkeys.Select(m => (long)m.InspectionCount).Order().TakeLast(2).ToList();

        var monkeyBusinesPartOne = busiestMonkeysPartOne[0] * busiestMonkeysPartOne[1];
        var monkeyBusinesPartTwo = busiestMonkeysPartTwo[0] * busiestMonkeysPartTwo[1];

        return (monkeyBusinesPartOne.ToString(), monkeyBusinesPartTwo.ToString());
    }

    public string GetRoundStandings(int index) => _roundStandings[index];

    private static string BuildRoundStandings(List<Monkey> monkeys)
    {
        var standings = new StringBuilder();
        standings.AppendLine();

        for (int i = 0; i < monkeys.Count; i++)
        {
            var monkeyLine = $"Monkey {i}: {string.Join(", ", monkeys[i].Items.Select(i => i.GetWorryLevel()))}";
            standings.AppendLine(monkeyLine);
        }

        return standings.ToString();
    }

    private static string BuildSecondPartStandings(List<Monkey> monkeys)
    {
        var standings = new StringBuilder();
        standings.AppendLine();

        for (int i = 0; i < monkeys.Count; i++)
        {
            var monkeyLine = $"Monkey {i} inspected items {monkeys[i].InspectionCount} times.";
            standings.AppendLine(monkeyLine);
        }

        return standings.ToString();
    }
}
