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
}