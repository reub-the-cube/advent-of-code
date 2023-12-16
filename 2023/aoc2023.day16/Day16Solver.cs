using AoC.Core;
using aoc2023.day16.domain;
using static aoc2023.day16.Enums;

namespace aoc2023.day16;

public class Day16Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day16Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var answerOne = CalculateAnswerOne(parsedInput.ContraptionLayout);
        var answerTwo = CalculateAnswerTwo(parsedInput.ContraptionLayout);

        return (answerOne, answerTwo);
    }

    private static string CalculateAnswerOne(List<string> contraptionLayout)
    {
        try
        {
            var contraption = new Contraption(contraptionLayout);
            contraption.FillWithLight(0, 0, Enums.Direction.Right);
            var energisedTiles = contraption.UniqueEnergisedTiles;
            return $"{energisedTiles.Count}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }

    private static string CalculateAnswerTwo(List<string> contraptionLayout)
    {
        try
        {
            int rowCount = contraptionLayout.Count;
            int columnCount = contraptionLayout[0].Length;
            int maxEnergisedTiles = 0;

            for (var startingRow = 0; startingRow < rowCount; startingRow++)
            {
                maxEnergisedTiles = Math.Max(maxEnergisedTiles, GetEnergisedTileCount(contraptionLayout, startingRow, 0, Direction.Right));
                maxEnergisedTiles = Math.Max(maxEnergisedTiles, GetEnergisedTileCount(contraptionLayout, startingRow, columnCount - 1, Direction.Left));
            }

            for (var startingColumn = 0; startingColumn < columnCount; startingColumn++)
            {
                maxEnergisedTiles = Math.Max(maxEnergisedTiles, GetEnergisedTileCount(contraptionLayout, 0, startingColumn, Direction.Down));
                maxEnergisedTiles = Math.Max(maxEnergisedTiles, GetEnergisedTileCount(contraptionLayout, rowCount - 1, startingColumn, Direction.Up));
            }

            return $"{maxEnergisedTiles}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }

    private static int GetEnergisedTileCount(List<string> contraptionLayout, int startingRow, int startingColumn, Direction startingDirection)
    {
        var contraption = new Contraption(contraptionLayout);
        contraption.FillWithLight(startingRow, startingColumn, startingDirection);
        return contraption.UniqueEnergisedTiles.Count;

    }
}
