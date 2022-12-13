using FluentAssertions;

namespace aoc2022.day12.tests;

public class Day12SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2022", "day12testinput.txt"));
    private const string EXPECTED_ANSWER_ONE = "31"; // <--------- solution from web page test example goes here
    private const string EXPECTED_ANSWER_TWO = "29"; // <--------- solution from web page test example goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void InputParsesCorrectly()
    {
        var parser = new Parser();
        var parsedInput = parser.ParseInput(INPUT);

        parsedInput.StartingPosition.Column.Should().Be(0);
        parsedInput.StartingPosition.Row.Should().Be(0);
        parsedInput.EndingPosition.Column.Should().Be(5);
        parsedInput.EndingPosition.Row.Should().Be(2);
        parsedInput.Heights.Length.Should().Be(5);
        parsedInput.Heights[0].Length.Should().Be(8);
        parsedInput.Heights[1][4].Should().Be(25);
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
