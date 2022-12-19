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
            var rock = Shape.MakeShape(rockShape);

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
            var rock = Shape.MakeShape(rockShape);

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
            var rock = Shape.MakeShape(rockShape);

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
            var rock = Shape.MakeShape(rockShape);

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
            var rock = Shape.MakeShape(rockShape);

            var indexOfBottomLeftPosition = chamber.PushRockRight(rock, indexOfBottomLeftPositionBeforePush, 1);

            indexOfBottomLeftPosition.Should().Be(indexOfBottomLeftPositionBeforePush + 1);
        }

        [InlineData(RockShape.HorizontalLine, 3)]
        [InlineData(RockShape.VerticalLine, 6)]
        [InlineData(RockShape.Plus, 4)]
        [InlineData(RockShape.Square, 5)]
        [InlineData(RockShape.MirroredL, 4)]
        [Theory]
        public void PushingRockRightRetainsBottomLeftPositionIfAgainstRightWall(RockShape rockShape, int indexOfBottomLeftPositionBeforePush)
        {
            var startingHeights = Enumerable.Repeat(0, 7).ToArray();
            var chamber = new Chamber(startingHeights);
            var rock = Shape.MakeShape(rockShape);

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
            // . . . . . . .
            // . . P . . . .
            // . P P P # . .
            // . . P . # . .
            // . . . . # . .
            // . . . . # . .
            // . . . . # . .
            // . . . . # . .
            // F F F F F F F
            var chamber = new Chamber(activeHeights);
            var rock = Shape.MakeShape(rockShape);

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
            var rock = Shape.MakeShape(rockShape);

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
            var rock = Shape.MakeShape(rockShape);

            var heightOfBottomLeftPosition = chamber.LetRockFall(rock, indexOfBottomLeftPositionBeforeDrop, heightOfBottomLeftPositionBeforeDrop);

            heightOfBottomLeftPosition.Should().Be(heightOfBottomLeftPositionBeforeDrop);
        }
        
        [Fact]
        public void SquareRockCanMoveRightUnderMaxHeightForWidthIndex()
        {
            //  9   . . . . . . .   ---->   . . . . . . .
            //  8   . . V . . . .   ---->   . . V . . . .
            //  7   . . V . . . .   ---->   . . V . . . .
            //  6   . . V . L . .   ---->   . . V . L . .
            //  5   . . V . L . .   ---->   . . V . L . .
            //  4   . . L L L P .   ---->   . . L L L P .
            //  3   S S . . P P P   ---->   . S S . P P P
            //  2   S S . . . P .   ---->   . S S . . P .
            //  1   . . H H H H .   ---->   . . H H H H .
            //  0   F F F F F F F   ---->   F F F F F F F
            var finishingHeights = new[] {0, 3, 8, 4, 6, 4, 3};
            var chamber = new Chamber(Enumerable.Repeat(0, 7).ToArray());
            var rock = Shape.MakeShape(RockShape.Square);
            
            // Setup chamber
            _ = chamber.PlaceRock(Shape.MakeShape(RockShape.HorizontalLine), 2, 1);
            _ = chamber.PlaceRock(Shape.MakeShape(RockShape.Plus), 4, 2);
            _ = chamber.PlaceRock(Shape.MakeShape(RockShape.MirroredL), 2, 4);
            _ = chamber.PlaceRock(Shape.MakeShape(RockShape.VerticalLine), 2, 5);
            
            var bottomLeftPosition = 0;
            var bottomLeftHeight = 2;

            bottomLeftPosition = chamber.PushRockRight(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftHeight = chamber.LetRockFall(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftPosition.Should().Be(1);
            bottomLeftHeight.Should().Be(2);

            var heights = chamber.PlaceRock(rock, bottomLeftPosition, bottomLeftHeight);
            heights.Should().HaveCount(finishingHeights.Length);
            heights.Should().BeEquivalentTo(finishingHeights);
        }
        
        [Fact]
        public void SquareRockCanMoveLeftUnderMaxHeightForWidthIndex()
        {
            //  9   . . . . . . .   ---->   . . . . . . .
            //  8   . . . . . . .   ---->   . . . . . . .
            //  7   . . . . . . .   ---->   . . . . . . .
            //  6   . . . L . . .   ---->   . . . L . . .
            //  5   . . . L . . .   ---->   . . . L . . .
            //  4   . L L L . . .   ---->   . L L L . . .
            //  3   . P . . S S .   ---->   . P . S S . .
            //  2   P P P . S S .   ---->   P P P S S . .
            //  1   . P H H H H .   ---->   . P H H H H .
            //  0   F F F F F F F   ---->   F F F F F F F
            var finishingHeights = new[] {2, 4, 4, 6, 3, 1, 0};
            var chamber = new Chamber(Enumerable.Repeat(0, 7).ToArray());
            var rock = Shape.MakeShape(RockShape.Square);
            
            // Setup chamber
            _ = chamber.PlaceRock(Shape.MakeShape(RockShape.HorizontalLine), 2, 1);
            _ = chamber.PlaceRock(Shape.MakeShape(RockShape.Plus), 0, 1);
            _ = chamber.PlaceRock(Shape.MakeShape(RockShape.MirroredL), 1, 4);
            
            var bottomLeftPosition = 4;
            var bottomLeftHeight = 2;

            bottomLeftPosition = chamber.PushRockLeft(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftHeight = chamber.LetRockFall(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftPosition.Should().Be(3);
            bottomLeftHeight.Should().Be(2);

            var heights = chamber.PlaceRock(rock, bottomLeftPosition, bottomLeftHeight);
            heights.Should().HaveCount(finishingHeights.Length);
            heights.Should().BeEquivalentTo(finishingHeights);
        }
        
        [Fact]
        public void PlusRockCanMoveUnderMaxHeightForWidthIndex()
        {
            //  9   . . . . . . .   ---->   . . . . . . .
            //  8   . . . H H H H   ---->   . . . H H H H
            //  7   . . . S S L .   ---->   . . . S S L .
            //  6   . . . S S L .   ---->   . . . S S L .
            //  5   . . . L L L V   ---->   . . . L L L V
            //  4   . . . . P . V   ---->   . . . . P . V
            //  3   . x . P P P V   ---->   . . x P P P V
            //  2   x x x . P . V   ---->   . x x x P . V
            //  1   . x . H H H H   ---->   . . x H H H H
            //  0   F F F F F F F   ---->   F F F F F F F
            var finishingHeights = new[] {0, 2, 3, 8, 8, 8, 8};
            var chamber = new Chamber(Enumerable.Repeat(0, 7).ToArray());
            var rock = Shape.MakeShape(RockShape.Plus);
            
            // Setup chamber
            _ = chamber.PlaceRock(Shape.MakeShape(RockShape.HorizontalLine), 3, 1);
            _ = chamber.PlaceRock(Shape.MakeShape(RockShape.Plus), 3, 2);
            _ = chamber.PlaceRock(Shape.MakeShape(RockShape.MirroredL), 3, 5);
            _ = chamber.PlaceRock(Shape.MakeShape(RockShape.VerticalLine), 6, 2);
            _ = chamber.PlaceRock(Shape.MakeShape(RockShape.Square), 3, 6);
            _ = chamber.PlaceRock(Shape.MakeShape(RockShape.HorizontalLine), 3, 8);
            
            var bottomLeftPosition = 0;
            var bottomLeftHeight = 1;
            
            bottomLeftPosition = chamber.PushRockRight(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftHeight = chamber.LetRockFall(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftPosition.Should().Be(1);
            bottomLeftHeight.Should().Be(1);

            var heights = chamber.PlaceRock(rock, bottomLeftPosition, bottomLeftHeight);
            heights.Should().HaveCount(finishingHeights.Length);
            heights.Should().BeEquivalentTo(finishingHeights);
        }

        [Fact]
        public void RockCanFallThroughGapAndRestUnderExistingHeightForColumn()
        {
            // 13   . . S S . . .   ---->   . . . . . . .
            // 12   . . S S . . .   ---->   . . . . . . .
            // 11   . . . . . . .   ---->   . . . . . . .
            // 10   . . . . . . .   ---->   . . . . . . .
            //  9   . . . . . . .   ---->   . . . . . . . 
            //  8   . . V . . . .   ---->   . . V . . . .
            //  7   . . V . . . .   ---->   . . V . . . .
            //  6   . . V . L . .   ---->   . . V . L . .
            //  5   . . V . L . .   ---->   . . V . L . .
            //  4   . . L L L P .   ---->   . . L L L P .
            //  3   . . . . P P P   ---->   . S S . P P P
            //  2   . . . . . P .   ---->   . S S . . P .
            //  1   . . H H H H .   ---->   . . H H H H .
            //  0   F F F F F F F   ---->   F F F F F F F
            var finishingHeights = new[] {0, 3, 8, 4, 6, 4, 3};
            var chamber = new Chamber(Enumerable.Repeat(0, 7).ToArray());
            
            // Setup chamber
            _ = chamber.PlaceRock(Shape.MakeShape(RockShape.HorizontalLine), 2, 1);
            _ = chamber.PlaceRock(Shape.MakeShape(RockShape.Plus), 4, 2);
            _ = chamber.PlaceRock(Shape.MakeShape(RockShape.MirroredL), 2, 4);
            _ = chamber.PlaceRock(Shape.MakeShape(RockShape.VerticalLine), 2, 5);
            
            var rock = Shape.MakeShape(RockShape.Square);
            var bottomLeftPosition = 2;
            var bottomLeftHeight = 12;

            bottomLeftPosition = chamber.PushRockLeft(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftHeight = chamber.LetRockFall(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftPosition.Should().Be(1);
            bottomLeftHeight.Should().Be(11);

            bottomLeftPosition = chamber.PushRockLeft(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftHeight = chamber.LetRockFall(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftPosition.Should().Be(0);
            bottomLeftHeight.Should().Be(10);
            
            bottomLeftPosition = chamber.PushRockLeft(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftHeight = chamber.LetRockFall(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftPosition.Should().Be(0);
            bottomLeftHeight.Should().Be(9);
            
            bottomLeftPosition = chamber.PushRockLeft(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftHeight = chamber.LetRockFall(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftPosition.Should().Be(0);
            bottomLeftHeight.Should().Be(8);
            
            bottomLeftPosition = chamber.PushRockRight(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftHeight = chamber.LetRockFall(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftPosition.Should().Be(0);
            bottomLeftHeight.Should().Be(7);
            
            bottomLeftPosition = chamber.PushRockRight(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftHeight = chamber.LetRockFall(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftPosition.Should().Be(0);
            bottomLeftHeight.Should().Be(6);
            
            bottomLeftPosition = chamber.PushRockRight(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftHeight = chamber.LetRockFall(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftPosition.Should().Be(0);
            bottomLeftHeight.Should().Be(5);
            
            bottomLeftPosition = chamber.PushRockRight(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftHeight = chamber.LetRockFall(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftPosition.Should().Be(0);
            bottomLeftHeight.Should().Be(4);
            
            bottomLeftPosition = chamber.PushRockRight(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftHeight = chamber.LetRockFall(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftPosition.Should().Be(0);
            bottomLeftHeight.Should().Be(3);
            
            bottomLeftPosition = chamber.PushRockRight(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftHeight = chamber.LetRockFall(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftPosition.Should().Be(0);
            bottomLeftHeight.Should().Be(2);
            
            bottomLeftPosition = chamber.PushRockRight(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftHeight = chamber.LetRockFall(rock, bottomLeftPosition, bottomLeftHeight);
            bottomLeftPosition.Should().Be(1);
            bottomLeftHeight.Should().Be(2);

            var heights = chamber.PlaceRock(rock, bottomLeftPosition, bottomLeftHeight);
            heights.Should().HaveCount(finishingHeights.Length);
            heights.Should().BeEquivalentTo(finishingHeights);
        }
    }
}
