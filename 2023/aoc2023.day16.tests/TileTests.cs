using FluentAssertions;
using static aoc2023.day16.Enums;

namespace aoc2023.day16.tests
{
    public class TileTests
    {
        [Theory]
        [InlineData(Direction.Left)]
        [InlineData(Direction.Down)]
        [InlineData(Direction.Right)]
        [InlineData(Direction.Up)]
        public void ExitDirectionOfTravelIsTheSameAsEntryDirectionForAnEmptyTile(Direction entryDirection)
        {
            var tile = new NothingTile();

            var exitDirectionsOfTravel = tile.GetExitDirectionsOfTravel(entryDirection);

            exitDirectionsOfTravel.Should().HaveCount(1);
            exitDirectionsOfTravel[0].Should().Be(entryDirection);
        }

        [Theory]
        [InlineData(Direction.Left)]
        [InlineData(Direction.Right)]
        public void WhenTravellingHorizontallyExitDirectionOfTravelIsTheSameAsEntryDirectionForHorizontalSplitter(Direction entryDirection)
        {
            var tile = new HorizontalSplitterTile();

            var exitDirectionsOfTravel = tile.GetExitDirectionsOfTravel(entryDirection);

            exitDirectionsOfTravel.Should().HaveCount(1);
            exitDirectionsOfTravel[0].Should().Be(entryDirection);
        }

        [Theory]
        [InlineData(Direction.Up)]
        [InlineData(Direction.Down)]
        public void WhenTravellingVerticallyExitDirectionOfTravelIsSplitFromEntryDirectionForHorizontalSplitter(Direction entryDirection)
        {
            var tile = new HorizontalSplitterTile();

            var exitDirectionsOfTravel = tile.GetExitDirectionsOfTravel(entryDirection);

            exitDirectionsOfTravel.Should().HaveCount(2);
            exitDirectionsOfTravel.Any(d => d == Direction.Left).Should().BeTrue();
            exitDirectionsOfTravel.Any(d => d == Direction.Right).Should().BeTrue();
        }

        [Theory]
        [InlineData(Direction.Up)]
        [InlineData(Direction.Down)]
        public void WhenTravellingVerticallyExitDirectionOfTravelIsTheSameAsEntryDirectionForVerticalSplitter(Direction entryDirection)
        {
            var tile = new VerticalSplitterTile();

            var exitDirectionsOfTravel = tile.GetExitDirectionsOfTravel(entryDirection);

            exitDirectionsOfTravel.Should().HaveCount(1);
            exitDirectionsOfTravel[0].Should().Be(entryDirection);
        }

        [Theory]
        [InlineData(Direction.Left)]
        [InlineData(Direction.Right)]
        public void WhenTravellingHorizontallyExitDirectionOfTravelIsSplitFromEntryDirectionForVerticalSplitter(Direction entryDirection)
        {
            var tile = new VerticalSplitterTile();

            var exitDirectionsOfTravel = tile.GetExitDirectionsOfTravel(entryDirection);

            exitDirectionsOfTravel.Should().HaveCount(2);
            exitDirectionsOfTravel.Any(d => d == Direction.Up).Should().BeTrue();
            exitDirectionsOfTravel.Any(d => d == Direction.Down).Should().BeTrue();
        }

        [Theory]
        [InlineData(Direction.Left, Direction.Down)]
        [InlineData(Direction.Up, Direction.Right)]
        [InlineData(Direction.Right, Direction.Up)]
        [InlineData(Direction.Down, Direction.Left)]
        public void ExitDirectionOfTravelIsLeftUpOrUpRightOrRightDownOrDownLeftFromEntryDirectionForForwardSlashMirror(Direction entryDirection, Direction exitDirection)
        {
            var tile = new ForwardSlashMirrorTile();

            var exitDirectionsOfTravel = tile.GetExitDirectionsOfTravel(entryDirection);

            exitDirectionsOfTravel.Should().HaveCount(1);
            exitDirectionsOfTravel[0].Should().Be(exitDirection);
        }

        [Theory]
        [InlineData(Direction.Left, Direction.Up)]
        [InlineData(Direction.Up, Direction.Left)]
        [InlineData(Direction.Right, Direction.Down)]
        [InlineData(Direction.Down, Direction.Right)]
        public void ExitDirectionOfTravelIsLeftDownOrUpLeftOrRightUpOrDownRightFromEntryDirectionForForwardSlashMirror(Direction entryDirection, Direction exitDirection)
        {
            var tile = new BackwardSlashMirrorTile();

            var exitDirectionsOfTravel = tile.GetExitDirectionsOfTravel(entryDirection);

            exitDirectionsOfTravel.Should().HaveCount(1);
            exitDirectionsOfTravel[0].Should().Be(exitDirection);
        }
    }
}
