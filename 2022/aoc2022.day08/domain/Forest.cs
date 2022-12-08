namespace aoc2022.day08.domain
{
    public readonly record struct Forest(Tree[,] Trees)
    {
        public int GetCountOfVisibleTrees()
        {
            var visibleCount = 0;
            for (var i = 0; i < Trees.GetLength(0); i++)
            {
                for (var j = 0; j < Trees.GetLength(1); j++)
                {
                    var treeIsVisible = Trees[i, j].IsVisible;
                    if (treeIsVisible) visibleCount++;
                }
            }

            return visibleCount;
        }

        public int GetMaximumScenicScore()
        {
            var maxScenicScore = 0;
            for (var i = 0; i < Trees.GetLength(0); i++)
            {
                for (var j = 0; j < Trees.GetLength(1); j++)
                {
                    var scenicScore = Trees[i, j].ScenicScore();
                    maxScenicScore = Math.Max(maxScenicScore, scenicScore);
                }
            }

            return maxScenicScore;
        }
    }

    public record Tree(int Height, int[] HeightsToTheNorth, int[] HeightsToTheEast, int[] HeightsToTheSouth, int[] HeightsToTheWest)
    {
        public bool IsVisible => IsVisibleFromTheNorth() || IsVisibleFromTheEast() || IsVisibleFromTheSouth() || IsVisibleFromTheWest();
        public int ScenicScore() => ViewableTreesToTheNorth() * ViewableTreesToTheEast() * ViewableTreesToTheSouth() * ViewableTreesToTheWest();

        private bool IsVisibleFromTheNorth() => IsVisibleFromDirection(HeightsToTheNorth);
        private bool IsVisibleFromTheEast() => IsVisibleFromDirection(HeightsToTheEast);
        private bool IsVisibleFromTheSouth() => IsVisibleFromDirection(HeightsToTheSouth);
        private bool IsVisibleFromTheWest() => IsVisibleFromDirection(HeightsToTheWest);

        private bool IsVisibleFromDirection(int[] heightsToCompare)
        {
            return heightsToCompare.All(h => h < Height);
        }

        private int ViewableTreesToTheNorth() => GetViewableTrees(HeightsToTheNorth, false);
        private int ViewableTreesToTheEast() => GetViewableTrees(HeightsToTheEast, true);
        private int ViewableTreesToTheSouth() => GetViewableTrees(HeightsToTheSouth, true);
        private int ViewableTreesToTheWest() => GetViewableTrees(HeightsToTheWest, false);

        private int GetViewableTrees(int[] heightsToCompare, bool countFromStart)
        {
            int visibleTrees = 0;
            if (countFromStart)
            {
                for (int i = 0; i < heightsToCompare.Length; i++)
                {
                    visibleTrees++;
                    if (Height <= heightsToCompare[i]) break;
                }
            }
            else
            {
                for (int i = heightsToCompare.Length - 1; i > -1; i--)
                {
                    visibleTrees++;
                    if (Height <= heightsToCompare[i]) break;
                }
            }

            return visibleTrees;
        }
    }
}