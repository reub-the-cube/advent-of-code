using FluentAssertions;

namespace aoc._2022.day01.tests;

public class Day01SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..\\..\\..\\..\\..\\Inputs\\2022\\day01testinput.txt"));

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

        answerOne.Should().Be("24000");
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var dayX = new Day01Solver(parser);

        var (_, answerTwo) = dayX.CalculateAnswers(INPUT);

        answerTwo.Should().Be("45000");
    }
}