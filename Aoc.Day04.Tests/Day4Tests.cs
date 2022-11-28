namespace aoc.day04.tests;

public class Day4Tests
{
    private readonly string[] INPUT = new string[] { };

    [Fact]
    public void CalculatedAnswerOneMatchesTestCase()
    {
        var parser = new Parser();
        var day2 = new Day4(parser);

        var (answerOne, _) = day2.CalculateAnswers(INPUT);

        answerOne.Should().Be(150);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day2 = new Day4(parser);

        var (_, answerTwo) = day2.CalculateAnswers(INPUT);

        answerTwo.Should().Be(900);
    }
}