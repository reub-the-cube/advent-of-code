namespace aoc2022.day17.domain
{
    public class Square : Shape
    {
        public override bool IsBlockedBelow(int[] heights, int bottomLeftIndex, int bottomLeftHeight)
        {
            return (heights[bottomLeftIndex] == bottomLeftHeight - 1) ||
                (heights[bottomLeftIndex + 1] == bottomLeftHeight - 1);
        }

        public override bool IsBlockedToTheLeft(int[] heights, int bottomLeftIndex, int bottomLeftHeight)
        {
            return (bottomLeftIndex == 0) || (heights[bottomLeftIndex - 1] >= bottomLeftHeight);
        }

        public override bool IsBlockedToTheRight(int[] heights, int bottomLeftIndex, int bottomLeftHeight)
        {
            var rightWallIndex = heights.Length - 1;
            return (bottomLeftIndex >= rightWallIndex - 1) ||
                (heights[bottomLeftIndex + 2] >= bottomLeftHeight);
        }

        public override void UpdateHeightsAfterComingToRest(ref int[] heights, int bottomLeftIndex)
        {
            // ....
            // .**.
            // .**.
            // ....
            heights[bottomLeftIndex] += 2;
            heights[bottomLeftIndex + 1] += 2;
        }
    }
}
