using System;

namespace aoc2020.day01.domain
{
    public class Input
    {
        public IEnumerable<int> ReportEntries { get; init; }

        public Input(IEnumerable<int> reportEntries)
        {
            ReportEntries = reportEntries;
        }
    }
}