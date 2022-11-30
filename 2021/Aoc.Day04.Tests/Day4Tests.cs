using aoc.day04.Models;
using FluentAssertions;

namespace aoc.day04.tests;

public class Day4Tests
{
    private readonly string[] INPUT = Array.Empty<string>();

    public Day4Tests()
    {
        INPUT = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..\\..\\..\\..\\AoC.Console\\day4testinput.txt"));
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
        var day4 = new Day4(parser);

        var (answerOne, _) = day4.CalculateAnswers(INPUT);

        answerOne.Should().Be(4512);
    }

    [Fact]
    public void CalculatedAnswerTwoMatchesTestCase()
    {
        var parser = new Parser();
        var day4 = new Day4(parser);

        var (_, answerTwo) = day4.CalculateAnswers(INPUT);

        answerTwo.Should().Be(1924);
    }

    [Fact]
    public void WhenNumberIsFoundOnBoardRowAndColumnIsReturned()
    {
        var board = new Board().Fill(3, new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" });
        //  1   2   3
        //  4   5   6
        //  7   8   9

        var (Found, Column, Row) = board.Find(8);

        Found.Should().Be(true);
        Column.Should().Be(1);
        Row.Should().Be(2);
    }

    [Fact]
    public void WhenCellIsMarkedItCanCompleteARow()
    {
        var board = new Board().Fill(3, new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9" });
        //  1   2   3
        //  4   5   6
        //  7   8   9

        board = board.Mark(0, 2).Mark(0, 0).Mark(0, 1);

        board.HasCompleteColumn.Should().BeFalse();
        board.HasCompleteRow.Should().BeTrue();
    }
}