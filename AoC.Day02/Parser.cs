using AoC.Core;
using AoC.Day02.Models;
using System.Diagnostics;
using static AoC.Day02.Enums;

namespace AoC.Day02
{
    public class Parser : IParser<Input>
    {
        public Input[] ParseInput(string[] input)
        {
            return input.Select(ParseLine).ToArray();
        }

        private Input ParseLine(string line)
        {
            var split = line.Split(' ');

            Debug.Assert(split.Length == 2);
            return new Input(ParseCommand(split[0]), ParseUnitsOfChange(split[1]));
        }

        private static SubmarineCommand ParseCommand(string command)
        {
            return command switch
            {
                "forward" => SubmarineCommand.Forward,
                "up" => SubmarineCommand.Up,
                "down" => SubmarineCommand.Down,
                _ => throw new ArgumentOutOfRangeException($"Submarine command {command} is not allowed.")
            };
        }

        private static int ParseUnitsOfChange(string unitsOfChange)
        {
            return int.Parse(unitsOfChange);
        }
    }
}
