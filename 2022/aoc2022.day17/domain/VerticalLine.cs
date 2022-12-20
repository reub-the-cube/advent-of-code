namespace aoc2022.day17.domain
{
    public class VerticalLine : Shape
    {
        public override bool IsBlockedBelow(HashSet<long>[] heights, int bottomLeftIndex, long bottomLeftHeight)
        {
            return heights[bottomLeftIndex].Contains(bottomLeftHeight - 1);
        }

        public override bool IsBlockedToTheLeft(HashSet<long>[] heights, int bottomLeftIndex, long bottomLeftHeight)
        {
            // return bottomLeftIndex == 0 || 
            //        heights[bottomLeftIndex - 1].Overlaps(Enumerable.Range(bottomLeftHeight, 4));
            return bottomLeftIndex == 0 || 
                   heights[bottomLeftIndex - 1].Contains(bottomLeftHeight) ||
                   heights[bottomLeftIndex - 1].Contains(bottomLeftHeight + 1) ||
                   heights[bottomLeftIndex - 1].Contains(bottomLeftHeight + 2) ||
                   heights[bottomLeftIndex - 1].Contains(bottomLeftHeight + 3);
        }

        public override bool IsBlockedToTheRight(HashSet<long>[] heights, int bottomLeftIndex, long bottomLeftHeight)
        {
            var rightWallIndex = heights.Length - 1;
            // return bottomLeftIndex == rightWallIndex ||
            //        heights[bottomLeftIndex + 1].Overlaps(Enumerable.Range(bottomLeftHeight, 4));
            return bottomLeftIndex == rightWallIndex ||
                   heights[bottomLeftIndex + 1].Contains(bottomLeftHeight) ||
                   heights[bottomLeftIndex + 1].Contains(bottomLeftHeight + 1) ||
                   heights[bottomLeftIndex + 1].Contains(bottomLeftHeight + 2) ||
                   heights[bottomLeftIndex + 1].Contains(bottomLeftHeight + 3);
        }

        public override void UpdateHeightsAfterComingToRest(ref HashSet<long>[] heights, int bottomLeftIndex, long bottomLeftHeight)
        {
            // ...
            // .*.
            // .*.
            // .*.
            // .*.
            // ...
            heights[bottomLeftIndex].Add(bottomLeftHeight);
            heights[bottomLeftIndex].Add(bottomLeftHeight + 1);
            heights[bottomLeftIndex].Add(bottomLeftHeight + 2);
            heights[bottomLeftIndex].Add(bottomLeftHeight + 3);
        }
    }
}
