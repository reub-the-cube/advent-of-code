namespace aoc2023.day06.domain
{
    public class Input
    {
        internal List<RaceEvent> RaceEvents { get; init; }

        public Input()
        {
            RaceEvents = new List<RaceEvent>();
        }

        internal void AddRaceEvent(RaceEvent raceEvent)
        {
            RaceEvents.Add(raceEvent);
        }
    }
}