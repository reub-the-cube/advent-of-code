namespace aoc2022.day17.domain
{
    public class VerticalLine : Shape
    {
        public override bool IsBlockedBelow(int[] heights, int bottomLeftIndex, int bottomLeftHeight)
        {
            return (heights[bottomLeftIndex] == bottomLeftHeight - 1);
        }

        public override bool IsBlockedToTheLeft(int[] heights, int bottomLeftIndex, int bottomLeftHeight)
        {
            return (bottomLeftIndex == 0) || (heights[bottomLeftIndex - 1] >= bottomLeftHeight);
        }

        public override bool IsBlockedToTheRight(int[] heights, int bottomLeftIndex, int bottomLeftHeight)
        {
            var rightWallIndex = heights.Length - 1;
            return (bottomLeftIndex >= rightWallIndex) ||
                (heights[bottomLeftIndex + 1] >= bottomLeftHeight);
        }

        public override void UpdateHeightsAfterComingToRest(ref int[] heights, int bottomLeftIndex, int bottomLeftHeight)
        {
            // ...
            // .*.
            // .*.
            // .*.
            // .*.
            // ...
            heights[bottomLeftIndex] = bottomLeftHeight + 3;
        }
    }
}
