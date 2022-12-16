using System;

namespace aoc2022.day15.domain
{
    public class Input
    {
        public List<Sensor> Sensors { get; init; }

        public Input(List<Sensor> sensors)
        {
            Sensors = sensors;
        }
    }
}