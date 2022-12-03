using aoc._2022.day03.Domain;
using FluentAssertions;

namespace aoc._2022.day03.tests;

public class Day03SolverTests
{
    private readonly string[] INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..\\..\\..\\..\\..\\Inputs\\2022\\day03testinput.txt"));
    private const int EXPECTED_DAY_ONE_ANSWER = 157; // <--------- solution from web page test example goes here
    private const int EXPECTED_DAY_TWO_ANSWER = 70; // <--------- solution from web page test example goes here

    [Fact]
    public void InputLoadsCorrectly()
    {
        INPUT.Length.Should().BeGreaterThan(0);
    }

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day03 = new Day03Solver(parser);

        var (answerOne, _) = day03.CalculateAnswers(INPUT);

        answerOne.Should().Be(EXPECTED_DAY_ONE_ANSWER);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day03 = new Day03Solver(parser);

        var (_, answerTwo) = day03.CalculateAnswers(INPUT);
        
        answerTwo.Should().Be(EXPECTED_DAY_TWO_ANSWER);
    }

    [Fact]
    public void ParserSplitsStringCorrectly()
    {
        var parser = new Parser();
        var input = new string[] { "abccba" };

        var result = parser.ParseInput(input);

        result.Rucksacks.Should().HaveCount(1);
        result.Rucksacks[0].CompartmentOne.Should().Be("abc");
        result.Rucksacks[0].CompartmentTwo.Should().Be("cba");
    }

    [Fact] 
    public void ItemsGetPrioritisedCorrectly()
    {
        var commonItems = new[] { 'a', 'o', 'A', 'K' }; // 1, 15, 27, 37 

        var calculatedPriority = PriorityCalculator.CalculatePriorityOfItems(commonItems);

        calculatedPriority.Should().Be(80);
    }
}
