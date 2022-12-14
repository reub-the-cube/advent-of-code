using FluentAssertions;

namespace aoc2022.day11.tests;

public class Day11SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..\\..\\..\\..\\..\\Inputs\\2022\\day11testinput.txt"));
    private const string EXPECTED_ANSWER_ONE = "10605"; // <--------- solution from web page test example goes here
    private const string EXPECTED_ANSWER_TWO = "2713310158"; // <--------- solution from web page test example goes here
    
    private const string EXPECTED_ROUND_ONE_STANDINGS = "\r\nMonkey 0: 20, 23, 27, 26\r\nMonkey 1: 2080, 25, 167, 207, 401, 1046\r\nMonkey 2: \r\nMonkey 3: \r\n"; // <--------- solution from web page test example goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day11 = new Day11Solver(parser);

        var (answerOne, _) = day11.CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_ANSWER_ONE);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day11 = new Day11Solver(parser);

        var (_, answerTwo) = day11.CalculateAnswers(INPUT);
        
        answerTwo.Should().Be(EXPECTED_ANSWER_TWO);
    }

    [Fact]
    public void DoOneRound()
    {
        var parser = new Parser();
        var day11 = new Day11Solver(parser);

        var (_, _) = day11.CalculateAnswers(INPUT);
        var standings = day11.GetRoundStandings(0);

        standings.Should().Be(EXPECTED_ROUND_ONE_STANDINGS);
    }
}
