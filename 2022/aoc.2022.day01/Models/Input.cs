namespace aoc._2022.day01.models
{
    public class Input
    {
        public List<Elf> Elves { get; private set; }

        public Input()
        {
            Elves = new List<Elf>();
        }

        public void AddElf(Elf elf)
        {
            Elves.Add(elf);
        }

        public int MostCaloriesHeldByAnElf() => Elves.Max(e => e.TotalCalories);
    }

    public record struct Elf(List<int> Calories, int Order)
    {
        public int TotalCalories = Calories.Sum();
    }
}