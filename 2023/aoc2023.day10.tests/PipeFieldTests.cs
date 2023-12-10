using AoC.Core;
using aoc2023.day10.domain;
using FluentAssertions;

namespace aoc2023.day10.tests
{
    public class PipeFieldTests
    {
        private readonly string[] INPUT_1B = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2023", "day10testinput_part1b.txt"));
        private readonly string[] INPUT_1C = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2023", "day10testinput_part1c.txt"));
        private readonly IParser<Input> inputParser = new Parser();

        [Fact]
        public void FurthestDistanceToAPipeInTheLoop()
        {
            //    /* FROM     TO
            //     *  
            //     * .F7-.    .01..
            //     * F|L77    .123.
            //     * -L-J.    .234.
            //     */

            var initialField = new char[][] {
                    ['.', 'F', '7', '-', '.'],
                    ['F', '|', 'L', '7', '7'],
                    ['-', 'L', '-', 'J', '.']
                };

            var pipeField = new PipeField(PipeField.BuildField(initialField));

            var furthestDistance = pipeField.GetFurthestDistance(0, 1);

            furthestDistance.Should().Be(4);
        }

        [Fact]
        public void FurthestDistanceToAPipeInTheLoop_TestExampleOne()
        {
            var parsedInput = inputParser.ParseInput(INPUT_1B);
            var pipeField = new PipeField(PipeField.BuildField(parsedInput.Sketch));

            var furthestDistance = pipeField.GetFurthestDistance(1, 1);

            furthestDistance.Should().Be(4);
        }

        [Fact]
        public void FurthestDistanceToAPipeInTheLoop_TestExampleTwo()
        {
            var parsedInput = inputParser.ParseInput(INPUT_1C);
            var pipeField = new PipeField(PipeField.BuildField(parsedInput.Sketch));

            var furthestDistance = pipeField.GetFurthestDistance(1, 1);

            furthestDistance.Should().Be(8);
        }

        //This test is commented because there is no need (yet) to remove unconnected pipes
        //[Fact]
        //public void PipeFieldCanHaveNonConnectedPipesRemoved()
        //{
        //    /* FROM     TO
        //     *  
        //     * .F7-.    .F7..
        //     * F|L77    .|L7.
        //     * -L-J.    .L-J.
        //     */
        //    //var parsedInput = inputParser.ParseInput(INPUT_1A);
        //    var initialField = new char[][] {
        //        ['.', 'F', '7', '-', '.'],
        //        ['F', '|', 'L', '7', '7'],
        //        ['-', 'L', '-', 'J', '.']
        //    };

        //    var clearedField = new char[][] {
        //        ['.', 'F', '7', '.', '.'],
        //        ['.', '|', 'L', '7', '.'],
        //        ['.', 'L', '-', 'J', '.']
        //    };

        //    var pipeField = new PipeField(initialField);

        //    var clearedPipeField = pipeField.RemoveUnconnectedPipes();

        //    clearedPipeField.Get().Should().Be(clearedField);
        //}
    }
}
