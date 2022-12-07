using static aoc2022.day07.domain.Enums;

namespace aoc2022.day07.domain
{
    public readonly record struct TreeItem(TreeItemType ItemType, int Size)
    {
    }

    public static class Enums
    {
        public enum TreeItemType
        {
            File,
            Directory
        }
    }
}
