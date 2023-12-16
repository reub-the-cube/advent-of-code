using AoC.Core;
using aoc2023.day16.domain;

namespace aoc2023.day16
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
