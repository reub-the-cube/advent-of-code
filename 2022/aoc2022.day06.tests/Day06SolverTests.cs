using FluentAssertions;

namespace aoc2022.day06.tests;

public class Day06SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..\\..\\..\\..\\..\\Inputs\\2022\\day06testinput.txt"));
    private const string EXPECTED_ANSWER_ONE = "7,5,6,10,11"; // <--------- solution from web page test example goes here
    private const string EXPECTED_ANSWER_TWO = ""; // <--------- solution from web page test example goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var day06 = new Day06Solver();

        var (answerOne, _) = day06.CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_ANSWER_ONE);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var day06 = new Day06Solver();

        var (_, answerTwo) = day06.CalculateAnswers(INPUT);
        
        answerTwo.Should().Be(EXPECTED_ANSWER_TWO);
    }
}
