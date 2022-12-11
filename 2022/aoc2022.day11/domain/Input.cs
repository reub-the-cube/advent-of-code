namespace aoc2022.day11.domain
{
    public class Input
    {
        public List<Monkey> Monkeys { get; init; }

        public Input(List<Monkey> monkeys)
        {
            Monkeys = monkeys;
        }
    }
}