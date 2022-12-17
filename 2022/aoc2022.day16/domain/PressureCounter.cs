namespace aoc2022.day16.domain
{
    public static class PressureCounter
    {
        public static Dictionary<string, int> CalculateMaximumRemainingPressure(string startingValve, int numberOfMinutes, Dictionary<(string From, string To), int> distancesBetweenValves, Dictionary<string, int> remainingOffValves)
        {
            return CalculateMaximumRemainingPressure(new[] { startingValve }, new[] { numberOfMinutes }, distancesBetweenValves, remainingOffValves);
        }

        public static Dictionary<string, int> CalculateMaximumRemainingPressure(string[] startingValves, int[] numberOfMinutes, Dictionary<(string From, string To), int> distancesBetweenValves, Dictionary<string, int> remainingOffValves)
        {
            var maxPressureRemainingByStartingValve = new Dictionary<string, int>();

            foreach (var valve in remainingOffValves)
            {
                // Update the one with the most time to go
                var mostTimeRemaining = numberOfMinutes.Max();
                var indexOfMostTime = Array.IndexOf(numberOfMinutes, mostTimeRemaining);

                var orderedKey = distancesBetweenValves.ContainsKey((startingValves[indexOfMostTime], valve.Key)) ? 
                    (startingValves[indexOfMostTime], valve.Key) : 
                    (valve.Key, startingValves[indexOfMostTime]);

                // Take a minute off to turn the valve on
                // Take minutes off based on how far the valve is from current one
                var remainingMinutes = numberOfMinutes[indexOfMostTime] - distancesBetweenValves[orderedKey] - 1;
                if (remainingMinutes > 0)
                {
                    var nextStartingValues = (string[])startingValves.Clone();
                    var nextRemainingMinutes = (int[])numberOfMinutes.Clone();
                    nextStartingValues[indexOfMostTime] = valve.Key;
                    nextRemainingMinutes[indexOfMostTime] = remainingMinutes;

                    var maxPressureOnRemainingValves = CalculateMaximumRemainingPressure(nextStartingValues, nextRemainingMinutes, distancesBetweenValves, remainingOffValves.Where(r => r.Key != valve.Key).ToDictionary(k => k.Key, v => v.Value));
                    var maxPressureRemaining = (remainingOffValves[valve.Key] * remainingMinutes) + maxPressureOnRemainingValves.Values.DefaultIfEmpty(0).Max();
                    maxPressureRemainingByStartingValve.Add(valve.Key, maxPressureRemaining);
                }
            }

            return maxPressureRemainingByStartingValve;
        }
    }
}
