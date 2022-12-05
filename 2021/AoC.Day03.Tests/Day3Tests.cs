using FluentAssertions;

namespace AoC.Day03.Tests;

public class Day3Tests
{
    private readonly string[] INPUT = new string[] { "00100", "11110", "10110", "10111", "10101", "01111", "00111", "11100", "10000", "11001", "00010", "01010" };

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day = new Day3(parser);

        var (answerOne, _) = day.CalculateAnswers(INPUT);

        answerOne.Should().Be("198");
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day = new Day3(parser);

        var (_, answerTwo) = day.CalculateAnswers(INPUT);

        answerTwo.Should().Be("230");
    }

    [Fact] 
    public void CheckBinaryParser()
    {
        var parser = new Parser();
        var parsedInput = parser.ParseInput(new [] { "0001", "0111" });

        uint expectedOne = 0b_0001;
        uint expectedTwo = 0b_0111;
        parsedInput.BinaryNumbers[0].Should().Be(expectedOne);
        parsedInput.BinaryNumbers[1].Should().Be(expectedTwo);
    }

    [Fact]
    public void CheckBitValueCount()
    {
        var parsedInput = new uint[] { 0b_0001, 0b_0111, 0b_1011 };
        var result = Day3.MostCommonBitFlags(parsedInput, 4).ToList();

        result[0].Should().Be(false);
        result[1].Should().Be(false);
        result[2].Should().Be(true);
        result[3].Should().Be(true);
    }

    [Fact] 
    public void GetGammaRate()
    {
        var result = Day3.GetGammaRate(new [] { true, false, false, true, false });

        const uint expectedOne = 0b_0001_0010;
        result.Should().Be(expectedOne);
    }
    
    [Fact] 
    public void GetBitwiseComplement()
    {
        // 0b_0101 --> 0b_1010
        var result = Day3.GetBitwiseComplement(5, 4);
        result.Should().Be(10);
    }
    
    [Fact]
    public void GetOxygenGeneratorRating()
    {
        var result = Day3.GetOxygenGeneratorRating(new uint[] { 0b_1011, 0b_1001, 0b_0000, 0b_1110, 0b_0111 }, 4);

        const uint expectedOne = 0b_1011;
        result.Should().Be(expectedOne);

        // 0b_1011 --> 0b_011 --> 0b_11 --> 0b_1
        // 0b_1001 --> 0b_001 --> 0b_01 --> XX
        // 0b_0000 --> XX
        // 0b_1110 --> 0b_110 --> XX
        // 0b_0111 --> XX
    }

    [Fact]
    public void GetCO2ScrubberRating()
    {
        var result = Day3.GetCO2ScrubberRating(new uint[] { 0b_1011, 0b_1001, 0b_0000, 0b_1110, 0b_0111 }, 4);

        const uint expected = 0b_0000;
        result.Should().Be(expected);

        // 0b_1011 --> XX
        // 0b_1001 --> XX
        // 0b_0000 --> 0b_000 --> 0b_00
        // 0b_1110 --> XX
        // 0b_0111 --> 0b_111 --> XX
    }
}