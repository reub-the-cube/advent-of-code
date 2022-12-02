using static aoc._2022.day02.Enums;

namespace aoc._2022.day02.domain
{
    public class Input
    {
        private readonly RockPaperScissorsGame StrategyOneGame = new(new List<Round>());
        private readonly RockPaperScissorsGame StrategyTwoGame = new(new List<Round>());

        public void AddRoundToStrategyOne(Round round)
        {
            StrategyOneGame.AddRound(round);
        }

        public void AddRoundToStrategyTwo(Round round)
        {
            StrategyTwoGame.AddRound(round);
        }

        public (int StrategyOneTotal, int StrategyTwoTotal) GetMyTotalScores()
        {
            return (StrategyOneGame.MyGameScore, StrategyTwoGame.MyGameScore);
        }
    }

    public readonly record struct RockPaperScissorsGame(List<Round> Rounds)
    {
        public void AddRound(Round round) => Rounds.Add(round);

        public int MyGameScore => Rounds.Sum(r => r.MyRoundScore);
    }

    public readonly record struct Round(RockPaperScissor Them, RockPaperScissor Me)
    {
        public int MyRoundScore => MapperHelper.ShapeToScore[Me] + RoundHelper.OutcomeScore(Me, Them);
    }
}