using aoc2022.day17.domain;
using FluentAssertions;
using static aoc2022.day17.Enums;

namespace aoc2022.day17.tests
{
    public class ChamberTests
    {
        [InlineData(RockShape.HorizontalLine, 0, new[] { 1, 1, 1, 1, 0, 0, 0 })]
        [InlineData(RockShape.HorizontalLine, 1, new[] { 0, 1, 1, 1, 1, 0, 0 })]
        [InlineData(RockShape.HorizontalLine, 2, new[] { 0, 0, 1, 1, 1, 1, 0 })]
        [InlineData(RockShape.HorizontalLine, 3, new[] { 0, 0, 0, 1, 1, 1, 1 })]
        [InlineData(RockShape.VerticalLine, 0, new[] { 4, 0, 0, 0, 0, 0, 0 })]
        [InlineData(RockShape.VerticalLine, 6, new[] { 0, 0, 0, 0, 0, 0, 4 })]
        [InlineData(RockShape.Plus, 0, new[] { 2, 3, 2, 0, 0, 0, 0 })]
        [InlineData(RockShape.Plus, 4, new[] { 0, 0, 0, 0, 2, 3, 2 })]
        [InlineData(RockShape.Square, 0, new[] { 2, 2, 0, 0, 0, 0, 0 })]
        [InlineData(RockShape.Square, 5, new[] { 0, 0, 0, 0, 0, 2, 2 })]
        [InlineData(RockShape.MirroredL, 0, new[] { 1, 1, 3, 0, 0, 0, 0 })]
        [InlineData(RockShape.MirroredL, 4, new[] { 0, 0, 0, 0, 1, 1, 3 })]
        [Theory]
        public void PlacingFirstRockInChamberUpdatesHighestPointsForWholeChamber(RockShape rockShape, int indexOfBottomLeftPosition, int[] expectedHeights)
        {
            var startingHeights = Enumerable.Repeat(0, expectedHeights.Length).ToArray();
            var chamber = new Chamber(startingHeights);
            var rock = MakeShapeTypeFromRockShapeEnum(rockShape);

            var actualHeights = chamber.PlaceRock(rock, indexOfBottomLeftPosition, 1);

            actualHeights.Should().HaveCount(expectedHeights.Length);
            actualHeights.Should().BeEquivalentTo(expectedHeights);
        }

        [InlineData(RockShape.HorizontalLine, 1)]
        [InlineData(RockShape.HorizontalLine, 3)]
        [InlineData(RockShape.VerticalLine, 1)]
        [InlineData(RockShape.VerticalLine, 7)]
        [InlineData(RockShape.Plus, 1)]
        [InlineData(RockShape.Plus, 4)]
        [InlineData(RockShape.Square, 1)]
        [InlineData(RockShape.Square, 5)]
        [InlineData(RockShape.MirroredL, 1)]
        [InlineData(RockShape.MirroredL, 4)]
        [Theory]
        public void PushingRockLeftUpdatesBottomLeftPositionIfNotObstructed(RockShape rockShape, int indexOfBottomLeftPositionBeforePush)
        {
            var startingHeights = Enumerable.Repeat(0, 7).ToArray();
            var chamber = new Chamber(startingHeights);
            Shape rock = MakeShapeTypeFromRockShapeEnum(rockShape);

            var indexOfBottomLeftPosition = chamber.PushRockLeft(rock, indexOfBottomLeftPositionBeforePush, 1);

            indexOfBottomLeftPosition.Should().Be(indexOfBottomLeftPositionBeforePush - 1);
        }

        [InlineData(RockShape.HorizontalLine)]
        [InlineData(RockShape.VerticalLine)]
        [InlineData(RockShape.Plus)]
        [InlineData(RockShape.Square)]
        [InlineData(RockShape.MirroredL)]
        [Theory]
        public void PushingRockLeftRetainsBottomLeftPositionIfAgainstLeftWall(RockShape rockShape)
        {
            var startingHeights = Enumerable.Repeat(0, 7).ToArray();
            var chamber = new Chamber(startingHeights);
            Shape rock = MakeShapeTypeFromRockShapeEnum(rockShape);

            var indexOfBottomLeftPosition = chamber.PushRockLeft(rock, 0, 1);

            indexOfBottomLeftPosition.Should().Be(0);
        }

