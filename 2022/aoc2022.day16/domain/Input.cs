using System;

namespace aoc2022.day16.domain
{
    public class Input
    {
        public Dictionary<string, int> ValveFlowRates { get; set; }
        public Dictionary<string, List<string>> ValveTunnels { get; set; }

        public Input(Dictionary<string, int> valveFlowRates, Dictionary<string, List<string>> valveTunnels)
        {
            ValveFlowRates = valveFlowRates;
            ValveTunnels = valveTunnels;
        }
    }
}