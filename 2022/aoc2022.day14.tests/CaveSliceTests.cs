using aoc2022.day14.domain;
using FluentAssertions;

namespace aoc2022.day14.tests
{
    public class CaveSliceTests
    {
        private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2022", "day14testinput.txt"));

        [Fact]
        public void CaveCanHaveALineOfRocksAdded()
        {
            var expectedResult = "\r\n..........\r\n..........\r\n..........\r\n..........\r\n....#...##\r\n....#...#.\r\n..###...#.\r\n........#.\r\n........#.\r\n#########.";

            var tiles = new Tile[10, 10];
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    tiles[i, j] = new Tile(new Position(i, j), TileState.Air);
                }
            }

            var cave = new CaveSlice(tiles);
            foreach (var item in INPUT)
            {
                cave = cave.AddLineOfRocks(item, 494);
            }
            var actualResult = cave.ToString();

            actualResult.Should().Be(expectedResult);
        }

        [Fact]
        public void CloneChangesDoNotPropogate()
        {
            var tiles = new Tile[1, 1];
            tiles[0, 0] = new Tile(new Position(0, 0), TileState.Sand);
            var cave = new CaveSlice(tiles);

            var caveClone = cave.Clone();

            caveClone = caveClone.AddLineOfRocks("0,0 -> 0,0", 0);

            caveClone.ToString().Should().Be("\r\n#");
            cave.ToString().Should().Be("\r\no");
        }

        [Theory]
        [InlineData(1, 8, 6)]
        [InlineData(2, 8, 5)]
        [InlineData(3, 8, 7)]
        [InlineData(4, 7, 6)]
        [InlineData(5, 8, 4)]
        [InlineData(22, 2, 6)]
        [InlineData(23, 5, 3)]
        [InlineData(24, 8, 1)]
        public void CanDropSand(int numberOfGrains, int finalRestingRow, int finalRestingColumn)
        {
            var tiles = new Tile[10, 10];
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    tiles[i, j] = new Tile(new Position(i, j), TileState.Air);
                }
            }

            var cave = new CaveSlice(tiles);
            foreach (var item in INPUT)
            {
                cave = cave.AddLineOfRocks(item, 494);
            }

            cave.SetSandDropPoint(0, 6);

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
            var tiles = new Tile[10, 10];
            for (var i = 0; i < 10; i++)
            {
                for (var j = 0; j < 10; j++)
                {
                    tiles[i, j] = new Tile(new Position(i, j), TileState.Air);
                }
            }

            var cave = new CaveSlice(tiles);
            foreach (var item in INPUT)
            {
                cave = cave.AddLineOfRocks(item, 494);
            }

            cave.SetSandDropPoint(0, 6);

            for (int i = 0; i < 24; i++)
            {
                _ = cave.AddGrainOfSand();
            }
            var restingPosition = cave.AddGrainOfSand();

            restingPosition.Should().BeNull();
        }
    }
}
