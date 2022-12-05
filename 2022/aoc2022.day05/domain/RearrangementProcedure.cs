namespace aoc2022.day05.domain
{
    public readonly record struct RearrangementProcedure(List<(int NumberOfCrates, int FromStack, int ToStack)> Steps);
}
