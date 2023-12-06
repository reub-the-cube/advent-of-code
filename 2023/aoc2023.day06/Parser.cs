using AoC.Core;
using aoc2023.day06.domain;

namespace aoc2023.day06
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var splitTimes = input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToList();
            var splitDistances = input[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(int.Parse).ToList();

            var parsedInput = new Input();

            for (int i = 0; i < splitTimes.Count; i++)
            {
                parsedInput.AddRaceEvent(new RaceEvent(splitTimes[i], splitDistances[i]));
            }

            return parsedInput;
        }

        public static Input ReformInput(string[] input)
        {
            var times = string.Join(string.Empty, input[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1));
            var distances = string.Join(string.Empty, input[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1));

            var newInput = new[]
            {
                $"{input[0].Split(' ')[0]} {times}",
                $"{input[1].Split(' ')[0]} {distances}"
            };

            var splitTimes = newInput[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(long.Parse).ToList();
            var splitDistances = newInput[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(long.Parse).ToList();

            var parsedInput = new Input();

            for (int i = 0; i < splitTimes.Count; i++)
            {
                parsedInput.AddRaceEvent(new RaceEvent(splitTimes[i], splitDistances[i]));
            }

            return parsedInput;
        }
    }
}
