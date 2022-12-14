using AoC.Core;
using aoc2022.day14.domain;

namespace aoc2022.day14;

public class Day14Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day14Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var cave = parsedInput.CaveSlice.Clone();

        var answerOne = FillCaveSliceWithSand(cave, 0, 500);

        parsedInput = _parser.ParseInput(input.Append("row-of-rocks").ToArray());

        var answerTwo = FillCaveSliceWithSand(parsedInput.CaveSlice, 0, 500);

        return (answerOne.ToString(), answerTwo.ToString());
    }

    private static int FillCaveSliceWithSand(CaveSlice cave, int entryRow, int entryColumn)
    {
        cave.SetSandDropPoint(entryRow, entryColumn);

        Position? restingPosition = new Position(-1, -1);
        while (restingPosition != null)
        {
            restingPosition = cave.AddGrainOfSand();
        }

        return cave.TotalGrainsOfSand;
    }
}
