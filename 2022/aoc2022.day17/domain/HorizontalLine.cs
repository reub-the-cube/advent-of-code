namespace aoc2022.day17.domain
{
    public class HorizontalLine : Shape
    {
        public override bool IsBlockedBelow(HashSet<long>[] heights, int bottomLeftIndex, long bottomLeftHeight)
        {
            var isBlockedBelow = heights[bottomLeftIndex].Contains(bottomLeftHeight - 1) ||
                                 heights[bottomLeftIndex + 1].Contains(bottomLeftHeight - 1) ||
                                 heights[bottomLeftIndex + 2].Contains(bottomLeftHeight - 1) ||
                                 heights[bottomLeftIndex + 3].Contains(bottomLeftHeight - 1);

            if (isBlockedBelow) HasComeToRest = true;
            return isBlockedBelow;
        }

        public override bool IsBlockedToTheLeft(HashSet<long>[] heights, int bottomLeftIndex, long bottomLeftHeight)
        {
            return bottomLeftIndex == 0 || 
                   heights[bottomLeftIndex - 1].Contains(bottomLeftHeight);
        }

        public override bool IsBlockedToTheRight(HashSet<long>[] heights, int bottomLeftIndex, long bottomLeftHeight)
        {
            var rightWallIndex = heights.Length - 1;
            return bottomLeftIndex == rightWallIndex - 3 ||
                   heights[bottomLeftIndex + 4].Contains(bottomLeftHeight);
        }

        public override void UpdateHeightsAfterComingToRest(ref HashSet<long>[] heights, int bottomLeftIndex, long bottomLeftHeight)
        {            
            // ......
            // .****.
            // ......
            heights[bottomLeftIndex].Add(bottomLeftHeight);
            heights[bottomLeftIndex + 1].Add(bottomLeftHeight);
            heights[bottomLeftIndex + 2].Add(bottomLeftHeight);
            heights[bottomLeftIndex + 3].Add(bottomLeftHeight);
        }
    }
}
