using AoC.Core;
using aoc2022.day09.domain;
using System.Runtime.CompilerServices;

namespace aoc2022.day09;

public class Day09Solver : IDaySolver
{
    private readonly IParser<Instruction[]> _parser;

    public Day09Solver(IParser<Instruction[]> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var instructions = _parser.ParseInput(input);

        var knots = Enumerable.Repeat(new Knot(0, 0), 10).ToList();
        var firstTailVisits = new Dictionary<(int X, int Y), int>();
        var secondTailVisits = new Dictionary<(int X, int Y), int>();

        foreach (var instruction in instructions)
        {
            for (int i = 0; i < instruction.NumberOfMoves; i++)
            {
                knots[0] = knots[0].Move(instruction.XMovement, instruction.YMovement);

                for (int knotNumber = 1; knotNumber < knots.Count; knotNumber++)
                {
                    knots[knotNumber] = knots[knotNumber].Follow(knots[knotNumber - 1].X, knots[knotNumber - 1].Y);

                    if (knotNumber == 1) firstTailVisits.Log((knots[knotNumber].X, knots[knotNumber].Y));
                    if (knotNumber == knots.Count - 1) secondTailVisits.Log((knots[knotNumber].X, knots[knotNumber].Y));
                }
            }
        }

        return (firstTailVisits.Keys.Count.ToString(), secondTailVisits.Keys.Count.ToString());
    }
}

public static class DictionaryExtensions
{
    public static void Log(this Dictionary<(int X, int Y), int> visitTracker, (int X, int Y) newKnotLocation)
    {
        if (!visitTracker.ContainsKey(newKnotLocation))
        {
            visitTracker.Add(newKnotLocation, 1);
        }
        else
        {
            visitTracker[newKnotLocation]++;
        }
    }
}
