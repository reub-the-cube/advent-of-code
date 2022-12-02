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

            Array.ForEach(input, i => parsedInput.AddRoundToStrategyOne(new Round(MapperHelper.InputCodeToShape[i[0]], MapperHelper.InputCodeToShape[i[2]])));
            Array.ForEach(input, i => parsedInput.AddRoundToStrategyTwo(new Round(MapperHelper.InputCodeToShape[i[0]], RoundHelper.MapToShapeFromDesiredResult(i[2], MapperHelper.InputCodeToShape[i[0]]))));

            return parsedInput;
        }


    }
}
