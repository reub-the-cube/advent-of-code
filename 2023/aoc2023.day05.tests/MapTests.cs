using aoc2023.day05.domain;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Unicode;
using System.Threading.Tasks;

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
    }
}
