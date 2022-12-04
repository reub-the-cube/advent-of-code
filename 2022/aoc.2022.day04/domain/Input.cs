using static aoc._2022.day04.Extensions;

namespace aoc._2022.day04.domain
{
    public class Input
    {
        public readonly List<AssignmentPair> AssignmentPairs;

        public Input(List<AssignmentPair> assignmentPairs)
        {
            AssignmentPairs = assignmentPairs;
        }
    }

    public readonly record struct AssignmentPair(Range FirstSectionIdRange, Range SecondSectionIdRange)
    {
        private RangeOverlapResult OverlapType => FirstSectionIdRange.GetTypeOfOverlap(SecondSectionIdRange);
        public bool HasFullRangeOverlap => OverlapType != RangeOverlapResult.False && OverlapType != RangeOverlapResult.Partial;
        public bool HasSomeKindOfOverlap => OverlapType != RangeOverlapResult.False;
    };
}