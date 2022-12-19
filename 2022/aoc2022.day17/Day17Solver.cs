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

        var answerOne = GetHeightOfRocksAfterAllDrops(2022, parsedInput.ToCharArray());
        var answerTwo = GetHeightOfRocksAfterAllDrops(1000000000000, parsedInput.ToCharArray());

        return (answerOne.ToString(), answerTwo.ToString());
    }

    private static long GetHeightOfRocksAfterAllDrops(long numberOfDrops, IReadOnlyList<char> jetPattern)
    {
        var startingChamber = new Chamber(Enumerable.Repeat(0, 7).ToArray());
        var (Chamber, CycleDuration, JetPatternOffset, CycleHeightDelta, CycleShape) = HeightOfRocksAfterAllDrops(startingChamber, numberOfDrops, jetPattern, (int)RockShape.HorizontalLine);

        if (CycleDuration == 0)
        {
            return Chamber.GetHighestRock();
        }

        var numberOfCyclesRemaining = (long)Math.Floor((double)((numberOfDrops - Chamber.NumberOfRocksDropped) / CycleDuration));
        //var numberOfDropsToCompleteAtTheEnd = ((numberOfCyclesRemaining * CycleDuration) + Chamber.NumberOfRocksDropped) % CycleDuration;
        var numberOfDropsToCompleteAtTheEnd = (numberOfDrops % CycleDuration) - (Chamber.NumberOfRocksDropped % CycleDuration);
        var offsetJetPatten = jetPattern.Skip(JetPatternOffset + 1).Concat(jetPattern.Take(JetPatternOffset + 1)).ToArray();

        // Do the bit before it starts repeating, then the end of whatever's left
        var (FinalChamberHeights, _, _, _, _) = HeightOfRocksAfterAllDrops(Chamber, numberOfDropsToCompleteAtTheEnd, offsetJetPatten, (int)CycleShape + 1);

        var overallHeight = FinalChamberHeights.GetHighestRock() + ((long)CycleHeightDelta * numberOfCyclesRemaining);

        return overallHeight;

        // Want to do 22                                                                        dsf + dae + duration = rem = total drops
        //  1   2   3           1   2   3   4                                                   (Drops so far + Drops at end) % duration = (total drops) % duration
        //  4   5   6   7       5   6   7   8   9
        //  8   9   10  11      10  11  12  13  14              Number of cycles remaining
        //  12  13  14  15      15  16  17  18  19
        //  16  17  18  19      20  21  22
        //  20  21  22
    }

    private static int HeightOfRocksAfter2022Drops(IReadOnlyList<char> jetPattern)
    {
        return HeightOfRocksAfterAllDrops(new Chamber(Enumerable.Repeat(0, 7).ToArray()), 2022, jetPattern, (int)RockShape.HorizontalLine).Chamber.GetHighestRock();
        //var chamber = new Chamber(Enumerable.Repeat(0, 7).ToArray());
        //var jetPatternIndex = 0;

        //for (var rockNumber = 0; rockNumber < 2022; rockNumber++)
        //{
        //    if (rockNumber % 10000 == 0) Debug.WriteLine($"Placing rock number {rockNumber}.");

        //    var shapeEnum = (RockShape)(rockNumber % 5);
        //    var rock = Shape.MakeShape(shapeEnum);

        //    var rockIsMoving = true;
        //    var bottomLeftIndex = 2;
        //    var bottomLeftHeight = chamber.GetHighestRock() + 4; // Three clear rows above

        //    while (rockIsMoving)
        //    {

        //        bottomLeftIndex = jetPattern[jetPatternIndex] switch
        //        {
        //            '<' => chamber.PushRockLeft(rock, bottomLeftIndex, bottomLeftHeight),
        //            '>' => chamber.PushRockRight(rock, bottomLeftIndex, bottomLeftHeight),
        //            _ => throw new Exception($"Unexpected character in jet pattern {jetPattern[jetPatternIndex]}")
        //        };

        //        var bottomLeftHeightAfterFall = chamber.LetRockFall(rock, bottomLeftIndex, bottomLeftHeight);

        //        if (bottomLeftHeightAfterFall == bottomLeftHeight)
        //        {
        //            // Rock is resting
        //            rockIsMoving = false;
        //            _ = chamber.PlaceRock(rock, bottomLeftIndex, bottomLeftHeight);
        //        }
        //        else
        //        {
        //            bottomLeftHeight = bottomLeftHeightAfterFall;
        //        }

        //        jetPatternIndex = (jetPatternIndex + 1) % jetPattern.Count;
        //    }
        //}

        //var finalHeight = chamber.GetHighestRock();
        //return finalHeight;
    }

    private static (Chamber Chamber, int CycleDuration, int JetPatternOffset, int CycleHeightDelta, RockShape CycleShape) HeightOfRocksAfterAllDrops(Chamber chamber, long numberOfDrops, IReadOnlyList<char> jetPattern, int startingRock)
    {
        var jetPatternIndex = 0;
        var rockJetTracker = new Dictionary<RockShape, HashSet<int>>()
        {
            { RockShape.HorizontalLine, new HashSet<int>() },
            { RockShape.Plus, new HashSet<int>() },
            { RockShape.MirroredL, new HashSet<int>() },
            { RockShape.VerticalLine, new HashSet<int>() },
            { RockShape.Square, new HashSet<int>() }
        };
        var rockReleaseProfile = new Dictionary<(RockShape, string), (int RockIndex, int Height)>();
        var cycleDuration = 0;
        var cycleHeightDelta = 0;
        var cycleStartingShape = RockShape.MirroredL;

        for (var rockNumber = startingRock; rockNumber < numberOfDrops + startingRock; rockNumber++)
        {
            if (rockNumber % 10000 == 0) Debug.WriteLine($"Placing rock number {rockNumber}.");

            var shapeEnum = (RockShape)(rockNumber % 5);
            var rock = Shape.MakeShape(shapeEnum);

            var rockIsMoving = true;
            var bottomLeftIndex = 2;
            var bottomLeftHeight = chamber.GetHighestRock() + 4; // Three clear rows above

            if (!rockJetTracker[shapeEnum].Contains(jetPatternIndex))
            {
                rockJetTracker[shapeEnum].Add(jetPatternIndex);
            }
            else
            {
                // This rock shape has started from this part of the jet pattern before. Is the height profile the same?
                var chamberProfile = chamber.GetHeightProfile();
                if (rockReleaseProfile.ContainsKey((shapeEnum, chamberProfile)))
                {
                    var (RockIndex, Height) = rockReleaseProfile[(shapeEnum, chamberProfile)];
                    cycleDuration = rockNumber - RockIndex;
                    cycleHeightDelta = chamber.GetHighestRock() - Height;
                    cycleStartingShape = shapeEnum;
                    break;
                }
                else
                {
                    rockReleaseProfile.Add((shapeEnum, chamberProfile), (rockNumber, chamber.GetHighestRock()));
                }
            }

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
                    _ = chamber.PlaceRock(rock, bottomLeftIndex, bottomLeftHeight);
                }
                else
                {
                    bottomLeftHeight = bottomLeftHeightAfterFall;
                }

                jetPatternIndex = (jetPatternIndex + 1) % jetPattern.Count;
            }
        }

        return (chamber, cycleDuration, jetPatternIndex, cycleHeightDelta, cycleStartingShape);
    }
}
