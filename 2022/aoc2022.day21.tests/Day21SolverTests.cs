using FluentAssertions;

namespace aoc2022.day21.tests;

public class Day21SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2022", "day21testinput.txt"));
    private const string EXPECTED_ANSWER_ONE = "152"; // <--------- solution from web page test example goes here
    private const string EXPECTED_ANSWER_TWO = "301"; // <--------- solution from web page test example goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day21 = new Day21Solver(parser);

        var (answerOne, _) = day21.CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_ANSWER_ONE);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day21 = new Day21Solver(parser);

        var (_, answerTwo) = day21.CalculateAnswers(INPUT);
        
        answerTwo.Should().Be(EXPECTED_ANSWER_TWO);
    }
}
