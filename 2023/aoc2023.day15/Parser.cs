using AoC.Core;
using aoc2023.day15.domain;

namespace aoc2023.day15
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            return new Input(input[0].Split(',').ToList());
        }
    }
}
