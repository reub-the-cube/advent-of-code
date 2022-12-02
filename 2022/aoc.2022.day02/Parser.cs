using aoc._2022.day02.domain;
using AoC.Core;
using static aoc._2022.day02.domain.Enums;

namespace aoc._2022.day02
{
    public class Parser : IParser<Input>
    {
        private readonly Dictionary<char, RockPaperScissor> ColumnCodeToShape = new() {
            { 'A', RockPaperScissor.Rock },
            { 'B', RockPaperScissor.Paper },
            { 'C', RockPaperScissor.Scissor },
            { 'X', RockPaperScissor.Rock },
            { 'Y', RockPaperScissor.Paper },
            { 'Z', RockPaperScissor.Scissor }
        };

        public Input ParseInput(string[] input)
        {
            var parsedInput = new Input();

            Array.ForEach(input, i => parsedInput.AddRoundToStrategyOne(new Round(ColumnCodeToShape[i[0]], ColumnCodeToShape[i[2]])));
            Array.ForEach(input, i => parsedInput.AddRoundToStrategyTwo(new Round(ColumnCodeToShape[i[0]], MapToShapeFromDesiredResult(i[2], ColumnCodeToShape[i[0]]))));

            return parsedInput;
        }

        private static RockPaperScissor MapToShapeFromDesiredResult(char result, RockPaperScissor opponentShape)
        {
            var opponentScore = Helper.ShapeToScore[opponentShape];

            return result switch
            {
                'X' => Helper.ModScoreToShape[(opponentScore + 2) % 3],         // Loses!
                'Y' => Helper.ModScoreToShape[opponentScore % 3],               // Ties!
                'Z' => Helper.ModScoreToShape[(opponentScore + 1) % 3],         // Wins!
                _ => throw new NotImplementedException(),
            };
        }
    }
}
