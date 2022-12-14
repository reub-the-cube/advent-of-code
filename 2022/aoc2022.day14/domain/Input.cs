namespace aoc2022.day14.domain
{
    public class Input
    {
        public CaveSlice CaveSlice { get; init; }

        public Input(CaveSlice caveSlice, int columnOffset)
        {
            CaveSlice = caveSlice;
        }
    }
}