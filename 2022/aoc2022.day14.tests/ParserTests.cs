using FluentAssertions;

namespace aoc2022.day14.tests
{
    public class ParserTests
    {
        private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2022", "day14testinput.txt"));

        [Fact]
        public void ParserCanBuildSliceOfCaveFromTest()
        {
            var parser = new Parser();

            var parsedInput = parser.ParseInput(INPUT);

            parsedInput.CaveSlice.GetNumberOfRows().Should().Be(9); // number of rows
            parsedInput.CaveSlice.GetNumberOfColumns().Should().Be(9); // number of columns

            //foreach (var item in INPUT)
            //{
            //    slice.AddLineOfRocks(item);
            //}
        }

        [Fact]
        public void ParserCanBuildSliceOfCaveFromWideRectangle()
        {
            var input = new[]
            {
                "498,4 -> 498,6 -> 496,6",
                "503,4 -> 502,4 -> 502,9 -> 494,9",
                "492,8 -> 493,8 -> 493,6"
            };

            var parser = new Parser();

            var parsedInput = parser.ParseInput(input);

            parsedInput.CaveSlice.GetNumberOfRows().Should().Be(9); // number of rows
            parsedInput.CaveSlice.GetNumberOfColumns().Should().Be(11); // number of columns
        }
    }
}
