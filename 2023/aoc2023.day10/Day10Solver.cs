using AoC.Core;
using aoc2023.day10.domain;

namespace aoc2023.day10;

public class Day10Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day10Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var answerOne = CalculateAnswerOne(parsedInput.Sketch);
        var answerTwo = CalculateAnswerTwo(parsedInput.Sketch);

        return (answerOne, answerTwo);
    }

    private static string CalculateAnswerOne(char[][] pipeSketch)
    {
        try
        {
            var pipeField = new PipeField(PipeField.BuildField(pipeSketch));
            var start = pipeField.FindStart();
            var furthestDistance = pipeField.GetFurthestDistance(start.Row, start.Column);
            return $"{furthestDistance}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }

    private static string CalculateAnswerTwo(char[][] pipeSketch)
    {
        try
        {
            var pipeField = new PipeField(PipeField.BuildField(pipeSketch));
            var clearedField = pipeField.RemoveJunkPipes();
            var enclosedTiles = clearedField.GetEnclosedTiles();
            return $"{enclosedTiles}";
        }
        catch (Exception e) when (e.GetType() != typeof(NotImplementedException))
        {
            return $"{e.Message}: {e.GetBaseException().Message}";
        }
    }
}
