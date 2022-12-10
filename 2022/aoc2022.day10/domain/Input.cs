namespace aoc2022.day10.domain
{
    public class Input
    {
        public List<Instruction> Instructions { get; init; }

        public Input(List<Instruction> instructions)
        {
            Instructions = instructions;
        }
    }
}