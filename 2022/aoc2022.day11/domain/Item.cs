using System.Numerics;

namespace aoc2022.day11.domain
{
    public class Item
    {
        private long WorryLevel { get; set; }

        public Item(int worryLevel)
        {
            WorryLevel = worryLevel;
        }

        public long GetWorryLevel()
        {
            return WorryLevel;
        }

        public void UpdateWorryLevelOnInspection(long newWorryLevel)
        {
            WorryLevel = newWorryLevel;
        }

        public void UpdateWorryLevelAfterInspection(Func<long, decimal> worryLevelReducer)
        {
            WorryLevel = Convert.ToInt64(Math.Floor(worryLevelReducer.Invoke(WorryLevel)));
        }
    }
}
