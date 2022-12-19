using static aoc2022.day17.Enums;

namespace aoc2022.day17.domain
{
    public class Chamber
    {
        private int[] HeightsAtEachWidthIndex;
        private HashSet<int>[] BlockedHeightsAtEachWidthIndex;

        public Chamber(int[] startingHeights)
        {
            HeightsAtEachWidthIndex = (int[])startingHeights.Clone();
            BlockedHeightsAtEachWidthIndex = HeightsAtEachWidthIndex
                .Select(h => Enumerable.Range(0, h + 1).ToHashSet())
                .ToArray();
        }

        public int GetHighestRock() => HeightsAtEachWidthIndex.Max();

        public int LetRockFall(Shape rock, int bottomLeftIndex, int bottomLeftHeight)
        {
            var isBlocked = rock.IsBlockedBelow(BlockedHeightsAtEachWidthIndex, bottomLeftIndex, bottomLeftHeight);

            return isBlocked ? bottomLeftHeight : bottomLeftHeight - 1;
        }

        public int[] PlaceRock(Shape rock, int indexOfBottomLeftPartOfShape, int heightOfBottomLeftPartOfShape)
        {
            rock.UpdateHeightsAfterComingToRest(ref BlockedHeightsAtEachWidthIndex, indexOfBottomLeftPartOfShape, heightOfBottomLeftPartOfShape);

            HeightsAtEachWidthIndex = BlockedHeightsAtEachWidthIndex.Select(h => h.DefaultIfEmpty(0).Max()).ToArray();

            RemoveImpossibleHeights();
            
            return HeightsAtEachWidthIndex;
        }

        public int PushRockLeft(Shape rock, int indexOfBottomLeftPartOfShape, int heightOfBottomLeftPartOfShape)
        {
            var isBlocked = rock.IsBlockedToTheLeft(BlockedHeightsAtEachWidthIndex, indexOfBottomLeftPartOfShape, heightOfBottomLeftPartOfShape);

            return isBlocked ? indexOfBottomLeftPartOfShape : indexOfBottomLeftPartOfShape - 1;
        }

        public int PushRockRight(Shape rock, int indexOfBottomLeftPartOfShape, int heightOfBottomLeftPartOfShape)
        {
            var isBlocked = rock.IsBlockedToTheRight(BlockedHeightsAtEachWidthIndex, indexOfBottomLeftPartOfShape, heightOfBottomLeftPartOfShape);

            return isBlocked ? indexOfBottomLeftPartOfShape : indexOfBottomLeftPartOfShape + 1;
        }

        private void RemoveImpossibleHeights()
        {
            var minHeight = BlockedHeightsAtEachWidthIndex.Select(h => h.DefaultIfEmpty(0).Min()).Min();
            Array.ForEach(BlockedHeightsAtEachWidthIndex, b => b.RemoveWhere(h => h < minHeight));
        }
    }
}
