using aoc2023.day08.domain;
using FluentAssertions;

namespace aoc2023.day08.tests
{
    public class NavigatorTests
    {
        [Fact]
        public void NavigateFromCurrentLocationToDestinationInASingleStep()
        {
            var network = new Dictionary<string, Node>()
            {
                { "START", new Node("START", "NOT_END", "END") }
            };
            var moveSequence = new char[] { 'R' };

            var navigator = new Navigator(network);

            var numberOfSteps = navigator.GetSteps("START", "END", moveSequence);

            numberOfSteps.Should().Be(1);
        }

        [Fact]
        public void NavigateFromCurrentLocationToDestinationInAMultipleSteps()
        {
            var network = new Dictionary<string, Node>()
            {
                { "START", new Node("START", "NOT_END", "END") },
                { "NOT_END", new Node("NOT_END", "START", "END") }
            };
            var moveSequence = new char[] { 'L', 'R' };

            var navigator = new Navigator(network);

            var numberOfSteps = navigator.GetSteps("START", "END", moveSequence);

            numberOfSteps.Should().Be(2);
        }

        [Fact]
        public void NavigateFromCurrentLocationToDestinationWhenVisitingANodeMultipleTimes()
        {
            var network = new Dictionary<string, Node>()
            {
                { "START", new Node("START", "NOT_END", "END") },
                { "NOT_END", new Node("NOT_END", "START", "END") }
            };
            var moveSequence = new char[] { 'L', 'L', 'R' };

            var navigator = new Navigator(network);

            var numberOfSteps = navigator.GetSteps("START", "END", moveSequence);

            numberOfSteps.Should().Be(3);
        }

        [Fact]
        public void NavigateFromCurrentLocationToDestinationWhenRepeatingMoveSequence()
        {
            var network = new Dictionary<string, Node>()
            {
                { "START", new Node("START", "NOT_END", "END") },
                { "NOT_END", new Node("NOT_END", "NOT_END_2", "END") },
                { "NOT_END_2", new Node("NOT_END_2", "END", "START") }
            };
            var moveSequence = new char[] { 'L' };

            var navigator = new Navigator(network);

            var numberOfSteps = navigator.GetSteps("START", "END", moveSequence);

            numberOfSteps.Should().Be(3);
        }

        [Fact]
        public void NavigateFromCurrentLocationToDestinationInExampleNetwork()
        {
            var network = new Dictionary<string, Node>()
            {
                { "AAA", new Node("AAA", "BBB", "CCC") },
                { "BBB", new Node("BBB", "DDD", "EEE") },
                { "CCC", new Node("CCC", "ZZZ", "GGG") },
                { "DDD", new Node("DDD", "DDD", "DDD") },
                { "EEE", new Node("EEE", "EEE", "EEE") },
                { "GGG", new Node("GGG", "GGG", "GGG") },
                { "ZZZ", new Node("ZZZ", "ZZZ", "ZZZ") }
            };
            var moveSequence = "RL".ToCharArray();

            var navigator = new Navigator(network);

            var numberOfSteps = navigator.GetSteps("AAA", "ZZZ", moveSequence);

            numberOfSteps.Should().Be(2);
        }

        [Fact]
        public void NavigateFromCurrentLocationToDestinationInExampleNetwork2()
        {
            var network = new Dictionary<string, Node>()
            {
                { "AAA", new Node("AAA", "BBB", "BBB")},
                { "BBB", new Node("BBB", "AAA", "ZZZ")},
                { "ZZZ", new Node("ZZZ", "ZZZ", "ZZZ")}
            };
            var moveSequence = "LLR".ToCharArray();

            var navigator = new Navigator(network);

            var numberOfSteps = navigator.GetSteps("AAA", "ZZZ", moveSequence);

            numberOfSteps.Should().Be(6);
        }
    }
}
