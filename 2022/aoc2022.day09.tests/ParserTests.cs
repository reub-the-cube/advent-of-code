using FluentAssertions;

namespace aoc2022.day09.tests
{
    public class ParserTests
    {
        [Fact]
        public void Parse()
        {
            var parser = new Parser();

            var parsedInput = parser.ParseInput(new[] { "U 2", "R 10", "D 1", "L 23" });

            parsedInput.Should().HaveCount(4);
            parsedInput[0].XMovement.Should().Be(0);
            parsedInput[0].YMovement.Should().Be(1);
            parsedInput[0].NumberOfMoves.Should().Be(2);

            parsedInput[1].XMovement.Should().Be(1);
            parsedInput[1].YMovement.Should().Be(0);
            parsedInput[1].NumberOfMoves.Should().Be(10);

            parsedInput[2].XMovement.Should().Be(0);
            parsedInput[2].YMovement.Should().Be(-1);
            parsedInput[2].NumberOfMoves.Should().Be(1);

            parsedInput[3].XMovement.Should().Be(-1);
            parsedInput[3].YMovement.Should().Be(0);
            parsedInput[3].NumberOfMoves.Should().Be(23);
        }
    }
}
