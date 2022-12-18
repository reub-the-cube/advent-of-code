namespace aoc2022.day17.domain
{
    public abstract class Shape
    {
        public Shape() { }

        public abstract bool IsBlockedBelow(int[] heights, int bottomLeftIndex, int bottomLeftHeight);

        public abstract bool IsBlockedToTheLeft(int[] heights, int bottomLeftIndex, int bottomLeftHeight);

        public abstract bool IsBlockedToTheRight(int[] heights, int bottomLeftIndex, int bottomLeftHeight);

        public abstract void UpdateHeightsAfterComingToRest(ref int[] heights, int bottomLeftIndex);
    }
}
