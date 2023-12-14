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
                "O."
            ];

            var platform = new Platform(rockFormation);

            platform.TiltNorth();

            var position = platform.GetRockAtPosition(0, 0);
            position.Should().Be(RockType.Rounded);

            position = platform.GetRockAtPosition(1, 0);
            position.Should().Be(RockType.None);
        }
    }
}
