using FluentAssertions;

namespace aoc2023.day10.tests
{
    public class TileTests
    {
        [Fact]
        public void NumberOfConnectedNeighboursIsZeroIfUnconnected()
        {
            var tile = new Tile('S', null, null, null, null);

            var connectedPipes = tile.GetNumberOfConnectedNeighbours();

            connectedPipes.Should().Be(0);
        }

        [Fact]
        public void NumberOfConnectedNeighboursIsZeroIfNeighboursConnectElsewhere()
        {
            var tile = new Tile('|', '-', '|', 'X', 'X');

            var connectedPipes = tile.GetNumberOfConnectedNeighbours();

            connectedPipes.Should().Be(0);
        }

        [Fact]
        public void NumberOfConnectedNeighboursIsZeroIfANeighbourWantsToConnectFromTheRightButCannot()
        {
            var tile = new Tile('|', '-', '-', 'X', 'X');

            var connectedPipes = tile.GetNumberOfConnectedNeighbours();

            connectedPipes.Should().Be(0);
        }

        [Fact]
        public void NumberOfConnectedNeighboursIsOneIfANeighbourWantsToConnectFromTheRightAndCan()
        {
            var tile = new Tile('L', '-', '-', 'X', 'X');

            var connectedPipes = tile.GetNumberOfConnectedNeighbours();

            connectedPipes.Should().Be(1);
        }

        [Fact]
        public void NumberOfConnectedNeighboursIsTwoIfANeighbourWantsToConnectOnAllSides()
        {
            var tile = new Tile('L', 'F', '7', 'J', 'L');

            var connectedPipes = tile.GetNumberOfConnectedNeighbours();

            connectedPipes.Should().Be(2);
        }

        [Fact]
        public void NumberOfConnectedNeighboursIsFourIfANeighbourWantsToConnectOnAllSidesAndConnectedFromStart()
        {
            var tile = new Tile('S', '|', '-', '|', '-');

            var connectedPipes = tile.GetNumberOfConnectedNeighbours();

            connectedPipes.Should().Be(4);
        }

        [Fact]
        public void NumberOfConnectedNeighboursIsOneIfANeighboursIsTheStart()
        {
            var tileBelowStart = new Tile('|', 'S', null, null, null);
            var tileLeftOfStart = new Tile('-', null, 'S', null, null);
            var tileAboveStart = new Tile('|', null, null, 'S', null);
            var tileRightOfStart = new Tile('-', null, null, null, 'S');

            var connectedPipes = tileBelowStart.GetNumberOfConnectedNeighbours();
            connectedPipes.Should().Be(1);

            connectedPipes = tileLeftOfStart.GetNumberOfConnectedNeighbours();
            connectedPipes.Should().Be(1);

            connectedPipes = tileAboveStart.GetNumberOfConnectedNeighbours();
            connectedPipes.Should().Be(1);

            connectedPipes = tileRightOfStart.GetNumberOfConnectedNeighbours();
            connectedPipes.Should().Be(1);
        }
    }
}
