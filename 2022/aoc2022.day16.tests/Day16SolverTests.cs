using FluentAssertions;

namespace aoc2022.day16.tests;

public class Day16SolverTests
{
    /*
     *      CC ---- BB      JJ                      // What is the most value we can get from this moment in time from all remaining valves 
     *      |       |       |                       // Recurse...
     *      |       |       |                       //   What is the most value we can get from the next moment in time from the new remaining values
     *      |       |       |
     *      |       |       |
     *      DD ---- AA ---- II
     *      |
     *      |
     *      |
     *      |        
     *      EE ---- FF ---- GG ---- HH
     * 
     * 
     */

    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2022", "day16testinput.txt"));
    private const string EXPECTED_ANSWER_ONE = "1651"; // <--------- solution from web page test example goes here
    private const string EXPECTED_ANSWER_TWO = "not_implemented"; // <--------- solution from web page test example goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day16 = new Day16Solver(parser);

        var (answerOne, _) = day16.CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_ANSWER_ONE);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day16 = new Day16Solver(parser);

        var (_, answerTwo) = day16.CalculateAnswers(INPUT);
        
        answerTwo.Should().Be(EXPECTED_ANSWER_TWO);
    }
}
