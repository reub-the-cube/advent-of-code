namespace aoc2022.day17.domain
{
    public class Plus : Shape
    {
        public override bool IsBlockedBelow(HashSet<int>[] heights, int bottomLeftIndex, int bottomLeftHeight)
        {
            return heights[bottomLeftIndex].Contains(bottomLeftHeight) ||
                   heights[bottomLeftIndex + 1].Contains(bottomLeftHeight - 1) ||
                   heights[bottomLeftIndex + 2].Contains(bottomLeftHeight);
        }

        public override bool IsBlockedToTheLeft(HashSet<int>[] heights, int bottomLeftIndex, int bottomLeftHeight)
        {
            return bottomLeftIndex == 0 ||
                   heights[bottomLeftIndex].Contains(bottomLeftHeight) ||
                   heights[bottomLeftIndex].Contains(bottomLeftHeight + 2) ||
                   heights[bottomLeftIndex - 1].Contains(bottomLeftHeight + 1);
        }

        public override bool IsBlockedToTheRight(HashSet<int>[] heights, int bottomLeftIndex, int bottomLeftHeight)
        {
            var rightWallIndex = heights.Length - 1;
            return bottomLeftIndex == rightWallIndex - 2 ||
                   heights[bottomLeftIndex + 2].Contains(bottomLeftHeight) ||
                   heights[bottomLeftIndex + 2].Contains(bottomLeftHeight + 2) ||
                   heights[bottomLeftIndex + 3].Contains(bottomLeftHeight + 1);
        }

        public override void UpdateHeightsAfterComingToRest(ref HashSet<int>[] heights, int bottomLeftIndex, int bottomLeftHeight)
        {
            // .....
            // ..*..
            // .***.
            // ..*..
            // .....
            heights[bottomLeftIndex].Add(bottomLeftHeight + 1);
            heights[bottomLeftIndex + 1].Add(bottomLeftHeight);
            heights[bottomLeftIndex + 1].Add(bottomLeftHeight + 1);
            heights[bottomLeftIndex + 1].Add(bottomLeftHeight + 2);
            heights[bottomLeftIndex + 2].Add(bottomLeftHeight + 1);
        }
    }
}
