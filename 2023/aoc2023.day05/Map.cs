using aoc2023.day05.domain;
using System;
using System.Text;
using System.Text.Unicode;

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

        public long GetDestination(long sourceValue)
        {
            var destinations = GetDestinations(sourceValue, sourceValue);
            return destinations.Min(d => d.From);
        }

        public List<(long From, long To)> GetDestinations(long sourceFrom, long sourceTo)
        {
            if (nextMap != null)
            {
                return GetNextMapDestinations(sourceFrom, sourceTo);
            }
            else
            {
                return GetThisMapDestinations(sourceFrom, sourceTo);
            }
        }

        private List<(long From, long To)> GetThisMapDestinations(long sourceFrom, long sourceTo)
        {
            var rangesToExplore = Ranges
                .Where(r => sourceFrom <= r.SourceStart + r.Length && sourceTo >= r.SourceStart)
                .DefaultIfEmpty(new MappingRange(sourceTo + 1, 1, 0))
                .ToList();

            return rangesToExplore
                .SelectMany(r => GetDestinationRanges(sourceFrom, sourceTo, r))
                .ToList();
        }

        private List<(long From, long To)> GetNextMapDestinations(long sourceFrom, long sourceTo)
        {
            var thisMapDestinations = GetThisMapDestinations(sourceFrom, sourceTo);
            return thisMapDestinations.SelectMany(d => nextMap.GetDestinations(d.From, d.To)).ToList();
        }

        private List<(long From, long To)> GetDestinationRanges(long sourceFrom, long sourceTo, MappingRange range)
        {
            var destinationRanges = new List<(long From, long To)>();
            destinationRanges.AddRange(GetOverlappingRanges(range, sourceFrom, sourceTo));
            destinationRanges.AddRange(GetUnmappedSubRanges(range, sourceFrom, sourceTo));

            return destinationRanges;
        }

        private List<(long From, long To)> GetOverlappingRanges(MappingRange range, long sourceFrom, long sourceTo)
        {
            var destinationRanges = new List<(long From, long To)>();
            if (sourceFrom <= range.SourceStart + range.Length && sourceTo >= range.SourceStart)
            {
                destinationRanges.Add(GetOverlappingRange(range, sourceFrom, sourceTo));
            }

            return destinationRanges;
        }

        private static (long From, long To) GetOverlappingRange(MappingRange range, long sourceFrom, long sourceTo)
        {
            // Overlap of some description with the range
            var start = Math.Max(sourceFrom, range.SourceStart);
            var end = Math.Min(sourceTo, range.SourceStart + range.Length);

            var startDelta = start - range.SourceStart;
            var endDelta = end - range.SourceStart;

            var destinationStart = range.DestinationStart + startDelta;
            var destinationEnd = range.DestinationStart + endDelta;

            return (destinationStart, destinationEnd);
        }

        private List<(long From, long To)> GetUnmappedSubRanges(MappingRange range, long sourceFrom, long sourceTo)
        {
            var destinationRanges = new List<(long From, long To)>();

            var unmappedRangeBelow = GetUnmappedSubRange(sourceFrom, range.SourceStart, 0, -1);
            if (unmappedRangeBelow != null) destinationRanges.Add(unmappedRangeBelow.Value);
            
            var unmappedRangeAbove = GetUnmappedSubRange(range.SourceStart + range.Length, sourceTo, 1, 0);
            if (unmappedRangeAbove != null) destinationRanges.Add(unmappedRangeAbove.Value);

            return destinationRanges;
        }

        private (long From, long To)? GetUnmappedSubRange(long unmappedFrom, long unmappedTo, int fromOffset, int toOffset)
        {
            (long From, long To)? unmappedRange = null;

            if (unmappedFrom < unmappedTo)
            {
                var unmappedFromWithOffset = unmappedFrom + fromOffset;
                var unmappedToWithOffset = unmappedTo + toOffset;
                if (!Ranges.Any(r => unmappedFromWithOffset <= r.SourceStart + r.Length && unmappedToWithOffset >= r.SourceStart))
                {
                    unmappedRange = (unmappedFromWithOffset, unmappedToWithOffset);
                }
            }

            return unmappedRange;
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
