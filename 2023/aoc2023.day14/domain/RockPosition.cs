using static aoc2023.day14.Enums;

namespace aoc2023.day14.domain
{
    public readonly record struct RockPosition(Position Position, RockType RockType);

    public readonly record struct Position(int Row, int Column);
}