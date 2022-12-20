using FluentAssertions;

namespace aoc2022.day18.tests;

public class Day18SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2022", "day18testinput.txt"));
    private const string EXPECTED_ANSWER_ONE = "64"; // <--------- solution from web page test example goes here
    private const string EXPECTED_ANSWER_TWO = "58"; // <--------- solution from web page test example goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day18 = new Day18Solver(parser);

        var (answerOne, _) = day18.CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_ANSWER_ONE);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day18 = new Day18Solver(parser);

        var (_, answerTwo) = day18.CalculateAnswers(INPUT);
        
        answerTwo.Should().Be(EXPECTED_ANSWER_TWO);
    }
}
