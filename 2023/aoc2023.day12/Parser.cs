using AoC.Core;
using aoc2023.day12.domain;

namespace aoc2023.day12
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var parsedInput = new Input();

            foreach (var item in input)
            {
                var inputSplitBySpace = item.Split(' ');
                var springArrangements = inputSplitBySpace[0];
                var contiguousGroups = inputSplitBySpace[1].Split(',').Select(int.Parse).ToList();

                parsedInput.AddSpringConditionsRecord(new SpringConditionsRecord(springArrangements, contiguousGroups));
            }

            return parsedInput;
        }
    }
}
