using FluentAssertions;

namespace aoc._2022.day02.tests;

public class Day02SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..\\..\\..\\..\\..\\Inputs\\2022\\day02testinput.txt"));
    private const int EXPECTED_DAY_ONE_ANSWER = -1; // <--------- solution from web page test example goes here
    private const int EXPECTED_DAY_TWO_ANSWER = -1; // <--------- solution from web page test example goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day02 = new Day02Solver(parser);

        var (answerOne, _) = day02.CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_DAY_ONE_ANSWER);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day02 = new Day02Solver(parser);

        var (_, answerTwo) = day02.CalculateAnswers(INPUT);
        
        answerTwo.Should().Be(EXPECTED_DAY_TWO_ANSWER);
    }
}
