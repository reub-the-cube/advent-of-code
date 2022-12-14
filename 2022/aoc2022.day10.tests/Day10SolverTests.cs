using FluentAssertions;

namespace aoc2022.day10.tests;

public class Day10SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..\\..\\..\\..\\..\\Inputs\\2022\\day10testinput.txt"));
    private const string EXPECTED_ANSWER_ONE = "13140"; // <--------- solution from web page test example goes here
    private const string EXPECTED_ANSWER_TWO = "\r\n##..##..##..##..##..##..##..##..##..##..\r\n###...###...###...###...###...###...###.\r\n####....####....####....####....####....\r\n#####.....#####.....#####.....#####.....\r\n######......######......######......####\r\n#######.......#######.......#######.....\r\n\r\n"; // <--------- solution from web page test example goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day10 = new Day10Solver(parser);

        var (answerOne, _) = day10.CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_ANSWER_ONE);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day10 = new Day10Solver(parser);

        var (_, answerTwo) = day10.CalculateAnswers(INPUT);
        
        answerTwo.Should().Be(EXPECTED_ANSWER_TWO);
    }
}
