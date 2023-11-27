using System;

namespace aoc2020.day03.domain
{
    public class Input
    {
        public Square[,]? Grid { get; init; }

        public Input(Square[,] grid)
        {
            Grid = grid;
        }
    }

    public enum Square
    {
        Open,
        Tree
    }
}