        [InlineData(RockShape.HorizontalLine, 1, 5, new[] { 5, 0, 0, 0, 0, 0, 0 })]
        [InlineData(RockShape.HorizontalLine, 3, 5, new[] { 5, 1, 7, 0, 0, 4, 9 })]
        [InlineData(RockShape.VerticalLine, 1, 5, new[] { 5, 0, 0, 0, 0, 0, 0 })]
        [InlineData(RockShape.VerticalLine, 6, 5, new[] { 4, 4, 4, 15, 0, 5, 0 })]
        [InlineData(RockShape.Plus, 1, 5, new[] { 6, 0, 0, 0, 0, 0, 0 })]
        [InlineData(RockShape.Plus, 1, 5, new[] { 2, 5, 0, 0, 2, 2, 4 })]
        [InlineData(RockShape.Square, 1, 5, new[] { 5, 4, 0, 0, 0, 0, 0})]
        [InlineData(RockShape.MirroredL, 1, 5, new[] { 5, 3, 3, 4, 8, 2})]
        [Theory]
        public void PushingRockLeftRetainsBottomLeftPositionIfObstructed(RockShape rockShape, int indexOfBottomLeftPositionBeforePush, int heightOfBottomLeftPositionBeforePush, int[] activeHeights)
        {
            var chamber = new Chamber(activeHeights);
            Shape rock = MakeShapeTypeFromRockShapeEnum(rockShape);

            var indexOfBottomLeftPosition = chamber.PushRockLeft(rock, indexOfBottomLeftPositionBeforePush, heightOfBottomLeftPositionBeforePush);

            indexOfBottomLeftPosition.Should().Be(indexOfBottomLeftPositionBeforePush);
        }

        [InlineData(RockShape.HorizontalLine, 2)]
        [InlineData(RockShape.VerticalLine, 5)]
        [InlineData(RockShape.Plus, 3)]
        [InlineData(RockShape.Square, 4)]
        [InlineData(RockShape.MirroredL, 3)]
        [Theory]
        public void PushingRockRightUpdatesBottomLeftPositionIfNotObstructed(RockShape rockShape, int indexOfBottomLeftPositionBeforePush)
        {
            var startingHeights = Enumerable.Repeat(0, 7).ToArray();
            var chamber = new Chamber(startingHeights);
            Shape rock = MakeShapeTypeFromRockShapeEnum(rockShape);

            var indexOfBottomLeftPosition = chamber.PushRockRight(rock, indexOfBottomLeftPositionBeforePush, 1);

            indexOfBottomLeftPosition.Should().Be(indexOfBottomLeftPositionBeforePush + 1);
        }

        [InlineData(RockShape.HorizontalLine, 3)]
        [InlineData(RockShape.VerticalLine, 6)]
        [InlineData(RockShape.Plus, 5)]
        [InlineData(RockShape.Square, 5)]
        [InlineData(RockShape.MirroredL, 4)]
        [Theory]
        public void PushingRockRightRetainsBottomLeftPositionIfAgainstRightWall(RockShape rockShape, int indexOfBottomLeftPositionBeforePush)
        {
            var startingHeights = Enumerable.Repeat(0, 7).ToArray();
            var chamber = new Chamber(startingHeights);
            Shape rock = MakeShapeTypeFromRockShapeEnum(rockShape);

            var indexOfBottomLeftPosition = chamber.PushRockRight(rock, indexOfBottomLeftPositionBeforePush, 1);

            indexOfBottomLeftPosition.Should().Be(indexOfBottomLeftPositionBeforePush);
        }

        [InlineData(RockShape.HorizontalLine, 1, 5, new[] { 0, 0, 0, 0, 0, 5, 0 })]
        [InlineData(RockShape.HorizontalLine, 2, 5, new[] { 8, 1, 4, 4, 4, 4, 5 })]
        [InlineData(RockShape.VerticalLine, 0, 5, new[] { 0, 5, 0, 0, 0, 0, 0 })]
        [InlineData(RockShape.VerticalLine, 5, 5, new[] { 4, 4, 4, 4, 4, 4, 5 })]
        [InlineData(RockShape.Plus, 1, 5, new[] { 0, 0, 0, 0, 6, 0, 0 })]
        [InlineData(RockShape.Plus, 1, 5, new[] { 0, 0, 0, 5, 2, 2, 4 })]
        [InlineData(RockShape.Square, 0, 5, new[] { 4, 0, 5, 4, 4, 4, 0 })]
        [InlineData(RockShape.MirroredL, 2, 5, new[] { 7, 3, 3, 4, 2, 5 })]
        [Theory]
        public void PushingRockRightRetainsBottomLeftPositionIfObstructed(RockShape rockShape, int indexOfBottomLeftPositionBeforePush, int heightOfBottomLeftPositionBeforePush, int[] activeHeights)
        {
            var chamber = new Chamber(activeHeights);
            Shape rock = MakeShapeTypeFromRockShapeEnum(rockShape);

            var indexOfBottomLeftPosition = chamber.PushRockRight(rock, indexOfBottomLeftPositionBeforePush, heightOfBottomLeftPositionBeforePush);

            indexOfBottomLeftPosition.Should().Be(indexOfBottomLeftPositionBeforePush);
        }

