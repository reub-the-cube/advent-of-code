using FluentAssertions;

namespace aoc2022.day13.tests;

public class Day13SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..\\..\\..\\..\\..\\Inputs\\2022\\day13testinput.txt"));
    private const string EXPECTED_ANSWER_ONE = "13"; // <--------- solution from web page test example goes here
    private const string EXPECTED_ANSWER_TWO = "140"; // <--------- solution from web page test example goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day13 = new Day13Solver(parser);

        var (answerOne, _) = day13.CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_ANSWER_ONE);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day13 = new Day13Solver(parser);

        var (_, answerTwo) = day13.CalculateAnswers(INPUT);
        
        answerTwo.Should().Be(EXPECTED_ANSWER_TWO);
    }
}
