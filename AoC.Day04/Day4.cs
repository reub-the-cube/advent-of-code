using AoC.Core;
using aoc.day04.models;
using System.Diagnostics;
using aoc.day04.Models;

namespace aoc.day04;
public class Day4 :IDay
{
    private readonly IParser<Input> _parser;

    public Day4(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (int AnswerOne, int AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);
        var (WinningNumber, WinningBoard) = FindWinningBoard(parsedInput);
        var answerOne = WinningNumber * WinningBoard.GetUnmarkedTotal();

        return (answerOne, 0);
    }

    private static (int WinningNumber, Board WinningBoard) FindWinningBoard(Input parsedInput)
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
}
