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
                    var maxPressureOnRemainingValves = CalculateMaximumRemainingPressure(valve.Key, remainingMinutes, distancesBetweenValves, remainingOffValves.Where(r => r.Key != valve.Key).ToDictionary(k => k.Key, v => v.Value));
                    var maxPressureRemaining = (remainingOffValves[valve.Key] * remainingMinutes) + maxPressureOnRemainingValves.Values.DefaultIfEmpty(0).Max(); 
                    maxPressureRemainingByStartingValve.Add(valve.Key, maxPressureRemaining);
                }
            }

            return maxPressureRemainingByStartingValve;
        }
    }
}
