using AoC.Core;
using aoc._2022.day03.domain;

namespace aoc._2022.day03
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var rucksacks = input.Select(rucksackItems =>
            {
                var compartmentOne = rucksackItems[..(rucksackItems.Length / 2)];
                var compartmentTwo = rucksackItems[(rucksackItems.Length / 2)..];

                return new Rucksack(compartmentOne, compartmentTwo);
            });

            return new Input(rucksacks.ToList());
        }
    }
}
