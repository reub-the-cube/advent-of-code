using FluentAssertions;

namespace aoc2023.day10.tests
{
    public class TileTests
    {
        [Fact]
        public void NumberOfConnectedNeighboursIsZeroIfUnconnected()
        {
            var tile = new Tile(null, null, null, null);

            var connectedPipes = tile.GetNumberOfConnectedNeighbours();

            connectedPipes.Should().Be(0);
        }

        [Fact]
        public void NumberOfConnectedNeighboursIsZeroIfNeighboursConnectElsewhere()
        {
            var tile = new Tile('-', '|', 'B', 'S');

            var connectedPipes = tile.GetNumberOfConnectedNeighbours();

            connectedPipes.Should().Be(0);
        }

        [Fact]
        public void NumberOfConnectedNeighboursIsOneIfANeighbourIsConnectedToTheRight()
        {
            var tile = new Tile('-', '-', 'B', 'S');

            var connectedPipes = tile.GetNumberOfConnectedNeighbours();

            connectedPipes.Should().Be(1);
        }

        [Fact]
        public void NumberOfConnectedNeighboursIsFourIfANeighbourIsConnectedOnAllSides()
        {
            var tile = new Tile('F', '7', 'J', 'L');

            var connectedPipes = tile.GetNumberOfConnectedNeighbours();

            connectedPipes.Should().Be(4);
        }
    }
}
