using aoc2022.day16.domain;
using FluentAssertions;

namespace aoc2022.day16.tests
{
    public class PressureCounterTests
    {
        /*
         *      CC ---- BB      JJ                      // What is the most value we can get from this moment in time from all remaining valves 
         *      |       |       |                       // Recurse...
         *      |       |       |                       //   What is the most value we can get from the next moment in time from the new remaining values
         *      |       |       |
         *      |       |       |                       // AA = 0       FF = 0
         *      DD ---- AA ---- II                      // BB = 13      GG = 0
         *      |                                       // CC = 2       HH = 22
         *      |                                       // DD = 20      II = 0
         *      |                                       // EE = 3       JJ = 21
         *      |        
         *      EE ---- FF ---- GG ---- HH
         */

        // use the test example (but it doesn't have to be)
        private readonly Dictionary<(string From, string To), int> distancesBetweenValves = new()
        {
            { ("AA", "AA"), 0 },
            { ("AA", "BB"), 1 },
            { ("AA", "CC"), 2 },
            { ("AA", "DD"), 1 },
            { ("AA", "EE"), 2 },
            { ("AA", "FF"), 3 },
            { ("AA", "GG"), 4 },
            { ("AA", "HH"), 5 },
            { ("AA", "II"), 1 },
            { ("AA", "JJ"), 2 }
        };

        // use the test example (but it doesn't have to be)
        private readonly Dictionary<(string From, string To), int> distancesBetweenValvesPovB = new()
        {
            { ("BB", "AA"), 1 },
            { ("BB", "BB"), 0 },
            { ("BB", "CC"), 1 },
            { ("BB", "DD"), 2 },
            { ("BB", "EE"), 3 },
            { ("BB", "FF"), 4 },
            { ("BB", "GG"), 5 },
            { ("BB", "HH"), 6 },
            { ("BB", "II"), 2 },
            { ("BB", "JJ"), 3 }
        };

        // use the test example (but it doesn't have to be)
        private readonly Dictionary<string, int> valveFlowRates = new()
        {
            { "AA", 0 },
            { "BB", 13 },
            { "CC", 2 },
            { "DD", 20 },
            { "EE", 3 },
            { "FF", 0 },
            { "GG", 0 },
            { "HH", 22 },
            { "II", 0 },
            { "JJ", 21 }
        };

        [Fact]
        public void OneMinuteInCaveCannotHaveAnyFlow()
        {
            // Minute   01: turn current valve on (but multiply by no minutes)
            var maximumRemainingPressure = PressureCounter.CalculateMaximumRemainingPressure("AA", 1, distancesBetweenValves, valveFlowRates);

            maximumRemainingPressure.Should().HaveCount(0);
        }

        [Fact]
        public void TwoMinutesInCaveHasAMaximumFlowOfTheFlowOfTheStartingPoint()
        {
            // Minute   01: turn current valve on
            //          02: have one minute of flow (makes zero)
            // Minute   01: move to neighbours
            //          02: turn them on (but multiply by zero minutes)
            var maximumRemainingPressure = PressureCounter.CalculateMaximumRemainingPressure("AA", 2, distancesBetweenValves, valveFlowRates);
            maximumRemainingPressure.Should().HaveCount(1);
            maximumRemainingPressure.Should().ContainKey("AA");
            maximumRemainingPressure["AA"].Should().Be(0);

            maximumRemainingPressure = PressureCounter.CalculateMaximumRemainingPressure("BB", 2, distancesBetweenValvesPovB, valveFlowRates);
            maximumRemainingPressure.Should().HaveCount(1);
            maximumRemainingPressure.Should().ContainKey("BB");
            maximumRemainingPressure["BB"].Should().Be(13);
        }
    }
}
