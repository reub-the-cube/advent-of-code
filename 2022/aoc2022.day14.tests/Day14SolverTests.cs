using FluentAssertions;

namespace aoc2022.day14.tests;

public class Day14SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2022", "day14testinput.txt"));
    private const string EXPECTED_ANSWER_ONE = "not_implemented"; // <--------- solution from web page test example goes here
    private const string EXPECTED_ANSWER_TWO = "not_implemented"; // <--------- solution from web page test example goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day14 = new Day14Solver(parser);

        var (answerOne, _) = day14.CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_ANSWER_ONE);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day14 = new Day14Solver(parser);

        var (_, answerTwo) = day14.CalculateAnswers(INPUT);
        
        answerTwo.Should().Be(EXPECTED_ANSWER_TWO);
    }
}
