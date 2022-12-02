using aoc._2022.day02.domain;
using AoC.Core;
using static aoc._2022.day02.Enums;

namespace aoc._2022.day02
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var parsedInput = new Input();

            Array.ForEach(input, i =>
            {
                var opponentShape = MapperHelper.InputCodeToShape[i[0]];

                parsedInput.AddRoundToStrategyOne(new Round(opponentShape, MapperHelper.InputCodeToShape[i[2]]));
                parsedInput.AddRoundToStrategyTwo(new Round(opponentShape, RoundHelper.MapToShapeFromDesiredResult(i[2], opponentShape)));
            });

            return parsedInput;
        }
    }
}
