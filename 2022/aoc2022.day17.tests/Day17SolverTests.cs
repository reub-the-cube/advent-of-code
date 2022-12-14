using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit.Abstractions;

namespace aoc2022.day17.tests;

public class Day17SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2022", "day17testinput.txt"));
    private const string EXPECTED_ANSWER_ONE = "3068"; // <--------- solution from web page test example goes here
    private const string EXPECTED_ANSWER_TWO = "1514285714288"; // <--------- solution from web page test example goes here
    private TestLogger<Day17Solver> _logger;

    public Day17SolverTests(ITestOutputHelper output)
    {
        _logger = new TestLogger<Day17Solver>(output);
    }
    
    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day17 = new Day17Solver(parser, _logger);

        var (answerOne, _) = day17.CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_ANSWER_ONE);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day17 = new Day17Solver(parser, _logger);

        var (_, answerTwo) = day17.CalculateAnswers(INPUT);

        answerTwo.Should().Be(EXPECTED_ANSWER_TWO);
    }
}
