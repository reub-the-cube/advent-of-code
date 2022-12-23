using AoC.Core;
using aoc2022.day21.domain;

namespace aoc2022.day21
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var riddle = new Riddle();

            foreach (var item in input)
            {
                var split = item.Split(" ");
                var monkeyName = split[0][..^1];
                if (split.Length > 2)
                {
                    riddle.AddMonkey(monkeyName, split[1], split[3], split[2]);
                }
                else
                {
                    riddle.AddMonkey(monkeyName, long.Parse(split[1]));
                }
            }

            return new Input(riddle);
        }
    }
}
