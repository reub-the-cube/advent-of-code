using aoc2022.day09.domain;
using FluentAssertions;
using System.Runtime.CompilerServices;

namespace aoc2022.day09.tests
{
    // Position is (X, Y) where X is horizontal and Y is vertical

    public class KnotTests
    {
        [Fact]
        public void KnotCanFollowPositionVerticallyUp()
        {
            var knot = new Knot(1, 2);

            var newKnot = knot.Follow(1, 4);

            newKnot.X.Should().Be(1);
            newKnot.Y.Should().Be(3);
        }

        [Fact]
        public void KnotCanFollowPositionVerticallyDown()
        {
            var knot = new Knot(1, 2);

            var newKnot = knot.Follow(1, 0);

            newKnot.X.Should().Be(1);
            newKnot.Y.Should().Be(1);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(5)]
        public void KnotCannotFollowPositionVerticallyIfOutOfRange(int yToFollow)
        {
            var knot = new Knot(1, 2);

            var actionDown = () => knot.Follow(1, yToFollow);

            actionDown.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void KnotCanFollowPositionVerticallyWithoutChangingPositionInRange(int yToFollow)
        {
            var knot = new Knot(1, 2);

            var newKnot = knot.Follow(1, yToFollow);

            newKnot.X.Should().Be(1);
            newKnot.Y.Should().Be(2);
        }

        [Fact]
        public void KnotCanFollowPositionHorizontallyLeft()
        {
            var knot = new Knot(1, 2);

            var newKnot = knot.Follow(-1, 2);

            newKnot.X.Should().Be(0);
            newKnot.Y.Should().Be(2);
        }

        [Fact]
        public void KnotCanFollowPositionHorizontallyRight()
        {
            var knot = new Knot(1, 2);

            var newKnot = knot.Follow(3, 2);

            newKnot.X.Should().Be(2);
            newKnot.Y.Should().Be(2);
        }

        [Theory]
        [InlineData(-2)]
        [InlineData(4)]
        public void KnotCannotFollowPositionHorizontallyIfOutOfRange(int xToFollow)
        {
            var knot = new Knot(1, 2);

            var actionDown = () => knot.Follow(xToFollow, 2);

            actionDown.Should().Throw<ArgumentOutOfRangeException>();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void KnotCanFollowPositionHorizontallyWithoutChangingPositionInRange(int xToFollow)
        {
            var knot = new Knot(1, 2);

            var newKnot = knot.Follow(xToFollow, 2);

            newKnot.X.Should().Be(1);
            newKnot.Y.Should().Be(2);
        }

        [Theory]
        [InlineData(-1, 3, -1, 1)]
        [InlineData(0, 4, -1, 1)]
        [InlineData(2, 4, 1, 1)]
        [InlineData(3, 3, 1, 1)]
        [InlineData(3, 1, 1, -1)]
        [InlineData(2, 0, 1, -1)]
        [InlineData(0, 0, -1, -1)]
        [InlineData(-1, 1, -1, -1)]
        public void KnotCanFollowPositionDiagonally(int xToFollow, int yToFollow, int xMovement, int yMovement)
        {
            /*
                4  .  b  .  c  .
                3  a  .  .  .  d
                2  .  .  X  .  .
                1  h  .  .  .  e
                0  .  g  .  f  .
                  -1  0  1  2  3
            */

            var knot = new Knot(1, 2);

            var newKnot = knot.Follow(xToFollow, yToFollow);

            newKnot.X.Should().Be(1 + xMovement);
            newKnot.Y.Should().Be(2 + yMovement);
        }

        [Theory]
        [InlineData(0, 3)]
        [InlineData(2, 3)]
        [InlineData(2, 1)]
        [InlineData(0, 1)]
        public void KnotCanFollowPositionDiagonallyWithoutChangingPosition(int xToFollow, int yToFollow)
        {
            /*
                4  .  .  .  .  .
                3  .  a  .  b  .
                2  .  .  X  .  .
                1  .  d  .  c  .
                0  .  .  .  .  .
                  -1  0  1  2  3
            */

            var knot = new Knot(1, 2);

            var newKnot = knot.Follow(xToFollow, yToFollow);

            newKnot.X.Should().Be(1);
            newKnot.Y.Should().Be(2);
        }
    }
}
