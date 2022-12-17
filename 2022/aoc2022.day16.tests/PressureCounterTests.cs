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
            { ("AA", "JJ"), 2 },
            { ("BB", "BB"), 0 },
            { ("BB", "CC"), 1 },
            { ("BB", "DD"), 2 },
            { ("BB", "EE"), 3 },
            { ("BB", "FF"), 4 },
            { ("BB", "GG"), 5 },
            { ("BB", "HH"), 6 },
            { ("BB", "II"), 2 },
            { ("BB", "JJ"), 3 },
            { ("CC", "CC"), 0 },
            { ("CC", "DD"), 1 },
            { ("CC", "EE"), 2 },
            { ("CC", "FF"), 3 },
            { ("CC", "GG"), 4 },
            { ("CC", "HH"), 5 },
            { ("CC", "II"), 3 },
            { ("CC", "JJ"), 4 },
            { ("DD", "DD"), 0 },
            { ("DD", "EE"), 1 },
            { ("DD", "FF"), 2 },
            { ("DD", "GG"), 3 },
            { ("DD", "HH"), 4 },
            { ("DD", "II"), 2 },
            { ("DD", "JJ"), 3 },
            { ("EE", "EE"), 0 },
            { ("EE", "FF"), 1 },
            { ("EE", "GG"), 2 },
            { ("EE", "HH"), 3 },
            { ("EE", "II"), 3 },
            { ("EE", "JJ"), 4 },
            { ("FF", "FF"), 0 },
            { ("FF", "GG"), 1 },
            { ("FF", "HH"), 2 },
            { ("FF", "II"), 4 },
            { ("FF", "JJ"), 5 },
            { ("GG", "GG"), 0 },
            { ("GG", "HH"), 1 },
            { ("GG", "II"), 5 },
            { ("GG", "JJ"), 6 },
            { ("HH", "HH"), 0 },
            { ("HH", "II"), 6 },
            { ("HH", "JJ"), 7 },
            { ("II", "II"), 0 },
            { ("II", "JJ"), 1 }
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
            //          02: move to a neighbour and have one minute of flow (makes zero)
            // Minute   01: move to a neighbour
            //          02: turn the neighbour on (but multiply by zero minutes)
            var maximumRemainingPressure = PressureCounter.CalculateMaximumRemainingPressure("AA", 2, distancesBetweenValves, valveFlowRates);
            maximumRemainingPressure.Should().HaveCount(1);
            maximumRemainingPressure.Should().ContainKey("AA");
            maximumRemainingPressure["AA"].Should().Be(0);

            // use the test example (but it doesn't have to be) and this time start from BB
            var distancesBetweenValvesPovB = new Dictionary<(string From, string To), int>()
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

            maximumRemainingPressure = PressureCounter.CalculateMaximumRemainingPressure("BB", 2, distancesBetweenValvesPovB, valveFlowRates);
            maximumRemainingPressure.Should().HaveCount(1);
            maximumRemainingPressure.Should().ContainKey("BB");
            maximumRemainingPressure["BB"].Should().Be(13);
        }

        [Fact]
        public void ThreeMinutesInCaveHasAFourFlowsAndAMaximumOf13()
        {
            // Minute   01: turn current valve on                                                           Path 1: Turn Move Turn
            //          02: move to a neighbour and have one minute of flow (makes zero)                    Path 2: Move Turn Move
            //          03: turn the neighbour on and have one minute of flow (makes zero)                  Path 3: Move Move Turn
            // Minute   01: move to a neighbour
            //          02: turn neighbour on
            //          03: move to neighbour+1 and have one minute of flow (makes 13 or 20 or 0)
            // Minute   01: move to a neighbour
            //          02: move to neighbour+1
            //          03: turn neighbour+1 on
            var maximumRemainingPressure = PressureCounter.CalculateMaximumRemainingPressure("AA", 3, distancesBetweenValves, valveFlowRates);
            maximumRemainingPressure.Should().HaveCount(4);
            maximumRemainingPressure.Should().ContainKey("AA");
            maximumRemainingPressure["AA"].Should().Be(0);

            maximumRemainingPressure.Should().ContainKey("BB");
            maximumRemainingPressure["BB"].Should().Be(13);

            maximumRemainingPressure.Should().ContainKey("DD");
            maximumRemainingPressure["DD"].Should().Be(20);

            maximumRemainingPressure.Should().ContainKey("II");
            maximumRemainingPressure["AA"].Should().Be(0);
        }

        [Fact]
        public void FourMinutesInCaveHasSevenFlowsAndAMaximumOf40()
        {
            // Minute   01: turn current valve on                                                           Path 1: Turn Move Turn Move
            //          02: move to a neighbour and have one minute of flow (makes zero)                    Path 2: Turn Move Move Turn
            //          03: turn neighbour on and have one minute of flow (makes zero)                      Path 3: Move Turn Move Turn
            //          04: move to neighbour+1 and have one minute of flow (0 and 13 or 20 or 0)           Path 4: Move Turn Move Move effectively same as 3
            // Minute   01: turn current value on                                                           Path 5: Move Move Turn Move
            //          02: move to a neighbour and have one minute of flow (makes zero)
            //          03: move to neighbour+1 and have one minute of flow (makes zero)
            //          04: turn neighbour+1 on and have one minute of flow (makes zero)
            // Minute   01: move to a neighbour                                                             
            //          02: turn neighbour on                                                             
            //          03: move to neighbour+1 and have one minute of flow (makes 13 or 20 or 0)
            //          04: turn neighbour+1 on and have one minute of flow (makes 26 or 40 or 0)
            // Minute   01: move to a neighbour
            //          02: move to neighbour+1
            //          03: turn neighbour+1 on
            //          04: move to neighbour+2 and have one minute of flow (makes 13 or 20 or 0)
            var maximumRemainingPressure = PressureCounter.CalculateMaximumRemainingPressure("AA", 4, distancesBetweenValves, valveFlowRates);
            maximumRemainingPressure.Should().HaveCount(7);
            maximumRemainingPressure.Should().ContainKey("AA");
            maximumRemainingPressure["AA"].Should().Be(20);

            maximumRemainingPressure.Should().ContainKey("BB");
            maximumRemainingPressure["BB"].Should().Be(26);

            maximumRemainingPressure.Should().ContainKey("DD");
            maximumRemainingPressure["DD"].Should().Be(40);

            maximumRemainingPressure.Should().ContainKey("II");
            maximumRemainingPressure["II"].Should().Be(0);

            maximumRemainingPressure.Should().ContainKey("CC");
            maximumRemainingPressure["CC"].Should().Be(2);

            maximumRemainingPressure.Should().ContainKey("JJ");
            maximumRemainingPressure["JJ"].Should().Be(21);

            maximumRemainingPressure.Should().ContainKey("EE");
            maximumRemainingPressure["EE"].Should().Be(3);
        }

        [Fact]
        public void FiveMinutesInCaveHasEightFlowsAndAMaximumOf63()
        {
            // Getting complicated to write.
            // Path 1:  Turn    Move    Turn    Move    Move/Turn   Total flow = (4 mins of position 1) + (2 mins of position 2)
            // Path 2:  Turn    Move    Move    Turn    Move        Total flow = (4 mins of position 1) + (1 min of position 3)     :::will be less than Path 1:::
            // Path 3:  Turn    Move    Move    Move    Move/Turn   Total flow = (4 mins of position 1)                             :::will be less than Path 2:::
            // Path 4:  Move    Turn    Move    Turn    Move        Total flow = (3 mins of position 2) + (1 min of position 3)
            // Path 5:  Move    Turn    Move    Move    Move/Turn   Total flow = (3 mins of position 2)                             :::will be less than Path 4:::
            // Path 6:  Move    Move    Turn    Move    Move/Turn   Total flow = (2 mins of position 3)
            // Path 7:  Move    Move    Move    Turn    Move        Total flow = (1 min of position 4)
            // All valves within a distance of 3 will have a possible maximum flow

            var maximumRemainingPressure = PressureCounter.CalculateMaximumRemainingPressure("AA", 5, distancesBetweenValves, valveFlowRates);
            maximumRemainingPressure.Should().HaveCount(8);
            maximumRemainingPressure.Should().ContainKey("AA");
            maximumRemainingPressure["AA"].Should().Be(40);         // 4 mins of AA, with 2 mins of DD

            maximumRemainingPressure.Should().ContainKey("BB");
            maximumRemainingPressure["BB"].Should().Be(41);         // 3 mins of BB, with 1 min of CC

            maximumRemainingPressure.Should().ContainKey("DD");
            maximumRemainingPressure["DD"].Should().Be(63);         // 3 mins of DD, with 1 min of EE

            maximumRemainingPressure.Should().ContainKey("II");
            maximumRemainingPressure["II"].Should().Be(21);         // 3 mins of II, with 1 min of JJ

            maximumRemainingPressure.Should().ContainKey("CC");
            maximumRemainingPressure["CC"].Should().Be(4);

            maximumRemainingPressure.Should().ContainKey("JJ");
            maximumRemainingPressure["JJ"].Should().Be(42);

            maximumRemainingPressure.Should().ContainKey("EE");
            maximumRemainingPressure["EE"].Should().Be(6);

            maximumRemainingPressure.Should().ContainKey("FF");
            maximumRemainingPressure["FF"].Should().Be(0);
        }


        [Fact]
        public void TestCaseCalculatesMaxPressureReleaseAsExpected()
        {
            var maximumRemainingPressure = PressureCounter.CalculateMaximumRemainingPressure("AA", 30, distancesBetweenValves, valveFlowRates);
            maximumRemainingPressure.Values.Max().Should().Be(1651);
        }
    }
}
