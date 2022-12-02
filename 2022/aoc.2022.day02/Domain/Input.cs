using static aoc._2022.day02.domain.Enums;

namespace aoc._2022.day02.domain
{
    public class Input
    {
        readonly List<Round> StrategyOneRounds = new();
        readonly List<Round> StrategyTwoRounds = new();

        public void AddRoundToStrategyOne(Round round)
        {
            StrategyOneRounds.Add(round);
        }

        public void AddRoundToStrategyTwo(Round round)
        {
            StrategyTwoRounds.Add(round);
        }

        public (int StrategyOneTotal, int StrategyTwoTotal) GetMyTotalScore()
        {
            return (StrategyOneRounds.Sum(r => r.MyScore), StrategyTwoRounds.Sum(r => r.MyScore));
        }
    }

    public readonly record struct Round(RockPaperScissor Them, RockPaperScissor Me)
    {
        public int MyScore => Helper.ShapeToScore[Me] + OutcomeScore(Helper.ShapeToScore[Me], Helper.ShapeToScore[Them]);

        private static int OutcomeScore(int thisScore, int otherScore)
        {
            // 2 beats 1, 3 beats 2, 1 beats 3                  1, 1, -2
            // 2 ties 2, 3 ties 3, 1 ties 1                     0, 0, 0
            // 2 loses 3, 3 loses 1, 1 loses 2                  -1, 2, -1
            return ((thisScore - otherScore) % 3) switch
            {
                1 or -2 => 6, // Wins!
                2 or -1 => 0, // Loss!
                0 => 3, // Tie!
                _ => throw new NotImplementedException()
            };
        }
    }

    public static class Helper
    {
        public static readonly Dictionary<RockPaperScissor, int> ShapeToScore = new()
        {
            { RockPaperScissor.Rock, 1 },
            { RockPaperScissor.Paper, 2 },
            { RockPaperScissor.Scissor, 3 },
        };

        public static readonly Dictionary<int, RockPaperScissor> ModScoreToShape = new()
        {
            { 1, RockPaperScissor.Rock },
            { 2, RockPaperScissor.Paper },
            { 0, RockPaperScissor.Scissor },
        };
    }

    public class Enums
    {
        public enum RockPaperScissor
        {
            Rock,
            Paper,
            Scissor
        }
    }
}