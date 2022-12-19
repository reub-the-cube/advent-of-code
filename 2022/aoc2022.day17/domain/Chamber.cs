using static aoc2022.day17.Enums;

namespace aoc2022.day17.domain
{
    public class Chamber
    {
        public int NumberOfRocksDropped { get; private set; }
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

        public string GetHeightProfile()
        {
            var minHeight = HeightsAtEachWidthIndex.Min();
            var heightDeltas = HeightsAtEachWidthIndex.Select(h => (h - minHeight).ToString());
            return string.Join('|', heightDeltas);
        }

        public int[] GetHeights()
        {
            return HeightsAtEachWidthIndex;
        }

        public int LetRockFall(Shape rock, int bottomLeftIndex, int bottomLeftHeight)
        {
            var isBlocked = rock.IsBlockedBelow(BlockedHeightsAtEachWidthIndex, bottomLeftIndex, bottomLeftHeight);

            return isBlocked ? bottomLeftHeight : bottomLeftHeight - 1;
        }

        public int[] PlaceRock(Shape rock, int indexOfBottomLeftPartOfShape, int heightOfBottomLeftPartOfShape)
        {
            rock.UpdateHeightsAfterComingToRest(ref BlockedHeightsAtEachWidthIndex, indexOfBottomLeftPartOfShape, heightOfBottomLeftPartOfShape);
            NumberOfRocksDropped++;

            HeightsAtEachWidthIndex = BlockedHeightsAtEachWidthIndex.Select(h => h.DefaultIfEmpty(0).Max()).ToArray();
            
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
    }
}
