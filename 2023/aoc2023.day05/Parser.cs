using AoC.Core;
using aoc2023.day05.domain;

namespace aoc2023.day05
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var seeds = input[0]
                .Split(':')[1]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            var parsedInput = new Input
            {
                Seeds = seeds,
                Maps = new Dictionary<string, Map>()
            };

            var mapName = "";
            var mappingRanges = new List<MappingRange>();

            for (int i = 2; i < input.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(input[i]))
                {

                }
                else if (input[i].Contains("map"))
                {
                    // New map
                    mapName = input[i].Split(' ')[0];
                    mappingRanges = new List<MappingRange>();
                    parsedInput.Maps.Add(mapName, new Map(mappingRanges));
                }
                else
                {
                    // Range information
                    var mappingInformation = input[i].Split(' ');
                    mappingRanges.Add(new MappingRange(
                        int.Parse(mappingInformation[1]), 
                        int.Parse(mappingInformation[2]), 
                        int.Parse(mappingInformation[0])));
                    var newMap = new Map(mappingRanges);
                    parsedInput.Maps[mapName] = newMap;
                }
            }

            return parsedInput;
        }
    }
}
