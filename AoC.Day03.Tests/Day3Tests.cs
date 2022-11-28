using AoC.Day03.Models;
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

        answerOne.Should().Be(198);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day = new Day3(parser);

        var (_, answerTwo) = day.CalculateAnswers(INPUT);

        Assert.Fail("not implemented");
    }

    [Fact] 
    public void CheckBinaryParser()
    {
        var parser = new Parser();
        var parsedInput = parser.ParseInput(new [] { "0001", "0111" });

        uint expectedOne = 0b_0001;
        uint expectedTwo = 0b_0111;
        parsedInput[0].BinaryNumber.Should().Be(expectedOne);
        parsedInput[1].BinaryNumber.Should().Be(expectedTwo);
    }

    [Fact]
    public void CheckBitValueCount()
    {
        var parsedInput = new uint[] { 0b_0001, 0b_0111, 0b_1011 };
        var result = Day3.MostCommonBitFlagByPosition(parsedInput, 4, null).ToList();

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
        var result = Day3.GetOxygenGeneratorRating(new uint[] { 0b_1011, 0b_1001, 0b_1000, 0b_1110 }, 4);

        const uint expectedOne = 0b_1001;
        result.Should().Be(expectedOne);
    }
}