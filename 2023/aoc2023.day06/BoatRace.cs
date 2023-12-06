using aoc2023.day06.domain;

namespace aoc2023.day06
{
    public class BoatRace
    {
        private readonly long raceDuration;
        private readonly List<RaceState> raceOutcomes = new();

        public BoatRace(long raceDuration)
        {
            this.raceDuration = raceDuration;
        }

        public long GetNumberOfScenariosToBeatADistance(long distanceToBeat, bool modelRace)
        {
            if (modelRace)
            {
                return GetNumberOfScenariosToBeatADistance(distanceToBeat);
            }
            else
            {
                return CalculateNumberOfScenariosToBeatADistance(distanceToBeat);
            }
        }

        private long CalculateNumberOfScenariosToBeatADistance(long distanceToBeat)
        {
            // Each unit of race duration corresponds to a total distance travelled
            // Distance travelled = time remaining * speed
            // Time remaining = race duration - time elapsed
            // Speed = time elapsed
            // ----------------------------------------------
            // Distance travelled = (race duration * speed) - (time elapsed * speed)
            // 0 = (time elapsed)^2 - race duration(time elapsed) + distanceTravelled
            // ----------------------------------------------
            // We want to beat the record (> distance travelled)
            // if x=time elapsed
            // 0 > x^2 - duration * x + record
            // quadratic equation is (-b +/- (b^2 - 4ac)^0.5) / 2a
            // a = 1
            // b = duration
            // c = record

            var sqrtPart = Math.Pow(Math.Pow(raceDuration, 2) - (4 * 1 * distanceToBeat), 0.5);
            var lower = Math.Floor((raceDuration - sqrtPart) * 0.5) + 1; 
            var upper = Math.Ceiling((raceDuration + sqrtPart) * 0.5) - 1;

            var result = upper - lower + 1;
            return (long)result;
        }

        public long GetNumberOfScenariosToBeatADistance(long distanceToBeat)
        {
            Begin();
            return raceOutcomes.Count(r => r.DistanceTravelled > distanceToBeat);
        }

        private void Begin()
        {
            var raceStates = new Queue<RaceState>();
            raceStates.Enqueue(new RaceState(0, 0, raceDuration, 0));

            while (raceStates.Count > 0)
            {
                var raceState = raceStates.Dequeue();

                // Can hold button or move
                if (raceState.TimeRemaining > 0)
                {
                    // Hold button
                    raceStates.Enqueue(new RaceState(raceState.TimeButtonHeld + 1, raceState.DistanceTravelled, raceState.TimeRemaining - 1, raceState.Speed + 1));

                    // Release button
                    raceStates.Enqueue(new RaceState(raceState.TimeButtonHeld, raceState.TimeRemaining * raceState.Speed, 0, raceState.Speed));
                }
                else
                {
                    raceOutcomes.Add(raceState);
                }
            }
        }
    }
}