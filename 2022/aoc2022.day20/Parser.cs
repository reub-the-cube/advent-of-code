using AoC.Core;
using aoc2022.day20.domain;

namespace aoc2022.day20
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var originalNumbers = new Dictionary<long, long>();

            for (int i = 0; i < input.Length; i++)
            {
                _ = long.TryParse(input[i], out long parsedNumber);
                originalNumbers.Add(i, parsedNumber);
            }
            
            return new Input(originalNumbers);
        }
    }
}
