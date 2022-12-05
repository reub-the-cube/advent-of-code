using FluentAssertions;

namespace aoc._2022.day04.tests;

public class Day04SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..\\..\\..\\..\\..\\Inputs\\2022\\day04testinput.txt"));
    private const string EXPECTED_ANSWER_ONE = "2"; // <--------- solution from web page test example goes here
    private const string EXPECTED_ANSWER_TWO = "4"; // <--------- solution from web page test example goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day04 = new Day04Solver(parser);

        var (answerOne, _) = day04.CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_ANSWER_ONE);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day04 = new Day04Solver(parser);

        var (_, answerTwo) = day04.CalculateAnswers(INPUT);
        
        answerTwo.Should().Be(EXPECTED_ANSWER_TWO);
    }
}
