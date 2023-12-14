using AoC.Core;
using aoc2023.day14.domain;

namespace aoc2023.day14
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var parsedInput = new Input(input.ToList());
            return parsedInput;
        }
    }
}
