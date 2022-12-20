using FluentAssertions;

namespace aoc2022.day20.tests;

public class Day20SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2022", "day20testinput.txt"));
    private const string EXPECTED_ANSWER_ONE = "3"; // <--------- solution from web page test example goes here
    private const string EXPECTED_ANSWER_TWO = "1623178306"; // <--------- solution from web page test example goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day20 = new Day20Solver(parser);

        var (answerOne, _) = day20.CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_ANSWER_ONE);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day20 = new Day20Solver(parser);

        var (_, answerTwo) = day20.CalculateAnswers(INPUT);
        
        answerTwo.Should().Be(EXPECTED_ANSWER_TWO);
    }
}
