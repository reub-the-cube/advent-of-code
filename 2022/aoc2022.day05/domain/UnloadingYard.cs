namespace aoc2022.day05.domain
{
    public readonly record struct UnloadingYard
    {
        public RearrangementProcedure RearrangementProcedure { get; init; }
        public Dictionary<int, List<string>> Stacks { get; init; }

        public UnloadingYard(Dictionary<int, List<string>> stacks, RearrangementProcedure rearrangementProcedure)
        {
            Stacks = stacks;
            RearrangementProcedure = rearrangementProcedure;
        }

        public UnloadingYard RearrangeYard(CraneTypes craneToUse)
        {
            var newStacks = Stacks.ToDictionary(k => k.Key, v => new List<string>(v.Value));

            foreach (var (NumberOfCrates, FromStack, ToStack) in RearrangementProcedure.Steps)
            {
                newStacks[FromStack].MoveCrates(NumberOfCrates, newStacks[ToStack], craneToUse);
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
        public static void MoveCrates(this List<string> stack, int numberOfCrates, List<string> to, CraneTypes craneType)
        {
            var topCrates = stack.TakeLast(numberOfCrates).ToList();

            // Only the CrateMover 9001 can move multiple crates (all of them) at once
            if (craneType != CraneTypes.CrateMover9001)
            {
                topCrates.Reverse();
            }

            stack.RemoveRange(stack.Count - numberOfCrates, numberOfCrates);
            to.AddRange(topCrates);
        }
    }

    public enum CraneTypes
    {
        CrateMover9000,
        CrateMover9001
    }
}