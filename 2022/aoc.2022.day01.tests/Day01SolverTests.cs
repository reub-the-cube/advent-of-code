using FluentAssertions;

namespace aoc._2022.day01.tests;

public class Day01SolverTests
{
    private readonly string[] INPUT = new string[] { };         // <-------- new day's test example input goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var dayX = new Day01Solver(parser);

        var (answerOne, _) = dayX.CalculateAnswers(INPUT);

        answerOne.Should().Be(150);                             // <--------- solution from web page test example goes here
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var dayX = new Day01Solver(parser);

        var (_, answerTwo) = dayX.CalculateAnswers(INPUT);

        Assert.Fail("We don't have part 2 of the day's challenge yet so it is not implemented");
    }
}