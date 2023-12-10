using AoC.Core;
using aoc2023.day10.domain;

namespace aoc2023.day10
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var sketchLayout = input.Select(i => i.ToCharArray()).ToArray();
            return new Input(sketchLayout);
        }
    }
}
