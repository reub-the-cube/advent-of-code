using FluentAssertions;

namespace aoc2023.day01.tests;

public class Day01SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2023", "day01testinput.txt"));
    private readonly string[] INPUT_PART_TWO = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2023", "day01testinput_part2.txt"));
    private const string EXPECTED_ANSWER_ONE = "142"; // <--------- solution from web page test example goes here
    private const string EXPECTED_ANSWER_TWO = "281"; // <--------- solution from web page test example goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day01 = new Day01Solver(parser);

        var (answerOne, _) = day01.CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_ANSWER_ONE);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day01 = new Day01Solver(parser);

        var (_, answerTwo) = day01.CalculateAnswers(INPUT_PART_TWO);
        
        answerTwo.Should().Be(EXPECTED_ANSWER_TWO);
    }
}
