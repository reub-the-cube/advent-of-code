using System;

namespace aoc2023.day02.domain
{
    public class Input
    {
        public IEnumerable<Game> Games { get; }

        public Input(List<Game> games)
        {
            Games = games;
        }
    }
}