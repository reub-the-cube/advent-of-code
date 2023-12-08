using aoc2023.day08.domain;
using FluentAssertions;
using System.Diagnostics;
using System.Reflection;
using Xunit.Abstractions;

namespace aoc2023.day08.tests
{
    public class NavigatorTests
    {
        private readonly ITestOutputHelper output;

        public NavigatorTests(ITestOutputHelper outputHelper)
        {
            this.output = outputHelper;
        }

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
                { "NOT_END", new Node("NOT_END", "START", "END") },
                { "END", new Node("END", "NOT_END", "NOT_END") }
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

        [Fact]
        public void NavigateFromCurrentLocationToDestinationBasedOnNumberOfStepsTaken()
        {
            var network = new Dictionary<string, Node>()
            {
                { "AAA", new Node("AAA", "BBB", "AAA")},
                { "BBB", new Node("BBB", "CCC", "ZZZ")},
                { "CCC", new Node("CCC", "DDD", "AAA")},
                { "DDD", new Node("DDD", "EEE", "ZZZ")},
                { "EEE", new Node("EEE", "FFF", "AAA")},
                { "FFF", new Node("FFF", "GGG", "AAA")},
                { "GGG", new Node("GGG", "AAA", "ZZZ")},
                { "ZZZ", new Node("ZZZ", "FFF", "ZZZ")}
            };
            var moveSequence = "LLLRLLLLLLRLLLLLLRLLLLLLRLLLL".ToCharArray();

            // AAA --1--> BBB --2--> CCC --3--> DDD --4--> ZZZ
            // ZZZ --5--> FFF --6--> GGG --7--> AAA --8--> BBB --9--> CCC --10-> DDD --11-> ZZZ

            var navigator = new Navigator(network);

            var numberOfSteps = navigator.GetStepsForMultipleReturnsToDestination("AAA", ["ZZZ"], moveSequence, 10);
            output.WriteLine($"From AAA to:");
            output.WriteLine(string.Join(Environment.NewLine, numberOfSteps.Select(n => $"{n.FinishingNode} in {n.NumberOfSteps} steps.")));

            // This (above) is more complicated than the problem as it goes in steps of a smaller delta before repeating

            string[] INPUT_PART2 = File.ReadAllLines(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "..", "..", "Inputs", "2023", "day08input.txt"));
            var parser = new Parser();
            var input = parser.ParseInput(INPUT_PART2);
            navigator = new Navigator(input.NodeNetwork);
            var destinations = input.NodeNetwork.Where(n => n.Key.EndsWith("Z")).Select(n => n.Key).ToList();
            
            foreach (KeyValuePair<string, Node> startingNode in input.NodeNetwork.Where(n => n.Key.EndsWith("A")))
            {
                numberOfSteps = navigator.GetStepsForMultipleReturnsToDestination(startingNode.Key, destinations, input.NodeSelectorSequence, 5);
                output.WriteLine($"From {startingNode.Key} to:");
                output.WriteLine(string.Join(Environment.NewLine, numberOfSteps.Select(n => $"{n.FinishingNode} in {n.NumberOfSteps} steps.")));
            }
        }
    }
}
