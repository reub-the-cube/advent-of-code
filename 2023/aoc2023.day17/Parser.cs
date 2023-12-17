using AoC.Core;
using aoc2023.day17.domain;

namespace aoc2023.day17
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var trafficPattern = input.Select(i => i.Chunk(1).Select(c => int.Parse(c)).ToList()).ToList();
            return new Input(trafficPattern);
        }
    }
}
