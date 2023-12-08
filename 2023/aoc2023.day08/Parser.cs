using AoC.Core;
using aoc2023.day08.domain;
using System.Text.RegularExpressions;

namespace aoc2023.day08
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var network = input.Skip(2).Select(CreateNode).ToDictionary(k => k.Id, v => v);
            var selectorSequence = input[0].ToCharArray();

            return new Input(network, selectorSequence);
        }

        private static Node CreateNode(string nodeInput)
        {
            var nodeMatches = Regex.Matches(nodeInput, @"\b[A-Z]+\b");
            return new Node(nodeMatches[0].Value, nodeMatches[1].Value, nodeMatches[2].Value);
        }
    }
}
