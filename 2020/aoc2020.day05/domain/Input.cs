using System;

namespace aoc2020.day05.domain
{
    public class Input
    {
        public List<Seat> Seats { get; }

        public void AddSeat(Seat seat) {
            Seats.Add(seat);
        }

        public Input()
        {
            Seats = new List<Seat>();
        }
    }

    public record Seat(int Row, int Column) {
        public int Id => Row * 8 + Column;
    }
}