using System.Collections.Immutable;
using System.Reflection;
using AoC.Core;
using aoc2020.day05.domain;

namespace aoc2020.day05;

public class Day05Solver : IDaySolver
{
    private readonly IParser<Input> _parser;

    public Day05Solver(IParser<Input> parser)
    {
        _parser = parser;
    }

    public (string AnswerOne, string AnswerTwo) CalculateAnswers(string[] input)
    {
        var parsedInput = _parser.ParseInput(input);

        var answerOne = parsedInput.Seats.Max(s => s.Id);

        // Answer two
        // Remove front and back rows
        var firstRow = parsedInput.Seats.Min(s => s.Row);
        var lastRow = parsedInput.Seats.Max(s => s.Row);
        var remainingSeats = parsedInput.Seats.Where(s => s.Row != firstRow && s.Row != lastRow).ToList();

        // find seat where id+1, id-1 exist
        // it's a full flight, so there must be one missing
        var seatsByRow = remainingSeats.GroupBy(s => s.Row).Where(s => s.Count() < 8);
        var mySeatId = 0;
        foreach (var seat in seatsByRow.First()) {
            bool previousSeat = parsedInput.Seats.Any(s => s.Id == seat.Id - 1);
            bool nextSeat = parsedInput.Seats.Any(s => s.Id == seat.Id + 1);
            if (!previousSeat) {
                mySeatId = seat.Id - 1;
            }
            if (!nextSeat) {
                mySeatId = seat.Id + 1;
            }
        }

        return ($"{answerOne}", $"{mySeatId}");
    }
}
