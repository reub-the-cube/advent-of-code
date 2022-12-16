using AoC.Core;
using aoc2022.day15.domain;

namespace aoc2022.day15
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var sensors = input.Select(i =>
            {
                var splitByEquals = i.Split('=');
                var sensorX = int.Parse(splitByEquals[1].Split(',')[0]);
                var sensorY = int.Parse(splitByEquals[2].Split(':')[0]);
                var beaconX = int.Parse(splitByEquals[3].Split(',')[0]);
                var beaconY = int.Parse(splitByEquals[4]);
                return new Sensor(new Position(sensorX, sensorY), new Position(beaconX, beaconY));
            });

            return new Input(sensors.ToList());
        }
    }
}
