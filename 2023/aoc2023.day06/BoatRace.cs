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