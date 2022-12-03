namespace aoc._2022.day03.Domain
{
    public static class CompartmentChecker
    {   
        public static char FindFirstCommonItem(string[] items)
        {
            IEnumerable<char> commonItems = items[0];

            for (int i = 1; i < items.Length; i++)
            {
                commonItems = commonItems.Intersect(items[i]);
            }

            return commonItems.FirstOrDefault();
        }
    }
}
