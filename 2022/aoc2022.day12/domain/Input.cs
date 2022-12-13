using System;

namespace aoc2022.day12.domain
{
    public class Input
    {
        public Position StartingPosition { get; private set; }
        public Position EndingPosition { get; private set; }
        public int[][] Heights { get; private set; }

        public Input(Position startingPosition, Position endingPosition, int[][] heights)
        {
            StartingPosition = startingPosition;
            EndingPosition = endingPosition;
            Heights = heights;
        }
    }
}