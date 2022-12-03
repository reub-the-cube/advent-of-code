namespace aoc._2022.day03.Domain
{
    public static class PriorityCalculator
    {
        public static int CalculatePriorityOfItems(IEnumerable<char> items) => items.Sum(ItemPriority);

        private static int ItemPriority(char item)
        {
            int caseWeighting = char.IsUpper(item) ? 26 : 0;
            return (item % 32) + caseWeighting;
        }
    }
}
