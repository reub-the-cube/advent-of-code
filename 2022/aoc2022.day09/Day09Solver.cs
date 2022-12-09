using AoC.Core;
using aoc2022.day09.domain;

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
        var visitedFirstTail = new Dictionary<(int X, int Y), int>();
        var visitedSecondTail = new Dictionary<(int X, int Y), int>();

        foreach (var instruction in instructions)
        {
            for (int i = 0; i < instruction.NumberOfMoves; i++)
            {
                knots[0] = knots[0].Move(instruction.XMovement, instruction.YMovement);

                for (int knotNumber = 1; knotNumber < knots.Count; knotNumber++)
                {
                    knots[knotNumber] = knots[knotNumber].Follow(knots[knotNumber - 1].X, knots[knotNumber - 1].Y);

                    if (knotNumber == 1)
                    {
                        if (visitedFirstTail.ContainsKey((knots[knotNumber].X, knots[knotNumber].Y)))
                        {
                            visitedFirstTail[(knots[knotNumber].X, knots[knotNumber].Y)]++;
                        }
                        else
                        {
                            visitedFirstTail.Add((knots[knotNumber].X, knots[knotNumber].Y), 1);
                        }
                    }

                    if (knotNumber == knots.Count - 1)
                    {
                        if (visitedSecondTail.ContainsKey((knots[knotNumber].X, knots[knotNumber].Y)))
                        {
                            visitedSecondTail[(knots[knotNumber].X, knots[knotNumber].Y)]++;
                        }
                        else
                        {
                            visitedSecondTail.Add((knots[knotNumber].X, knots[knotNumber].Y), 1);
                        }
                    }
                }
            }
        }

        return (visitedFirstTail.Keys.Count.ToString(), visitedSecondTail.Keys.Count.ToString());
    }
}
