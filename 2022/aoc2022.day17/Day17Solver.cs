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
        var heights = new StringBuilder();
        var chamber = new Chamber(Enumerable.Repeat(0, 7).ToArray());
        var jetPatternIndex = 0;
        var rockJetTracker = new Dictionary<RockShape, HashSet<int>>()
        {
            { RockShape.HorizontalLine, new HashSet<int>() },
            { RockShape.Plus, new HashSet<int>() },
            { RockShape.MirroredL, new HashSet<int>() },
            { RockShape.VerticalLine, new HashSet<int>() },
            { RockShape.Square, new HashSet<int>() }
        };
        var rockReleaseProfile = new Dictionary<(RockShape RockShape, int JetPatternIndex, string ChamberProfile), (long RockIndex, long Height, string TopXHeights)>();
        long cycleDuration = 0;
        var cycleHeightDelta = 0;

        long rockNumber = 1;
        var inRepeatedCycle = false;
        while (rockNumber < numberOfDrops + 1)
        {
            var shapeEnum = (RockShape)((rockNumber - 1) % 5);

            if (!rockJetTracker[shapeEnum].Contains(jetPatternIndex))
            {
                rockJetTracker[shapeEnum].Add(jetPatternIndex);
            }
            else
            {
                // This rock shape has started from this part of the jet pattern before. Is the height profile the same?
                var chamberProfile = chamber.GetProfileForHeights();
                if (rockReleaseProfile.ContainsKey((shapeEnum, jetPatternIndex, chamberProfile)))
                {
                    var (rockIndex, height, _) = rockReleaseProfile[(shapeEnum, jetPatternIndex, chamberProfile)];
                    cycleDuration = rockNumber - rockIndex;
                    cycleHeightDelta = (int)(chamber.GetHighestRock() - height);
                    inRepeatedCycle = chamber.RockFormationIsRepeated(chamber.GetHighestRock(), cycleHeightDelta);
                    if (!inRepeatedCycle)
                        throw new Exception("Rock formation is different, but with same height deltas.");
                }
                else
                {
                    rockReleaseProfile.Add((shapeEnum, jetPatternIndex, chamberProfile), (rockNumber, chamber.GetHighestRock(), string.Empty));
                }
            }

            if (inRepeatedCycle)
            {
                var remainingCycles = (long)Math.Floor(((double)numberOfDrops - rockNumber) / cycleDuration);
                chamber.BumpBlockedHeights(remainingCycles * cycleHeightDelta, remainingCycles * cycleDuration);
                
                // Move to the next rock (close to the end of the series) and drop on the existed pattern
                rockNumber = chamber.NumberOfRocksDropped + 1;
                inRepeatedCycle = false;
                rockJetTracker = rockJetTracker.Keys.ToDictionary(k => k, v => new HashSet<int>());
                rockReleaseProfile.Clear();
            }
            else
            {
                var rock = Shape.MakeShape(shapeEnum);
                var rockIsMoving = true;
                var bottomLeftIndex = 2;
                var bottomLeftHeight = chamber.GetHighestRock() + 4; // Three clear rows above
                while (rockIsMoving)
                {
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
                        var landingHeights = chamber.PlaceRock(rock, bottomLeftIndex, bottomLeftHeight);
                        heights = heights.AppendLine($"Rock {rockNumber.ToString().PadRight(4)} ends on jet pattern index {jetPatternIndex.ToString().PadRight(2)} and is a {Enum.GetName(shapeEnum)?.PadRight(15)}: {string.Join(',', landingHeights)}");
                    }
                    else
                    {
                        bottomLeftHeight = bottomLeftHeightAfterFall;
                    }

                    jetPatternIndex = (jetPatternIndex + 1) % jetPattern.Count;
                }
                rockNumber++;
            }
        }

        _logger.LogDebug(heights.ToString());
        
        return chamber.GetHighestRock();
    }
}
