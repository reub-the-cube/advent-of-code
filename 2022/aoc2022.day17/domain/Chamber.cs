using static aoc2022.day17.Enums;

namespace aoc2022.day17.domain
{
    public class Chamber
    {
        public long NumberOfRocksDropped { get; private set; }
        private long[] HeightsAtEachWidthIndex;
        private HashSet<long>[] BlockedHeightsAtEachWidthIndex;

        public Chamber(int[] startingHeights)
        {
            HeightsAtEachWidthIndex = startingHeights.Select(h => (long)h).ToArray();
            BlockedHeightsAtEachWidthIndex = HeightsAtEachWidthIndex
                .Select(h => Enumerable.Range(0, (int)h + 1).Select(i => (long)i).ToHashSet())
                .ToArray();
        }

        public void BumpBlockedHeights(long bump, long numberOfRocks)
        {
            BlockedHeightsAtEachWidthIndex = BlockedHeightsAtEachWidthIndex
                .Select(b => b.Select(h => h + bump).ToHashSet()).ToArray();
            
            HeightsAtEachWidthIndex = BlockedHeightsAtEachWidthIndex.Select(h => h.DefaultIfEmpty(0).Max()).ToArray();

            NumberOfRocksDropped += numberOfRocks;
        }

        public long GetHighestRock() => HeightsAtEachWidthIndex.Max();

        public string GetProfileForTopOfChamber()
        {
            var lookbackDepth = 200;
            var highestRock = GetHighestRock();

            var recentHeights = BlockedHeightsAtEachWidthIndex
                .Select(b =>
                    b.Where(h => h >= highestRock - lookbackDepth).Select(h => h % lookbackDepth)
                ).Select(b => string.Join(string.Empty, b));
            
            return string.Join('|', recentHeights);
        }
        
        public string GetProfileForHeights()
        {
            var minHeight = HeightsAtEachWidthIndex.Min();
            var heightDeltas = HeightsAtEachWidthIndex.Select(h => (h - minHeight).ToString());
            return string.Join('|', heightDeltas);
        }

        public long LetRockFall(Shape rock, int bottomLeftIndex, long bottomLeftHeight)
        {
            var isBlocked = rock.IsBlockedBelow(BlockedHeightsAtEachWidthIndex, bottomLeftIndex, bottomLeftHeight);

            return isBlocked ? bottomLeftHeight : bottomLeftHeight - 1;
        }

        public long[] PlaceRock(Shape rock, int indexOfBottomLeftPartOfShape, long heightOfBottomLeftPartOfShape)
        {
            rock.UpdateHeightsAfterComingToRest(ref BlockedHeightsAtEachWidthIndex, indexOfBottomLeftPartOfShape, heightOfBottomLeftPartOfShape);
            NumberOfRocksDropped++;

            HeightsAtEachWidthIndex = BlockedHeightsAtEachWidthIndex.Select(h => h.DefaultIfEmpty(0).Max()).ToArray();
            
            return HeightsAtEachWidthIndex;
        }

        public int PushRockLeft(Shape rock, int indexOfBottomLeftPartOfShape, long heightOfBottomLeftPartOfShape)
        {
            var isBlocked = rock.IsBlockedToTheLeft(BlockedHeightsAtEachWidthIndex, indexOfBottomLeftPartOfShape, heightOfBottomLeftPartOfShape);

            return isBlocked ? indexOfBottomLeftPartOfShape : indexOfBottomLeftPartOfShape - 1;
        }

        public int PushRockRight(Shape rock, int indexOfBottomLeftPartOfShape, long heightOfBottomLeftPartOfShape)
        {
            var isBlocked = rock.IsBlockedToTheRight(BlockedHeightsAtEachWidthIndex, indexOfBottomLeftPartOfShape, heightOfBottomLeftPartOfShape);

            return isBlocked ? indexOfBottomLeftPartOfShape : indexOfBottomLeftPartOfShape + 1;
        }

        public bool RockFormationIsRepeated(long highestRock, int heightDelta)
        {
            var isRepeated = true;
            for (var i = highestRock; i < highestRock - heightDelta; i--)
            {
                isRepeated = BlockedHeightsAtEachWidthIndex.All(t =>
                {
                    var bothHeightsAreBlocked = t.Contains(i) &&
                                                t.Contains(i - heightDelta);
                    var bothHeightsAreNotBlocked = t.Contains(i) &&
                                                   t.Contains(i - heightDelta);
                    return bothHeightsAreBlocked || bothHeightsAreNotBlocked;
                });

                if (!isRepeated) break;
            }

            return isRepeated;
        }
    }
}
