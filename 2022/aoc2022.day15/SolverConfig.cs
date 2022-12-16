namespace aoc2022.day15
{
    public class SolverConfig : ISolverConfig
    {
        private const int ROW_TO_INSPECT = 2000000;
        private const int MIN_INDEX_FOR_PART_TWO = 0;
        private const int MAX_INDEX_FOR_PART_TWO = 4000000;

        public int RowToInspectForPartOne { get => ROW_TO_INSPECT; }

        public int MinIndexForPartTwo { get => MIN_INDEX_FOR_PART_TWO; }

        public int MaxIndexForPartTwo { get => MAX_INDEX_FOR_PART_TWO; }
    }
}
