using FluentAssertions;

namespace aoc2023.day01.tests
{
    public class CalibrationDecoderTests
    {
        [Theory]
        [InlineData("1abc2", 1, 2)]
        [InlineData("pqr3stu8vwx", 3, 8)]
        [InlineData("a1b2c3d4e5f", 1, 5)]
        [InlineData("treb7uchet", 7, 7)]
        public void WhenInputLineIsDecodedThenItReturnsFirstAndLastDigit(string inputLine, int expectedFirstDigit, int expectedLastDigit)
        {
            (int firstDigit, int lastDigit) = CalibrationDecoder.GetFirstAndLastDigit(inputLine);

            firstDigit.Should().Be(expectedFirstDigit);
            lastDigit.Should().Be(expectedLastDigit);
        }

        [Theory]
        [InlineData("two1nine", 2, 9)]
        [InlineData("eightwothree", 8, 3)]
        [InlineData("abcone2threexyz", 1, 3)]
        [InlineData("xtwone3four", 2, 4)]
        [InlineData("4nineeightseven2", 4, 2)]
        [InlineData("zoneight234", 1, 4)]
        [InlineData("7pqrstsixteen", 7, 6)]
        [InlineData("7pqrstsixteenzero", 7, 6)]
        [InlineData("szsvltgsc1onecccbfour3oneightfh", 1, 8)]
        public void WhenInputLineIsDecodedThenItReturnsFirstAndLastDigitIncludingText(string inputLine, int expectedFirstDigit, int expectedLastDigit)
        {
            (int firstDigit, int lastDigit) = CalibrationDecoder.GetFirstAndLastDigit(inputLine, true);

            firstDigit.Should().Be(expectedFirstDigit);
            lastDigit.Should().Be(expectedLastDigit);
        }
    }
}
