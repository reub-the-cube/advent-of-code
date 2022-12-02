using static aoc._2022.day02.Enums;

namespace aoc._2022.day02.domain
{
    public class Input
    {
        private readonly RockPaperScissorsGame[] Games = new RockPaperScissorsGame[2] { new RockPaperScissorsGame(), new RockPaperScissorsGame() };

        public void AddRoundToGame(int gameIndex, Round round)
        {
            Games[gameIndex].AddRound(round);
        }

        public int GetMyGameScore(int gameIndex)
        {
            return Games[gameIndex].MyGameScore;
        }
    }

    public readonly record struct RockPaperScissorsGame(List<Round> Rounds)
    {
        public RockPaperScissorsGame() : this(new List<Round>()) { }

        public void AddRound(Round round) => Rounds.Add(round);

        public int MyGameScore => Rounds.Sum(r => r.MyRoundScore);
    }

    public readonly record struct Round(RockPaperScissor Them, RockPaperScissor Me)
    {
        public int MyRoundScore => MapperHelper.ShapeToScore[Me] + RoundHelper.OutcomeScore(Me, Them);
    }
}