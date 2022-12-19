using static aoc2022.day17.Enums;

namespace aoc2022.day17.domain
{
    public abstract class Shape
    {
        public Shape() { }

        public abstract bool IsBlockedBelow(HashSet<int>[] heights, int bottomLeftIndex, int bottomLeftHeight);

        public abstract bool IsBlockedToTheLeft(HashSet<int>[] heights, int bottomLeftIndex, int bottomLeftHeight);

        public abstract bool IsBlockedToTheRight(HashSet<int>[] heights, int bottomLeftIndex, int bottomLeftHeight);

        public abstract void UpdateHeightsAfterComingToRest(ref HashSet<int>[] heights, int bottomLeftIndex, int bottomLeftHeight);

        public static Shape MakeShape(RockShape rockShape)
        {
            return rockShape switch
            {
                RockShape.HorizontalLine => new HorizontalLine(),
                RockShape.VerticalLine => new VerticalLine(),
                RockShape.Plus => new Plus(),
                RockShape.Square => new Square(),
                RockShape.MirroredL => new MirroredL(),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
