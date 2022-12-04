using aoc._2022.day04.domain;
using AoC.Core;

namespace aoc._2022.day04
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var assignmentPairs = input.Select(ParseInputRow);

            return new Input(assignmentPairs.ToList());
        }

        private static AssignmentPair ParseInputRow(string inputRow)
        {
            var elfAssignments = inputRow.Split(',');

            var elfOneLowerEndOfRange = int.Parse(elfAssignments[0].Split('-')[0].ToString());
            var elfOneHigherEndOfRange = int.Parse(elfAssignments[0].Split('-')[1].ToString());
            var elfTwoLowerEndOfRange = int.Parse(elfAssignments[1].Split('-')[0].ToString());
            var elfTwoHigherEndOfRange = int.Parse(elfAssignments[1].Split('-')[1].ToString());

            return new AssignmentPair(elfOneLowerEndOfRange..elfOneHigherEndOfRange, elfTwoLowerEndOfRange..elfTwoHigherEndOfRange);
        }
    }
}
