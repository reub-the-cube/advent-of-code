using static aoc2022.day17.Enums;

namespace aoc2022.day17.domain
{
    public class Chamber
    {
        private int[] HeightsAtEachWidthIndex;
        private readonly HorizontalLine _horizontalLine = new();
        private readonly MirroredL _mirroredL = new();
        private readonly Plus _plus = new();
        private readonly Square _square = new();
        private readonly VerticalLine _verticalLine = new();

        public Chamber(int[] startingHeights)
        {
            HeightsAtEachWidthIndex = (int[])startingHeights.Clone();
        }

        public int GetHighestRock() => HeightsAtEachWidthIndex.Max();

        public int LetRockFall(Shape rock, int bottomLeftIndex, int bottomLeftHeight)
        {
            var isBlocked = rock.IsBlockedBelow(HeightsAtEachWidthIndex, bottomLeftIndex, bottomLeftHeight);

            return isBlocked ? bottomLeftHeight : bottomLeftHeight - 1;
        }

        public int[] PlaceRock(Shape rock, int indexOfBottomLeftPartOfShape, int heightOfBottomLeftPartOfShape)
        {
            rock.UpdateHeightsAfterComingToRest(ref HeightsAtEachWidthIndex, indexOfBottomLeftPartOfShape, heightOfBottomLeftPartOfShape);

            return HeightsAtEachWidthIndex;
        }

        public int PushRockLeft(Shape rock, int indexOfBottomLeftPartOfShape, int heightOfBottomLeftPartOfShape)
        {
            var isBlocked = rock.IsBlockedToTheLeft(HeightsAtEachWidthIndex, indexOfBottomLeftPartOfShape, heightOfBottomLeftPartOfShape);

            return isBlocked ? indexOfBottomLeftPartOfShape : indexOfBottomLeftPartOfShape - 1;
        }

        public int PushRockRight(Shape rock, int indexOfBottomLeftPartOfShape, int heightOfBottomLeftPartOfShape)
        {
            var isBlocked = rock.IsBlockedToTheRight(HeightsAtEachWidthIndex, indexOfBottomLeftPartOfShape, heightOfBottomLeftPartOfShape);

            return isBlocked ? indexOfBottomLeftPartOfShape : indexOfBottomLeftPartOfShape + 1;
        }
    }
}
