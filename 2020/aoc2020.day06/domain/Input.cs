using System;

namespace aoc2020.day06.domain
{
    public class Input
    {
        public List<string[]> GroupAnswers { get; init; }

        public Input(List<string[]> groupAnswers)
        {
            GroupAnswers = groupAnswers;
        }
    }
}