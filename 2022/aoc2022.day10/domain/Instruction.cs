namespace aoc2022.day10.domain
{
    public class Instruction
    {
        public int CyclesToCompletion { get; init; }
        public int CycleCounter { get; private set; }
        public int XRegisterIncreaseOnCompletion { get; init; }

        public Instruction(int cyclesToCompletion, int xRegisterIncreaseOnCompletion)
        {
            CyclesToCompletion = cyclesToCompletion;
            CycleCounter = 0;
            XRegisterIncreaseOnCompletion = xRegisterIncreaseOnCompletion;
        }

        public void IncreaseCycleCounter()
        {
            CycleCounter++;
        }

        public bool IsFinished()
        {
            return CycleCounter == CyclesToCompletion;
        }
    }
}
