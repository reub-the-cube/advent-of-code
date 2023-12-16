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
                var contraption = new Contraption(contraptionLayout);
                contraption.FillWithLight(startingRow, 0, Direction.Right);
                maxEnergisedTiles = Math.Max(maxEnergisedTiles, contraption.UniqueEnergisedTiles.Count);

                contraption = new Contraption(contraptionLayout);
                contraption.FillWithLight(startingRow, columnCount - 1, Direction.Left);
                maxEnergisedTiles = Math.Max(maxEnergisedTiles, contraption.UniqueEnergisedTiles.Count);
            }

            for (var startingColumn = 0; startingColumn < columnCount; startingColumn++)
            {
                var contraption = new Contraption(contraptionLayout);
                contraption.FillWithLight(0, startingColumn, Direction.Down);
                maxEnergisedTiles = Math.Max(maxEnergisedTiles, contraption.UniqueEnergisedTiles.Count);

                contraption = new Contraption(contraptionLayout);
                contraption.FillWithLight(rowCount - 1, startingColumn, Direction.Down);
                maxEnergisedTiles = Math.Max(maxEnergisedTiles, contraption.UniqueEnergisedTiles.Count);
            }
            return $"{maxEnergisedTiles}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }
}
