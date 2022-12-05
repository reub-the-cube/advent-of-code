namespace aoc2022.day05.domain
{
    public class UnloadingYard
    {
        public RearrangementProcedure RearrangementProcedure { get; init; }
        public Dictionary<int, List<string>> Stacks { get; init; }

        public UnloadingYard(Dictionary<int, List<string>> stacks, RearrangementProcedure rearrangementProcedure)
        {
            Stacks = stacks;
            RearrangementProcedure = rearrangementProcedure;
        }

        public UnloadingYard RearrangeYard()
        {
            var newStacks = Stacks.ToDictionary(k => k.Key, v => v.Value);

            foreach (var (NumberOfCrates, FromStack, ToStack) in RearrangementProcedure.Steps)
            {
                newStacks[FromStack].MoveCrates(NumberOfCrates, newStacks[ToStack]);
            }

            return new(newStacks, RearrangementProcedure);
        }

        public IEnumerable<string> GetTopCrateOfEachStack()
        {
            return Stacks.Select(s => s.Value.Last());
        }
    }

    public static class YardExtensions
    {
        public static void MoveCrates(this List<string> stack, int numberOfCrates, List<string> to)
        {
            var topCrates = stack.TakeLast(numberOfCrates).ToList();
            topCrates.Reverse();

            stack.RemoveRange(stack.Count - numberOfCrates, numberOfCrates);
            to.AddRange(topCrates);
        }
    }
}