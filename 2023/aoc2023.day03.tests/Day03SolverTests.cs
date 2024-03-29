using FluentAssertions;

namespace aoc2023.day03.tests;

public class Day03SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2023", "day03testinput.txt"));
    private const string EXPECTED_ANSWER_ONE = "4361"; // <--------- solution from web page test example goes here
    private const string EXPECTED_ANSWER_TWO = "467835"; // <--------- solution from web page test example goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day03 = new Day03Solver(parser);

        var (answerOne, _) = day03.CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_ANSWER_ONE);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day03 = new Day03Solver(parser);

        var (_, answerTwo) = day03.CalculateAnswers(INPUT);
        
        answerTwo.Should().Be(EXPECTED_ANSWER_TWO);
    }
}
