using AoC.Core;
using aoc2022.day09.domain;

namespace aoc2022.day09
{
    public class Parser : IParser<Instruction[]>
    {
        public Instruction[] ParseInput(string[] input)
        {
            return input.Select(BuildInstruction).ToArray();
        }

        private static Instruction BuildInstruction(string inputRow)
        {
            var direction = inputRow[0];
            var xMovement = 0;
            var yMovement = 0;
            var movementCount = int.Parse(inputRow[2..]);

            if (direction == 'U') yMovement++;
            if (direction == 'R') xMovement++;
            if (direction == 'D') yMovement--;
            if (direction == 'L') xMovement--;

            return new Instruction(xMovement, yMovement, movementCount);
        }
    }
}
