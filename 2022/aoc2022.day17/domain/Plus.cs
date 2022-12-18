namespace aoc2022.day17.domain
{
    public class Plus : Shape
    {
        public override bool IsBlockedBelow(int[] heights, int bottomLeftIndex, int bottomLeftHeight)
        {
            return (heights[bottomLeftIndex] == bottomLeftHeight) ||
                (heights[bottomLeftIndex + 1] == bottomLeftHeight - 1) ||
                (heights[bottomLeftIndex + 2] == bottomLeftHeight);
        }

        public override bool IsBlockedToTheLeft(int[] heights, int bottomLeftIndex, int bottomLeftHeight)
        {
            if (bottomLeftIndex == 0) return true;

            var isBlockedOnMostLeft = heights[bottomLeftIndex - 1] >= bottomLeftHeight + 1;
            var isBlockedOnMostBottom = heights[bottomLeftIndex] >= bottomLeftHeight;
            return isBlockedOnMostLeft || isBlockedOnMostBottom;
        }

        public override bool IsBlockedToTheRight(int[] heights, int bottomLeftIndex, int bottomLeftHeight)
        {
            var rightWallIndex = heights.Length - 1;
            return (bottomLeftIndex >= rightWallIndex - 2) ||
                (heights[bottomLeftIndex + 3] >= bottomLeftHeight + 1) ||
                (heights[bottomLeftIndex + 2] >= bottomLeftHeight);
        }

        public override void UpdateHeightsAfterComingToRest(ref int[] heights, int bottomLeftIndex, int bottomLeftHeight)
        {
            // .....
            // ..*..
            // .***.
            // ..*..
            // .....
            heights[bottomLeftIndex] = bottomLeftHeight + 1;
            heights[bottomLeftIndex + 1] = bottomLeftHeight + 2;
            heights[bottomLeftIndex + 2] = bottomLeftHeight + 1;
        }
    }
}
