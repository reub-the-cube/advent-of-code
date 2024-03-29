using FluentAssertions;

namespace aoc2023.day08.tests;

public class Day08SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2023", "day08testinput.txt"));
    private readonly string[] INPUT_PART2 = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2023", "day08testinput_part2.txt"));
    private const string EXPECTED_ANSWER_ONE = "6"; // <--------- solution from web page test example goes here
    private const string EXPECTED_ANSWER_TWO = "6"; // <--------- solution from web page test example goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day08 = new Day08Solver(parser);

        var (answerOne, _) = day08.CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_ANSWER_ONE);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day08 = new Day08Solver(parser);

        var (_, answerTwo) = day08.CalculateAnswers(INPUT_PART2);

        answerTwo.Should().Be(EXPECTED_ANSWER_TWO);
    }
}
