using AoC.Core;
using aoc2022.day05.domain;
using System.Text.RegularExpressions;

namespace aoc2022.day05
{
    public class Parser : IParser<UnloadingYard>
    {
        private static readonly Regex DigitRegex = new("\\d+");

        public UnloadingYard ParseInput(string[] input)
        {
            // Get index of empty row (initial state above, instructions below)
            var emptyRowIndex = Array.FindIndex(input, string.IsNullOrWhiteSpace);

            var stackIndexes = GetStackIndexes(input[emptyRowIndex - 1]);
            var initialStacks = stackIndexes.ToDictionary(s => s, stackIndex =>
            {
                var initialCratesForStack = input
                    .Take(emptyRowIndex - 1)                                // Take the (maximum) number of rows for all the crates that could be in this stack
                    .Select(s => s.Substring((stackIndex - 1) * 4, 3))      // Choose the three characters that define the crate
                    .Where(s => !string.IsNullOrWhiteSpace(s))              // Remove empty entries, because it means a crate isn't there
                    .Reverse();                                             // Reverse the enumerable, because we want most recent crates at the end of the list

                return initialCratesForStack.ToList();
            });

            var instructions = input.Skip(emptyRowIndex + 1).Select(GetRearrangementProcedureStep).ToList();

            return new UnloadingYard(initialStacks, new RearrangementProcedure(instructions));
        }

        private static (int NumberOfCrates, int From, int To) GetRearrangementProcedureStep(string inputRow)
        {
            var instructions = DigitRegex.Matches(inputRow).Select(m => int.Parse(m.Value)).ToList();
            return (instructions[0], instructions[1], instructions[2]);
        }

        private static IEnumerable<int> GetStackIndexes(string inputRow)
        {
            var stacks = inputRow.Split(Array.Empty<char>(), StringSplitOptions.RemoveEmptyEntries);

            if (stacks.Length > 9) throw new NotImplementedException("Haven't worked out how to do more than 9 stacks.");

            return stacks.Select(int.Parse);
        }
    }
}
