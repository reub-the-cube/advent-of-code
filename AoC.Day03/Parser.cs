using AoC.Core;
using AoC.Day03.Models;

namespace AoC.Day03
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            return new Input(input.Select(ParseLine).ToArray());
        }

        private static uint ParseLine(string line)
        {
            return Convert.ToUInt32(line, fromBase: 2);
        }
    }
}
