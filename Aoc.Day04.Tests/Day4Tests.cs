using FluentAssertions;

namespace aoc.day04.tests;

public class Day4Tests
{
    private readonly string[] INPUT = Array.Empty<string>();

    public Day4Tests()
    {
        INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..\\..\\..\\..\\AoC.Console\\day4input.txt"));
    }

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day4 = new Day4(parser);

        var (answerOne, _) = day4.CalculateAnswers(INPUT);

        answerOne.Should().Be(4512);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day4 = new Day4(parser);

        var (_, answerTwo) = day4.CalculateAnswers(INPUT);

        answerTwo.Should().Be(0);
    }
}