using aoc2022.day16.domain;
using FluentAssertions;

namespace aoc2022.day16.tests
{
    public class TunnelNetworkTests
    {
        readonly Dictionary<string, List<string>> ValveTunnels = new Dictionary<string, List<string>>()
        {
            {"AA", new List<string>{ "DD", "II", "BB" } },
            {"BB", new List<string>{ "CC", "AA" } },
            {"CC", new List<string>{ "DD", "BB" } },
            {"DD", new List<string>{ "CC", "AA", "EE" } },
            {"EE", new List<string>{ "FF", "DD" } },
            {"FF", new List<string>{ "EE", "GG" } },
            {"GG", new List<string>{ "FF", "HH" } },
            {"HH", new List<string>{ "GG" } },
            {"II", new List<string>{ "AA", "JJ" } },
            {"JJ", new List<string>{ "II" } }
        };

        [Fact]
        public void CanFindShortestPathToSelf()
        {
            var tunnelNetwork = new TunnelNetwork(ValveTunnels);
            var shortestPath = tunnelNetwork.GetShortestPath("AA", "AA");

            shortestPath.Should().Be(0);
        }

        [Theory]
        [InlineData("AA", "DD")]
        [InlineData("AA", "II")]
        [InlineData("AA", "BB")]
        [InlineData("CC", "DD")]
        [InlineData("FF", "GG")]
        public void FindShortestPathToImmediateNeighbourReturnsOne(string from, string to)
        {
            var tunnelNetwork = new TunnelNetwork(ValveTunnels);
            var shortestPath = tunnelNetwork.GetShortestPath(from, to);

            shortestPath.Should().Be(1);
        }

        [Theory]
        [InlineData("AA", "CC")]
        [InlineData("AA", "EE")]
        [InlineData("AA", "JJ")]
        [InlineData("CC", "AA")]
        [InlineData("CC", "EE")]
        [InlineData("FF", "DD")]
        [InlineData("FF", "HH")]
        public void FindShortestPathToNextButOneNeighbourReturnsTwo(string from, string to)
        {
            var tunnelNetwork = new TunnelNetwork(ValveTunnels);
            var shortestPath = tunnelNetwork.GetShortestPath(from, to);

            shortestPath.Should().Be(2);
        }

        [Theory]
        [InlineData("AA", "HH", 5)]
        [InlineData("JJ", "GG", 6)]
        public void FindShortestPathOnLongerJourneyReturnsExpectedValue(string from, string to, int distance)
        {
            var tunnelNetwork = new TunnelNetwork(ValveTunnels);
            var shortestPath = tunnelNetwork.GetShortestPath(from, to);

            shortestPath.Should().Be(distance);
        }
    }
}
