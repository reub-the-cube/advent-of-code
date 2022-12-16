namespace aoc2022.day15
{
    public interface ISolverConfig
    {
        int RowToInspectForPartOne { get; }
        int MinIndexForPartTwo { get; }
        int MaxIndexForPartTwo { get; }
    }
}
