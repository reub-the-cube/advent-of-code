using AoC.Core;
using aoc2022.day18.domain;

namespace aoc2022.day18;

public class Day18Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day18Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var grid = new Grid();
        foreach (var cube in parsedInput.GetCubes())
        {
            grid.AddCube(cube);
        }

        var answerOne = grid.GetUnconnectedFaces();
        var answerTwo = grid.GetExposedFaces();

        return (answerOne.ToString(), string.Empty);
    }
}
