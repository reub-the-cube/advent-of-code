using AoC.Core;
using aoc2023.day11.domain;

namespace aoc2023.day11
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            return new Input(input.ToList());
        }
    }
}
