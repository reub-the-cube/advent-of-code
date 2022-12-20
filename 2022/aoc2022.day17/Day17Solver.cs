using System.Diagnostics;
using System.Text;
using AoC.Core;
using aoc2022.day17.domain;
using Microsoft.Extensions.Logging;
using static aoc2022.day17.Enums;

namespace aoc2022.day17;

public class Day17Solver : IDaySolver
{
    private readonly IParser<string> _parser;
    private readonly ILogger<Day17Solver> _logger;

    public Day17Solver(IParser<string> parser, ILogger<Day17Solver> logger)
    {
        _parser = parser;
        _logger = logger;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var answerOne = DropRocksIntoChamber(2022, parsedInput.ToCharArray());
        var answerTwo = DropRocksIntoChamber(1000000000000, parsedInput.ToCharArray());

        return (answerOne.ToString(), answerTwo.ToString());
    }

    private long DropRocksIntoChamber(long numberOfDrops, IReadOnlyList<char> jetPattern)
    {
        // Just for logging
        var heights = new StringBuilder();
        
        // Instantiate the chamber and iteration variables
        var chamber = new Chamber(Enumerable.Repeat(0, 7).ToArray());
        var jetPatternIndex = 0;
        var patternSpotter = new PatternSpotter();

        long rockNumber = 1;
        while (rockNumber < numberOfDrops + 1)
        {
            var shapeEnum = (RockShape) ((rockNumber - 1) % 5);

            if (!patternSpotter.HasDetectedPattern)
            {
                patternSpotter.AddRockToPattern(shapeEnum, jetPatternIndex, chamber);

                if (patternSpotter.HasDetectedPattern)
                {
                    var remainingCycles =
                        (long) Math.Floor(((double) numberOfDrops - rockNumber) / patternSpotter.CycleDuration);
                    chamber.BumpBlockedHeights(remainingCycles * patternSpotter.CycleHeightDelta,
                        remainingCycles * patternSpotter.CycleDuration);

                    // Move to the next rock (close to the end of the series) and drop on the existing pattern
                    rockNumber = chamber.NumberOfRocksDropped + 1;
                    shapeEnum = (RockShape) ((rockNumber - 1) % 5);
                }
            }

            var rock = Shape.MakeShape(shapeEnum);
            var bottomLeftIndex = 2;
            var bottomLeftHeight = chamber.GetHighestRock() + 4; // Three clear rows above
            while (!rock.HasComeToRest)
            {
                bottomLeftIndex = jetPattern[jetPatternIndex] switch
                {
                    '<' => chamber.PushRockLeft(rock, bottomLeftIndex, bottomLeftHeight),
                    '>' => chamber.PushRockRight(rock, bottomLeftIndex, bottomLeftHeight),
                    _ => throw new Exception($"Unexpected character in jet pattern {jetPattern[jetPatternIndex]}")
                };

                bottomLeftHeight = chamber.LetRockFall(rock, bottomLeftIndex, bottomLeftHeight);
                
                jetPatternIndex = (jetPatternIndex + 1) % jetPattern.Count;
            }
            
            var landingHeights = chamber.PlaceRock(rock, bottomLeftIndex, bottomLeftHeight);
            heights = heights.AppendLine(
                $"Rock {rockNumber.ToString().PadRight(4)} ends on jet pattern index {jetPatternIndex.ToString().PadRight(2)} and is a {Enum.GetName(shapeEnum)?.PadRight(15)}: {string.Join(',', landingHeights)}");

            rockNumber++;
        }

        _logger.LogDebug(heights.ToString());
        
        return chamber.GetHighestRock();
    }
}
