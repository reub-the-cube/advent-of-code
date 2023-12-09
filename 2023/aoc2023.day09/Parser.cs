using AoC.Core;
using aoc2023.day09.domain;

namespace aoc2023.day09
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var history = input.Select(i => i.Split(" ").Select(int.Parse).ToList()).ToList();
            return new Input(history);
        }
    }
}
