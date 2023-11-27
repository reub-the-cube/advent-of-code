using System;

namespace aoc2020.day02.domain
{
    public class Input
    {
        public List<KeyValuePair<Policy, string>>? PolicyPasswordPairs { get; set; }
    }

    public record Policy(int Min, int Max, char SearchFor);
}