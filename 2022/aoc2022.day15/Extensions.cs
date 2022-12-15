using aoc2022.day15.domain;

namespace aoc2022.day15;

public static class Extensions
{
    public static int GetManhattanDistance(this Position from, Position to)
    {
        return Math.Abs(from.Column - to.Column) + Math.Abs(from.Row - to.Row);
    }
}