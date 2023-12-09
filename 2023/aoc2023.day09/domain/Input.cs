namespace aoc2023.day09.domain
{
    public class Input
    {
        public List<List<int>> OasisHistoryRecords { get; init; }

        public Input(List<List<int>> oasisHistoryRecords)
        {
            OasisHistoryRecords = oasisHistoryRecords;
        }
    }
}