namespace aoc._2022.day04
{
    public static class Extensions
    {
        public static RangeOverlapResult GetTypeOfOverlap(this Range range, Range compareTo)
        {
            if ((range.Start.Value == compareTo.Start.Value) && (range.Start.Value == compareTo.Start.Value))
            {
                return RangeOverlapResult.Equal;
            }
            if ((range.Start.Value <= compareTo.Start.Value) && (range.End.Value >= compareTo.End.Value))
            {
                return RangeOverlapResult.OtherIsInThis;
            }
            if ((range.Start.Value >= compareTo.Start.Value) && (range.End.Value <= compareTo.End.Value))
            {
                return RangeOverlapResult.ThisIsInOther;
            }
            if ((range.Start.Value > compareTo.End.Value) || (range.End.Value < compareTo.Start.Value))
            {
                // If the start of this range is after the end of the other, it can't overlap
                // If the end of this range is before the start of the other, it can't overlap
                return RangeOverlapResult.False;
            }

            return RangeOverlapResult.Partial;
        }

        public enum RangeOverlapResult
        {
            False,
            ThisIsInOther,
            OtherIsInThis,
            Equal,
            Partial
        }
    }
}
