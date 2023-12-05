using aoc2023.day05.domain;

namespace aoc2023.day05
{
    public class Map
    {
        private readonly List<MappingRange> ranges;
        private readonly Map? nextMap;

        public Map(List<MappingRange> mappingRanges)
        {
            ranges = mappingRanges;
        }

        public Map(List<MappingRange> mappingRanges, Map nextMap)
        {
            ranges = mappingRanges;
            this.nextMap = nextMap;
        }

        public int GetDestination(int sourceValue)
        {
            var destinationValue = GetThisDestination(sourceValue);

            if (nextMap != null)
            {
                destinationValue = nextMap.GetDestination(destinationValue);
            }

            return destinationValue;
        }

        private int GetThisDestination(int sourceValue)
        {
            foreach (var range in ranges)
            {
                if (sourceValue >= range.SourceStart && sourceValue <= range.SourceStart + range.Length)
                {
                    var delta = sourceValue - range.SourceStart;
                    return range.DestinationStart + delta;
                }
            }

            return sourceValue;
        }
    }
}
