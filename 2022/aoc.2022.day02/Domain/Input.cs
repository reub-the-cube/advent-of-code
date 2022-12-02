using static aoc._2022.day02.Enums;

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
        public int MyScore => MapperHelper.ShapeToScore[Me] + RoundHelper.OutcomeScore(Me, Them);
    }
}