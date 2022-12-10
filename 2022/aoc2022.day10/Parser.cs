using AoC.Core;
using aoc2022.day10.domain;

namespace aoc2022.day10
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var instructions = new List<Instruction>();

            foreach (var item in input)
            {
                if (item == "noop")
                {
                    instructions.Add(new Instruction(1, 0));
                }
                else
                {
                    instructions.Add(new Instruction(2, int.Parse(item[5..])));
                }
            }

            return new Input(instructions);
        }
    }
}
