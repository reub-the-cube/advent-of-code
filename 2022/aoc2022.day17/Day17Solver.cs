using AoC.Core;
using aoc2022.day17.domain;
using static aoc2022.day17.Enums;

namespace aoc2022.day17;

public class Day17Solver : IDaySolver
{
    private readonly IParser<string> _parser;

    public Day17Solver(IParser<string> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var answerOne = HeightOfRocksAfter2022Drops(parsedInput.ToCharArray());

        return (answerOne.ToString(), "not done yet");
    }

    private static int HeightOfRocksAfter2022Drops(IReadOnlyList<char> jetPattern)
    {
        var chamber = new Chamber(Enumerable.Repeat(0, 7).ToArray());
        var jetPatternIndex = -1;

        for (var rockNumber = 0; rockNumber < 2022; rockNumber++)
        {
            var shapeEnum = (RockShape)(rockNumber % 5);
            var rock = Shape.MakeShape(shapeEnum);
            var rockIsMoving = true;
            var bottomLeftIndex = 2;
            var bottomLeftHeight = chamber.GetHighestRock() + 4; // Three clear rows above

            while (rockIsMoving)
            {
                if (jetPatternIndex < jetPattern.Count - 1)
                {
                    jetPatternIndex += 1;
                }
                else
                {
                    jetPatternIndex = 0;
                }

                bottomLeftIndex = jetPattern[jetPatternIndex] switch
                {
                    '<' => chamber.PushRockLeft(rock, bottomLeftIndex, bottomLeftHeight),
                    '>' => chamber.PushRockRight(rock, bottomLeftIndex, bottomLeftHeight),
                    _ => throw new Exception($"Unexpected character in jet pattern {jetPattern[jetPatternIndex]}")
                };

                var bottomLeftHeightAfterFall = chamber.LetRockFall(rock, bottomLeftIndex, bottomLeftHeight);

                if (bottomLeftHeightAfterFall == bottomLeftHeight)
                {
                    // Rock is resting
                    rockIsMoving = false;
                    _ = chamber.PlaceRock(rock, bottomLeftIndex, bottomLeftHeight);
                }
                else
                {
                    bottomLeftHeight = bottomLeftHeightAfterFall;
                }
            }
        }

        var finalHeight = chamber.GetHighestRock();
        return finalHeight;
    }
}
