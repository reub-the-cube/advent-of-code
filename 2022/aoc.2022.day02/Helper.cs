using static aoc._2022.day02.Enums;

namespace aoc._2022.day02
{
    public static class MapperHelper
    {
        public static readonly Dictionary<char, RockPaperScissor> InputCodeToShape = new() {
            { 'A', RockPaperScissor.Rock },
            { 'B', RockPaperScissor.Paper },
            { 'C', RockPaperScissor.Scissor },
            { 'X', RockPaperScissor.Rock },
            { 'Y', RockPaperScissor.Paper },
            { 'Z', RockPaperScissor.Scissor }
        };

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

    public class RoundHelper
    {
        public static int OutcomeScore(RockPaperScissor thisShape, RockPaperScissor otherShape)
        {
            int thisScore = MapperHelper.ShapeToScore[thisShape];
            int otherScore = MapperHelper.ShapeToScore[otherShape];

            // 2 beats 1, 3 beats 2, 1 beats 3
            // 2 ties 2, 3 ties 3, 1 ties 1
            // 2 loses 3, 3 loses 1, 1 loses 2
            return ((thisScore + 3 - otherScore) % 3) switch
            {
                1 => 6,   // Wins!
                2 => 0,   // Loss!
                0 => 3,   // Tie!
                _ => throw new NotImplementedException()
            };
        }

        public static RockPaperScissor MapToShapeFromDesiredResult(char result, RockPaperScissor opponentShape)
        {
            var opponentModScore = MapperHelper.ShapeToScore[opponentShape] % 3;

            // for a loss, map 1 to 0, 2 to 1, 0 to 2
            // for a draw, map 1 to 1, 2 to 2, 0 to 0
            // for a win, map 1 to 2, 2 to 0, 0 to 1
            return result switch
            {
                'X' => MapperHelper.ModScoreToShape[(opponentModScore + 2) % 3],     // Loses!
                'Y' => MapperHelper.ModScoreToShape[opponentModScore],               // Ties!
                'Z' => MapperHelper.ModScoreToShape[(opponentModScore + 1) % 3],     // Wins!
                _ => throw new NotImplementedException(),
            };
        }
    }
}