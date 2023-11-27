using FluentAssertions;

namespace aoc2020.day02.tests
{
    public class ParserTests
    {
        [Fact]
        public void ParserCreatesPolicyCorrectly()
        {
            var parser = new Parser();

            var result = parser.ParseInput(new[] { "1-3 a: abcde" });

            result.PolicyPasswordPairs.Should().NotBeNull();
            result.PolicyPasswordPairs?.Count.Should().Be(1);
            result.PolicyPasswordPairs?.First().Key.Min.Should().Be(1);
            result.PolicyPasswordPairs?.First().Key.Max.Should().Be(3);
            result.PolicyPasswordPairs?.First().Key.SearchFor.Should().Be('a');
        }

        [Fact]
        public void ParserCreatesPasswordCorrectly()
        {
            var parser = new Parser();

            var result = parser.ParseInput(new[] { "1-3 a: abcde" });

            result.PolicyPasswordPairs.Should().NotBeNull();
            result.PolicyPasswordPairs?.Count.Should().Be(1);
            result.PolicyPasswordPairs?.First().Value.Should().Be("abcde");
        }
    }
}
