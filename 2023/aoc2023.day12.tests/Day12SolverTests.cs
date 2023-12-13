using FluentAssertions;

namespace aoc2023.day12.tests;

public class Day12SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2023", "day12testinput.txt"));
    private const string EXPECTED_ANSWER_ONE = "21"; // <--------- solution from web page test example goes here
    private const string EXPECTED_ANSWER_TWO = "525152"; // <--------- solution from web page test example goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day12 = new Day12Solver(parser);

        var (answerOne, _) = day12.CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_ANSWER_ONE);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day12 = new Day12Solver(parser);

        var (_, answerTwo) = day12.CalculateAnswers(INPUT);
        
        answerTwo.Should().Be(EXPECTED_ANSWER_TWO);
    }
}