        [Theory]
        [InlineData(RockShape.HorizontalLine, 1, 2, new[] { 1, 0, 0, 0, 0, 0, 0 })]
        [InlineData(RockShape.HorizontalLine, 1, 2, new[] { 1, 0, 0, 0, 0, 1, 0 })]
        [InlineData(RockShape.VerticalLine, 1, 2, new[] { 1, 0, 0, 2, 0, 0, 0 })]
        [InlineData(RockShape.VerticalLine, 1, 2, new[] { 1, 0, 1, 0, 0, 1, 0 })]
        [InlineData(RockShape.Plus, 1, 2, new[] { 0, 1, 0, 0, 0, 0, 0 })]
        [InlineData(RockShape.Plus, 1, 2, new[] { 0, 0, 0, 1, 0, 0, 0 })]
        [InlineData(RockShape.Square, 1, 2, new[] { 0, 0, 0, 1, 0, 0, 0 })]
        [InlineData(RockShape.MirroredL, 1, 2, new[] { 0, 0, 0, 0, 1, 0, 0 })]
        [InlineData(RockShape.MirroredL, 1, 2, new[] { 1, 0, 0, 0, 1, 0, 0 })]
        public void LettingRockFallUpdatesBottomLeftPositionIfNotObstructed(RockShape rockShape, int indexOfBottomLeftPositionBeforeDrop, int heightOfBottomLeftPositionBeforeDrop, int[] activeHeights)
        {
            // Dropping from height 2 is possible if won't collide with a floor on height 1. i.e. a gap of two is required to drop
            var chamber = new Chamber(activeHeights);
            Shape rock = MakeShapeTypeFromRockShapeEnum(rockShape);

            var heightOfBottomLeftPosition = chamber.LetRockFall(rock, indexOfBottomLeftPositionBeforeDrop, heightOfBottomLeftPositionBeforeDrop);

            heightOfBottomLeftPosition.Should().Be(heightOfBottomLeftPositionBeforeDrop - 1);
        }

        [Theory]
        [InlineData(RockShape.HorizontalLine, 1, 2, new[] { 0, 1, 0, 0, 0, 0, 0 })]
        [InlineData(RockShape.HorizontalLine, 1, 2, new[] { 0, 0, 1, 0, 0, 0, 0 })]
        [InlineData(RockShape.HorizontalLine, 1, 2, new[] { 0, 0, 0, 1, 0, 0, 0 })]
        [InlineData(RockShape.HorizontalLine, 1, 2, new[] { 0, 0, 0, 0, 1, 0, 0 })]
        [InlineData(RockShape.VerticalLine, 1, 2, new[] { 0, 1, 0, 0, 0, 0, 0 })]
        [InlineData(RockShape.Plus, 1, 2, new[] { 0, 2, 0, 0, 0, 0, 0 })]
        [InlineData(RockShape.Plus, 1, 2, new[] { 0, 0, 1, 0, 0, 0, 0 })]
        [InlineData(RockShape.Plus, 1, 2, new[] { 0, 0, 0, 2, 0, 0, 0 })]
        [InlineData(RockShape.Square, 1, 2, new[] { 1, 1, 0, 0, 0, 0, 0 })]
        [InlineData(RockShape.Square, 1, 2, new[] { 0, 0, 1, 1, 0, 0, 0 })]
        [InlineData(RockShape.MirroredL, 1, 2, new[] { 1, 1, 0, 0, 1, 0, 0 })]
        [InlineData(RockShape.MirroredL, 1, 2, new[] { 1, 0, 1, 0, 1, 0, 0 })]
        [InlineData(RockShape.MirroredL, 1, 2, new[] { 1, 0, 0, 1, 1, 0, 0 })]
        public void LettingRockFallUpdatesBottomLeftPositionIfTouchingTheFloor(RockShape rockShape, int indexOfBottomLeftPositionBeforeDrop, int heightOfBottomLeftPositionBeforeDrop, int[] activeHeights)
        {
            var chamber = new Chamber(activeHeights);
            Shape rock = MakeShapeTypeFromRockShapeEnum(rockShape);

            var heightOfBottomLeftPosition = chamber.LetRockFall(rock, indexOfBottomLeftPositionBeforeDrop, heightOfBottomLeftPositionBeforeDrop);

            heightOfBottomLeftPosition.Should().Be(heightOfBottomLeftPositionBeforeDrop);
        }

        private static Shape MakeShapeTypeFromRockShapeEnum(RockShape rockShape)
        {
            return rockShape switch
            {
                RockShape.HorizontalLine => new HorizontalLine(),
                RockShape.VerticalLine => new VerticalLine(),
                RockShape.Plus => new Plus(),
                RockShape.Square => new Square(),
                RockShape.MirroredL => new MirroredL(),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
