using aoc.day04.models;
using aoc.day04.Models;
using AoC.Core;

namespace aoc.day04;
public class Day4 :IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day4(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (int AnswerOne, int AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        var (FirstWinningNumber, FirstWinningBoard) = FindFirstWinningBoard(parsedInput);
        var answerOne = FirstWinningNumber * FirstWinningBoard.GetUnmarkedTotal();

        parsedInput = _parser.ParseInput(input);
        var (LastWinningNumber, LastWinningBoard) = FindLastWinningBoard(parsedInput);
        var answerTwo = LastWinningNumber * LastWinningBoard.GetUnmarkedTotal();

        return (answerOne, answerTwo);
    }

    private static (int WinningNumber, Board WinningBoard) FindFirstWinningBoard(Input parsedInput)
    {
        var boards = parsedInput.Boards;

        foreach (var numberToCall in parsedInput.NumbersToCall)
        {
            boards = boards.Select(b =>
            {
                var cell = b.Find(numberToCall);
                if (cell.Found)
                {
                    return b.Mark(cell.Row, cell.Column);
                }
                else
                {
                    return b;
                }
            }).ToArray();

            var winningBoard = boards.FirstOrDefault(b => b.HasCompleteRow || b.HasCompleteColumn);
            if (winningBoard != null)
            {
                return (numberToCall, winningBoard);
            }
        }

        return (-1, new Board());
    }

    private static (int WinningNumber, Board WinningBoard) FindLastWinningBoard(Input parsedInput)
    {
        var boards = parsedInput.Boards;

        foreach (var numberToCall in parsedInput.NumbersToCall)
        {
            boards = boards
                .Where(b => !b.HasCompleteRow && !b.HasCompleteColumn)
                .Select(b =>
                {
                    var (Found, Column, Row) = b.Find(numberToCall);
                    if (Found)
                    {
                        return b.Mark(Row, Column);
                    }
                    else
                    {
                        return b;
                    }
                }).ToArray();

            var lastBoardComplete = boards.Length == 1 && boards.FirstOrDefault(b => b.HasCompleteColumn || b.HasCompleteRow) != null;
            if (lastBoardComplete)
            {
                return (numberToCall, boards[0]);
            }
        }

        return (-1, new Board());
    }
}
