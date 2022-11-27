using AoC.Core;
using AoC.Day03.Models;
using System.Diagnostics;

namespace AoC.Day03
{
    public class Parser : IParser<Input>
    {
        public Input[] ParseInput(string[] input)
        {
            return input.Select(ParseLine).ToArray();
        }

        private Input ParseLine(string line)
        {
            return new Input(Convert.ToUInt32(line, fromBase: 2));
        }
    }
}
