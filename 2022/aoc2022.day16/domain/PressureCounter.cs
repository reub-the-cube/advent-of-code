namespace aoc2022.day16.domain
{
    public static class PressureCounter
    {
        public static Dictionary<string, int> CalculateMaximumRemainingPressure(string startingValve, int numberOfMinutes, Dictionary<(string From, string To), int> distancesBetweenValves, Dictionary<string, int> remainingOffValves)
        {
            var maxPressureRemainingByStartingValve = new Dictionary<string, int>();

            foreach (var valve in remainingOffValves)
            {
                // Take a minute off to turn the valve on
                // Take minutes off based on how far the valve is from current one
                var distanceToValve = distancesBetweenValves.TryGetValue((startingValve, valve.Key), out int value) ? value : distancesBetweenValves[(valve.Key, startingValve)];
                var remainingMinutes = numberOfMinutes - distanceToValve - 1;
                if (remainingMinutes > 0)
                {
                    maxPressureRemainingByStartingValve.Add(valve.Key, remainingOffValves[startingValve]);
                }
            }

            return maxPressureRemainingByStartingValve;
        }
    }
}
