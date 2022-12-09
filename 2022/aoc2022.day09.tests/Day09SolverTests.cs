using FluentAssertions;

namespace aoc2022.day09.tests;

public class Day09SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..\\..\\..\\..\\..\\Inputs\\2022\\day09testinput.txt"));
    private const string EXPECTED_ANSWER_ONE = "13"; // <--------- solution from web page test example goes here
    private const string EXPECTED_ANSWER_TWO = "1"; // <--------- solution from web page test example goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day09 = new Day09Solver(parser);

        var (answerOne, _) = day09.CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_ANSWER_ONE);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day09 = new Day09Solver(parser);

        var (_, answerTwo) = day09.CalculateAnswers(INPUT);
        
        answerTwo.Should().Be(EXPECTED_ANSWER_TWO);
    }

    [Fact]
    public void CalculatedAnswerTwoBiggerExampleMatchesTestCase()
    {
        var parser = new Parser();
        var day09 = new Day09Solver(parser);

        var input = new[] { "R 5", "U 8", "L 8", "D 3", "R 17", "D 10", "L 25", "U 20" };
        var (_, answerTwo) = day09.CalculateAnswers(input);

        answerTwo.Should().Be("36");
    }
}
