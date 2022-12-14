using aoc2022.day14.domain;

namespace aoc2022.day14
{
    public static class PositionExtensions
    {
        public static Position MoveDown(this Position position)
        {
            return new Position(position.Row + 1, position.Column);
        }

        public static Position MoveDownAndLeft(this Position position)
        {
            return new Position(position.Row + 1, position.Column - 1);
        }

        public static Position MoveDownAndRight(this Position position)
        {
            return new Position(position.Row + 1, position.Column + 1);
        }
    }
}
