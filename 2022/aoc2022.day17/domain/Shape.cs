using static aoc2022.day17.Enums;

namespace aoc2022.day17.domain
{
    public abstract class Shape
    {
        public Shape() { }

        public abstract bool IsBlockedBelow(HashSet<long>[] heights, int bottomLeftIndex, long bottomLeftHeight);

        public abstract bool IsBlockedToTheLeft(HashSet<long>[] heights, int bottomLeftIndex, long bottomLeftHeight);

        public abstract bool IsBlockedToTheRight(HashSet<long>[] heights, int bottomLeftIndex, long bottomLeftHeight);

        public abstract void UpdateHeightsAfterComingToRest(ref HashSet<long>[] heights, int bottomLeftIndex, long bottomLeftHeight);

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
