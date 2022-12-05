using FluentAssertions;

namespace aoc2022.day05.tests;

public class Day05SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..\\..\\..\\..\\..\\Inputs\\2022\\day05testinput.txt"));
    private const string EXPECTED_ANSWER_ONE = "CMZ"; // <--------- solution from web page test example goes here
    private const int EXPECTED_ANSWER_TWO = -1; // <--------- solution from web page test example goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day05 = new Day05Solver(parser);

        var (answerOne, _) = day05.CalculateNewAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_ANSWER_ONE);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day05 = new Day05Solver(parser);

        var (_, answerTwo) = day05.CalculateAnswers(INPUT);
        
        answerTwo.Should().Be(EXPECTED_ANSWER_TWO);
    }
}
