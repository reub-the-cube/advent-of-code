using aoc2023.day05.domain;
using FluentAssertions;

namespace aoc2023.day05.tests
{
    public class MapTests
    {
        [Fact]
        public void WhenASourceIsInTheFirstRangeItMapsToCorrespondingDestination()
        {
            var firstRange = new MappingRange(98, 99, 50);
            var map = new Map([firstRange]);

            var destinationWhenInRange = map.GetDestination(98);

            destinationWhenInRange.Should().Be(50);
        }

        [Fact]
        public void WhenASourceIsNotInTheFirstRangeItMapsToCorrespondingDestination()
        {
            var firstRange = new MappingRange(98, 99, 50);
            var map = new Map([firstRange]);

            var destinationWhenInRange = map.GetDestination(0);

            destinationWhenInRange.Should().Be(0);
        }

        [Fact]
        public void WhenASourceIsInTheLastRangeItMapsToCorrespondingDestination()
        {
            var firstRange = new MappingRange(98, 99, 50);
            var otherRange = new MappingRange(10, 25, 20);
            var lastRange = new MappingRange(90, 97, 5);
            var map = new Map([firstRange, otherRange, lastRange]);

            var destinationWhenInRange = map.GetDestination(97);

            destinationWhenInRange.Should().Be(12);
        }

        [Fact]
        public void WhenASourceIsNotInAnyRangeItMapsToCorrespondingDestination()
        {
            var firstRange = new MappingRange(98, 99, 50);
            var otherRange = new MappingRange(10, 25, 20);
            var lastRange = new MappingRange(90, 97, 5);
            var map = new Map([firstRange, otherRange, lastRange]);

            var destinationWhenInRange = map.GetDestination(0);

            destinationWhenInRange.Should().Be(0);
        }

        [Fact]
        public void WhenAMapContainsMultipleLevelsThenSourceMapsToFinalDestination()
        {
            var secondRange = new MappingRange(50, 10, 10);
            var secondMap = new Map([secondRange]);

            var firstRange = new MappingRange(98, 99, 50);
            var firstMap = new Map([firstRange], secondMap);

            // First map 98 --> 50
            // Second map 50 --> 10
            var destinationWhenInRange = firstMap.GetDestination(98);

            destinationWhenInRange.Should().Be(10);
        }

        [Fact]
        public void WhenASourceRangeIsInASingleRangeThenARangeIsReturned()
        {
            var firstRange = new MappingRange(98, 99, 50);
            var map = new Map([firstRange]);

            var destinations = map.GetDestinations(110, 125);

            destinations.Should().HaveCount(1);
            destinations[0].From.Should().Be(62);
            destinations[0].To.Should().Be(77);
        }

        [Fact]
        public void WhenASourceRangeIsNotInASingleRangeThenARangeIsReturned()
        {
            var firstRange = new MappingRange(98, 99, 50);
            var map = new Map([firstRange]);

            var destinations = map.GetDestinations(55, 60);

            destinations.Should().HaveCount(1);
            destinations[0].From.Should().Be(55);
            destinations[0].To.Should().Be(60);
        }

        [Fact]
        public void WhenASourceRangeMapsThroughMultipleLevelsThenARangeIsReturned()
        {
            var firstRange = new MappingRange(98, 99, 50);
            var map = new Map([firstRange]);

            var destinations = map.GetDestinations(90, 100);

            destinations.Should().HaveCount(2);
            destinations.Contains((90, 97));
            destinations.Contains((50, 52));
        }

        [Fact]
        public void WhenASourceRangeIsOverlapsAMappedRangeThenARangeIsReturned()
        {
            var secondRange = new MappingRange(51, 10, 10);
            var secondMap = new Map([secondRange]);

            var firstRange = new MappingRange(98, 99, 50);
            var firstMap = new Map([firstRange], secondMap);

            // First map (90, 100) --> (90, 97), (50, 52)
            // Second map (90, 97), (50, 52) --> (90, 97), (50, 50), (10, 11)
            var destinations = firstMap.GetDestinations(90, 100);

            destinations.Should().HaveCount(3);
            destinations.Contains((90, 97));
            destinations.Contains((50, 50));
            destinations.Contains((10, 11));
        }
    }
}
