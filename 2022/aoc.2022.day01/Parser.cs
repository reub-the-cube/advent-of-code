using AoC.Core;
using aoc._2022.day01.models;

namespace aoc._2022.day01
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var parsedInput = new Input();

            int elfIndex = 0;
            List<int> elfCalories = new();

            foreach (var item in input)
            {
                if (string.IsNullOrWhiteSpace(item))
                {
                    // End of elf's calories.
                    // Create a new elf and clear the list.
                    parsedInput.AddElf(new Elf(elfCalories, elfIndex));
                    elfIndex++;
                    elfCalories.Clear();
                }
                else
                {
                    // Add this item to the elf's calories
                    elfCalories.Add(int.Parse(item));
                }
            }

            // Add the last elf
            parsedInput.AddElf(new Elf(elfCalories, elfIndex));

            return parsedInput;
        }
    }
}
