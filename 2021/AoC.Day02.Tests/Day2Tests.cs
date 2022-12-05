using AoC.Day02.Models;
using FluentAssertions;
using Moq;

namespace AoC.Day02.Tests;

public class Day2Tests
{
    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var input = new string[] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" };
        var parser = new Parser();

        var day2 = new Day2(parser);

        var (answerOne, _) = day2.CalculateAnswers(input);

        answerOne.Should().Be("150");
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var input = new string[] { "forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2" };
        var parser = new Parser();

        var day2 = new Day2(parser);

        var (_, answerTwo) = day2.CalculateAnswers(input);

        answerTwo.Should().Be("900");
    }
}