using System.Diagnostics;
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
        var answerTwo = HeightOfRocksAfterDrops(1000000000000, parsedInput.ToCharArray());
        
        return (answerOne.ToString(), answerTwo.ToString());
    }

    
    private static int HeightOfRocksAfter2022Drops(IReadOnlyList<char> jetPattern)
    {
        return (int)HeightOfRocksAfterDrops(2022, jetPattern);
    }
    
    private static long HeightOfRocksAfterDrops(long numberOfDrops, IReadOnlyList<char> jetPattern)
    {
        var chamber = new Chamber(Enumerable.Repeat(0, 7).ToArray());
        var jetPatternIndex = -1;
        var rockJetTracker = new Dictionary<RockShape, HashSet<int>>()
        {
            { RockShape.HorizontalLine, new HashSet<int>() },
            { RockShape.Plus, new HashSet<int>() },
            { RockShape.MirroredL, new HashSet<int>() },
            { RockShape.VerticalLine, new HashSet<int>() },
            { RockShape.Square, new HashSet<int>() },
        };

        for (var rockNumber = 0; rockNumber < numberOfDrops; rockNumber++)
        {
            if (rockNumber % 10000 == 0) Debug.WriteLine($"Placing rock number {rockNumber}.");
            
            var shapeEnum = (RockShape)(rockNumber % 5);
            var rock = Shape.MakeShape(shapeEnum);
            
            var rockIsMoving = true;
            var bottomLeftIndex = 2;
            var bottomLeftHeight = chamber.GetHighestRock() + 4; // Three clear rows above

            if (rockJetTracker[shapeEnum].Contains(jetPatternIndex + 1))
            {
                return jetPatternIndex;
            }
            else
            {
                rockJetTracker[shapeEnum].Add(jetPatternIndex + 1);
            }
            
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
