using FluentAssertions;

namespace aoc2023.day11.tests
{
    public class GalaxyImageTests
    {
        [Fact]
        public void GalaxyImageWithMultipleEmptyRowsAndColumnsCanGetSumOfShortestPathsBetweenGalaxiesWithATwoMultiplier()
        {
            List<string> galaxyImageInput = [
                "...#......",
                ".......#..",
                "#.........",
                "..........",
                "......#...",
                ".#........",
                ".........#",
                "..........",
                ".......#..",
                "#...#....."
            ];

            var expandedGalaxyImage = GalaxyImage.Build(galaxyImageInput);

            var sumOfShortestPaths = expandedGalaxyImage.GetSumOfShortestPaths(2);

            sumOfShortestPaths.Should().Be(374);
        }

        [Fact]
        public void GalaxyImageWithMultipleEmptyRowsAndColumnsCanGetSumOfShortestPathsBetweenGalaxiesWithATenMultiplier()
        {
            List<string> galaxyImageInput = [
                "...#......",
                ".......#..",
                "#.........",
                "..........",
                "......#...",
                ".#........",
                ".........#",
                "..........",
                ".......#..",
                "#...#....."
            ];

            var galaxyImage = GalaxyImage.Build(galaxyImageInput);

            var sumOfShortestPaths = galaxyImage.GetSumOfShortestPaths(10);

            sumOfShortestPaths.Should().Be(1030);
        }

        [Fact]
        public void GalaxyImageWithMultipleEmptyRowsAndColumnsCanGetSumOfShortestPathsBetweenGalaxiesWithAHundredMultiplier()
        {
            List<string> galaxyImageInput = [
                "...#......",
                ".......#..",
                "#.........",
                "..........",
                "......#...",
                ".#........",
                ".........#",
                "..........",
                ".......#..",
                "#...#....."
            ];

            var galaxyImage = GalaxyImage.Build(galaxyImageInput);

            var sumOfShortestPaths = galaxyImage.GetSumOfShortestPaths(100);

            sumOfShortestPaths.Should().Be(8410);
        }
    }
}
