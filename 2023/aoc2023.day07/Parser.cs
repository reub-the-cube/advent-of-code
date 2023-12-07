using AoC.Core;
using aoc2023.day07.domain;

namespace aoc2023.day07
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            return new Input(input.Select(i => (i.Split(' ')[0], int.Parse(i.Split(' ')[1]))).ToList());
        }
    }
}
