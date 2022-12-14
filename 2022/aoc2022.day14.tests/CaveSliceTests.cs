using aoc2022.day14.domain;
using FluentAssertions;

namespace aoc2022.day14.tests
{
    public class CaveSliceTests
    {
        private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2022", "day14testinput.txt"));

        [Fact]
        public void CloneChangesDoNotPropogate()
        {
            var tiles = new Tile[1, 1];
            tiles[0, 0] = new Tile(new Position(0, 0), TileState.Sand);
            var cave = new CaveSlice(tiles);

            var caveClone = cave.Clone();

            caveClone = caveClone.AddLineOfRocks("0,0 -> 0,0");

            caveClone.ToString().Should().Be("\r\n#");
            cave.ToString().Should().Be("\r\no");
        }

        [Theory]
        [InlineData(1, 8, 500)]
        [InlineData(2, 8, 499)]
        [InlineData(3, 8, 501)]
        [InlineData(4, 7, 500)]
        [InlineData(5, 8, 498)]
        [InlineData(22, 2, 500)]
        [InlineData(23, 5, 497)]
        [InlineData(24, 8, 495)]
        public void CanDropSand(int numberOfGrains, int finalRestingRow, int finalRestingColumn)
        {
            var tiles = new Tile[10, 504];
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 504; j++)
                {
                    tiles[i, j] = new Tile(new Position(i, j), TileState.Air);
                }
            }

            var cave = new CaveSlice(tiles);
            foreach (var item in INPUT)
            {
                cave = cave.AddLineOfRocks(item);
            }

            cave.SetSandDropPoint(0, 500);

            for (int i = 0; i < numberOfGrains - 1; i++)
            {
                _ = cave.AddGrainOfSand();
            }
            var restingPosition = cave.AddGrainOfSand();

            restingPosition.Should().NotBeNull();
            restingPosition?.Row.Should().Be(finalRestingRow);
            restingPosition?.Column.Should().Be(finalRestingColumn);
        }

        [Fact]
        public void CanDropSandIntoTheAbyss()
        {
            var tiles = new Tile[10, 504];
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 504; j++)
                {
                    tiles[i, j] = new Tile(new Position(i, j), TileState.Air);
                }
            }

            var cave = new CaveSlice(tiles);
            foreach (var item in INPUT)
            {
                cave = cave.AddLineOfRocks(item);
            }

            cave.SetSandDropPoint(0, 500);

            for (int i = 0; i < 24; i++)
            {
                _ = cave.AddGrainOfSand();
            }
            var restingPosition = cave.AddGrainOfSand();

            restingPosition.Should().BeNull();
        }
    }
}
