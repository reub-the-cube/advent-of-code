using AoC.Core;
using aoc2022.day18.domain;

namespace aoc2022.day18
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var cubes = input.Select(i =>
            {
                var splitInput = i.Split(',');
                return new Cube(int.Parse(splitInput[0]), int.Parse(splitInput[1]), int.Parse(splitInput[2]));
            }).ToList();

            return new Input(cubes);
        }
    }
}
