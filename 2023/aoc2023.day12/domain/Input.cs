namespace aoc2023.day12.domain
{
    public class Input
    {
        public readonly List<SpringConditionsRecord> SpringConditions = new();

        public void AddSpringConditionsRecord(SpringConditionsRecord record)
        {
            SpringConditions.Add(record);
        }
    }

    public class SpringConditionsRecord
    {
        public string SpringConditions { get; init; }
        public List<int> ContiguousCount { get; init; }

        public SpringConditionsRecord(string springConditions, List<int> contiguousCount)
        {
            SpringConditions = springConditions;
            ContiguousCount = contiguousCount;
        }
    }
}