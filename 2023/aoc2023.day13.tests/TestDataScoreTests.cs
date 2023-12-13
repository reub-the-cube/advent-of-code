using FluentAssertions;

namespace aoc2023.day13.tests
{
    public class TestDataScoreTests
    {
        [Fact]
        public void GetSummarizeScoreForTestData1()
        {
            List<string> patternLines = [
                "######..#....#.",
                "######.#.#.####",
                "##..###.##.#..#",
                "......######.#.",
                "#....###...##.#",
                ".#..#.###.#.##.",
                ".#..#..##.#.##."
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.SummarizeScore(true);

            linesAboveReflection.Should().Be(600);
        }

        [Fact]
        public void GetSummarizeScoreForTestData2()
        {
            List<string> patternLines = [
"#.#....##....#.#.",
"#.#....##....#.#.",
"##.##.####.##.###",
".....#....#......",
"#####.####.######",
".###...##...###.#",
"..####....####...",
".#####....#####.#",
".##...#..##..##..",
"#.####....####.#.",
".#....####....#.#",
"..##........##...",
".#.###....###.#.#"
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.SummarizeScore(true);

            linesAboveReflection.Should().Be(8);
        }

        [Fact]
        public void GetSummarizeScoreForTestData3()
        {
            List<string> patternLines = [
"#########..##",
".####..#.##.#",
".#..#....##..",
"..##..#.#..#.",
".......#.##.#",
".####.#.#..#.",
"..##...#....#",
"......#..##..",
"#...###..##.."
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.SummarizeScore(true);

            linesAboveReflection.Should().Be(3);
        }

        [Fact]
        public void GetSummarizeScoreForTestData4()
        {
            List<string> patternLines = [
"#..#..#.###",
"###....####",
"##..##.#.#.",
"##..##.#.#.",
"###....####",
"#..#..#.###",
"##.##..##.#",
"#...#.....#",
"...##.###.#",
"####.#.##..",
".#.###.#...",
"####..#...#",
"#.#.#####..",
"#.#.#####..",
"####..#....",
".#.###.#...",
"####.#.##.."
            ];

            var pattern = new Pattern(patternLines);
            var linesAboveReflection = pattern.SummarizeScore(true);

            linesAboveReflection.Should().Be(1300);
        }
    }
}
