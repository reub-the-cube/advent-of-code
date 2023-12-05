using aoc2023.day05.domain;

namespace aoc2023.day05
{
    public class Map
    {
        public List<MappingRange> Ranges { get; init; }
        private readonly Map? nextMap;

        public Map(List<MappingRange> mappingRanges)
        {
            Ranges = mappingRanges;
        }

        public Map(List<MappingRange> mappingRanges, Map nextMap)
        {
            Ranges = mappingRanges;
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
            foreach (var range in Ranges)
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

    public static class MapExtensions
    {
        public static Map CreateNewMapWithDependency(this Map map, Map nextMap)
        {
            return new Map(map.Ranges, nextMap);
        }
    }
}
