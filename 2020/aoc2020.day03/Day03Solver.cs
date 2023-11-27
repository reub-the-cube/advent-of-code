using AoC.Core;
using aoc2020.day03.domain;

namespace aoc2020.day03;

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

        var treesEncounteredRightOneDownOne = TraverseSlope(parsedInput.Grid, 1, 1);
        var treesEncounteredRightThreeDownOne = TraverseSlope(parsedInput.Grid, 1, 3);
        var treesEncounteredRightFiveDownOne = TraverseSlope(parsedInput.Grid, 1, 5);
        var treesEncounteredRightSevenDownOne = TraverseSlope(parsedInput.Grid, 1, 7);
        var treesEncounteredRightOneDownTwo = TraverseSlope(parsedInput.Grid, 2, 1);

        var answerTwo = treesEncounteredRightOneDownOne *
            treesEncounteredRightThreeDownOne *
            treesEncounteredRightFiveDownOne *
            treesEncounteredRightSevenDownOne *
            treesEncounteredRightOneDownTwo;

        return ($"{treesEncounteredRightThreeDownOne}", $"{answerTwo}");
    }

    private static int TraverseSlope(Square[,]? terrainGrid, int verticalStep, int horizontalStep)
    {
        if (terrainGrid == null) throw new ArgumentNullException("terrainGrid");

        var patternWidth = terrainGrid.GetUpperBound(1);
        var gridRow = 0;
        var gridColumn = 0;
        var treeCount = 0;

        while (true)
        {
            gridRow += verticalStep;
            gridColumn = (gridColumn + horizontalStep) % (patternWidth + 1);

            if (gridRow > terrainGrid.GetUpperBound(0)) break;

            var nextSquare = terrainGrid[gridRow, gridColumn];

            if (nextSquare == Square.Tree)
            {
                treeCount += 1;
            }
        }

        return treeCount;

    }
}
