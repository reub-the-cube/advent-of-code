using FluentAssertions;
using static aoc2023.day14.Enums;

namespace aoc2023.day14.tests
{
    public class PlatformTests
    {
        [Fact]
        public void TiltRocksNorthWhenBlockedImmediatelyAboveByCubedRock()
        {
            List<string> rockFormation = [
                "#.",
                "O."
            ];

            var platform = new Platform(rockFormation);

            platform.TiltNorth();

            var position = platform.GetRockAtPosition(0, 0);
            position.Should().Be(RockType.Cubed);

            position = platform.GetRockAtPosition(1, 0);
            position.Should().Be(RockType.Rounded);
        }

        [Fact]
        public void TiltRocksNorthWhenImmediatelyAboveByPlatformEdge()
        {
            List<string> rockFormation = [
                "O.",
                ".."
            ];

            var platform = new Platform(rockFormation);

            platform.TiltNorth();

            var position = platform.GetRockAtPosition(0, 0);
            position.Should().Be(RockType.Rounded);

            position = platform.GetRockAtPosition(1, 0);
            position.Should().Be(RockType.None);
        }

        [Fact]
        public void TiltRocksNorthToTheEdgeOfThePlatform()
        {
            List<string> rockFormation = [
                "..",
                "OO"
            ];

            var platform = new Platform(rockFormation);

            platform.TiltNorth();

            var position = platform.GetRockAtPosition(0, 0);
            position.Should().Be(RockType.Rounded);

            position = platform.GetRockAtPosition(1, 0);
            position.Should().Be(RockType.None);


            position = platform.GetRockAtPosition(0, 1);
            position.Should().Be(RockType.Rounded);
        }

        [Fact]
        public void TiltRocksNorthWithTwoRoundedRocksMoving()
        {
            List<string> rockFormation = [
                "..",
                "O#",
                "..",
                "OO",
            ];

            var platform = new Platform(rockFormation);

            platform.TiltNorth();

            var position = platform.GetRockAtPosition(0, 0);
            position.Should().Be(RockType.Rounded);

            position = platform.GetRockAtPosition(1, 0);
            position.Should().Be(RockType.Rounded);

            position = platform.GetRockAtPosition(2, 0);
            position.Should().Be(RockType.None);

            position = platform.GetRockAtPosition(0, 1);
            position.Should().Be(RockType.None);

            position = platform.GetRockAtPosition(1, 1);
            position.Should().Be(RockType.Cubed);

            position = platform.GetRockAtPosition(2, 1);
            position.Should().Be(RockType.Rounded);
        }

        [Fact]
        public void CalculateLoadCausedByRoundedRocks()
        {
            List<string> rockFormation = [
                "..",
                "O#",
                "..",
                "OO",
            ];

            var platform = new Platform(rockFormation);

            var load = platform.CalculateLoad();

            load.Should().Be(5);
        }

        [Fact]
        public void CalculateLoadCausedByRoundedRocksAfterOneCycle()
        {
            List<string> rockFormation = [
                "O....#....",
                "O.OO#....#",
                ".....##...",
                "OO.#O....O",
                ".O.....O#.",
                "O.#..O.#.#",
                "..O..#O..O",
                ".......O..",
                "#....###..",
                "#OO..#...."
            ];

            var platform = new Platform(rockFormation);

            platform.RunCycles(1);
            var load = platform.CalculateLoad();

            load.Should().Be(87);
        }

        [Fact]
        public void CalculateLoadCausedByRoundedRocksAfterTwoCycles()
        {
            List<string> rockFormation = [
                "O....#....",
                "O.OO#....#",
                ".....##...",
                "OO.#O....O",
                ".O.....O#.",
                "O.#..O.#.#",
                "..O..#O..O",
                ".......O..",
                "#....###..",
                "#OO..#...."
            ];

            var platform = new Platform(rockFormation);

            platform.RunCycles(2);
            var load = platform.CalculateLoad();

            load.Should().Be(69);
        }

        [Fact]
        public void CalculateLoadCausedByRoundedRocksAfterThreeCycles()
        {
            List<string> rockFormation = [
                "O....#....",
                "O.OO#....#",
                ".....##...",
                "OO.#O....O",
                ".O.....O#.",
                "O.#..O.#.#",
                "..O..#O..O",
                ".......O..",
                "#....###..",
                "#OO..#...."
            ];

            var platform = new Platform(rockFormation);

            platform.RunCycles(3);
            var load = platform.CalculateLoad();

            load.Should().Be(69);
        }

        [Fact]
        public void CalculateLoadCausedByRoundedRocksAfterManyCycles()
        {
            List<string> rockFormation = [
                "O....#....",
                "O.OO#....#",
                ".....##...",
                "OO.#O....O",
                ".O.....O#.",
                "O.#..O.#.#",
                "..O..#O..O",
                ".......O..",
                "#....###..",
                "#OO..#...."
            ];

            var platform = new Platform(rockFormation);

            platform.RunCycles(1000000000);
            var load = platform.CalculateLoad();

            load.Should().Be(64);
        }
    }
}

//  1   2   3   4   5   6   7   8   9   10  11  12  13  14  15  16  17  18  19  20
//  1   2   3   4   5   6   7   8   3   4   5   6   7   8   3   4   5   6   7   8
// Step = 6
// Start = 3
// First repeat = 9
// start + (end - first repeat) % step = 5

// End 20 => 3 + (17 % 6) => 8
// End 16 => 3 + (13 % 6) => 4
