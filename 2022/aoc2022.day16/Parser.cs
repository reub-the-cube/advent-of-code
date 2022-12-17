using AoC.Core;
using aoc2022.day16.domain;
using System.Text.RegularExpressions;

namespace aoc2022.day16
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var valveFlowRates = new Dictionary<string, int>();
            var valveTunnels = new Dictionary<string, List<string>>();

            foreach (var inputRow in input)
            {
                var parsedRow = Regex.Split(inputRow, "\\s|=|;|,");
                if (int.TryParse(parsedRow[5], out int flowRate) && flowRate > 0)
                {
                    valveFlowRates.Add(parsedRow[1], flowRate);
                }
                valveTunnels.Add(parsedRow[1], parsedRow[11..].Where(v => !string.IsNullOrEmpty(v)).ToList());
            }

            return new Input(valveFlowRates, valveTunnels);
        }
    }
}
