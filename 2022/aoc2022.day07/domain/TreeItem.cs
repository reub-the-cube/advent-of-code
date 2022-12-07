using static aoc2022.day07.domain.Enums;

namespace aoc2022.day07.domain
{
    public class TreeDirectoryItem : TreeItem
    {
        public TreeDirectoryItem() : base(TreeItemType.Directory, 0)
        {
        }
    }
    
    public class TreeFileItem : TreeItem
    {
        public TreeFileItem(int size) : base(TreeItemType.File, size)
        {
        }
    }

    public abstract class TreeItem
    {
        public TreeItemType ItemType { get; }
        public int Size { get; }

        protected TreeItem(TreeItemType treeItemType, int size)
        {
            ItemType = treeItemType;
            Size = size;
        }
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
