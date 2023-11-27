using AoC.Core;
using aoc2020.day02.domain;

namespace aoc2020.day02
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            return new Input
            {
                PolicyPasswordPairs = input.Select(s => ParseLine(s)).ToList()
            };
        }

        private static KeyValuePair<Policy, string> ParseLine(string inputLine)
        {
            string[] splitInputLine = inputLine.Split('-', ' ', ':');
            return new KeyValuePair<Policy, string>(
                new Policy(int.Parse(splitInputLine[0]), int.Parse(splitInputLine[1]), char.Parse(splitInputLine[2])),
                splitInputLine.Last()
            );
        }
    }
}