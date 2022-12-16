using FluentAssertions;

namespace aoc2022.day15.tests;

public class Day15SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2022", "day15testinput.txt"));
    private const string EXPECTED_ANSWER_ONE = "26"; // <--------- solution from web page test example goes here
    private const string EXPECTED_ANSWER_TWO = "56000011"; // <--------- solution from web page test example goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var solverConfig = new TestSolverConfig();
        var day15 = new Day15Solver(parser, solverConfig);

        var (answerOne, _) = day15.CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_ANSWER_ONE);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var solverConfig = new TestSolverConfig();
        var day15 = new Day15Solver(parser, solverConfig);

        var (_, answerTwo) = day15.CalculateAnswers(INPUT);
        
        answerTwo.Should().Be(EXPECTED_ANSWER_TWO);
    }
}
