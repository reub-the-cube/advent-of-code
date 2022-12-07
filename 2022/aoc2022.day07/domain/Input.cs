namespace aoc2022.day07.domain
{
    public class Input
    {
        public Dictionary<(string Name, string PathToParent), TreeItem> Tree { get; }

        public Input()
        {
            Tree = new Dictionary<(string Name, string PathToParent), TreeItem>();
        }

        public Input(Dictionary<(string Name, string PathToParent), TreeItem> tree)
        {
            Tree = tree;
        }

        public void AddTreeItem(string name, string pathToParent, TreeItem value)
        {
            Tree.Add((name, pathToParent), value);
        }

        public Dictionary<string, int> GetDirectoriesBySize()
        {
            return Tree
                .Where(v => v.Value.ItemType == Enums.TreeItemType.Directory)
                .Select(kvp => new KeyValuePair<string, int>(Path.Combine(kvp.Key.PathToParent, kvp.Key.Name),
                    GetTotalSizeOfDirectoryFiles(kvp.Key.Name, kvp.Key.PathToParent)))
                .ToDictionary(k => k.Key, v => v.Value);
        }

        public int GetTotalSizeOfDirectoryFiles(string name, string pathToParent)
        {
            var currentDirectory = Path.Combine(pathToParent, name);
            var matchingTreeItems = Tree
                .Where(k => k.Key.PathToParent.StartsWith(currentDirectory)
                            && k.Value.ItemType == Enums.TreeItemType.File);

            var sumOfFiles = matchingTreeItems.Sum(v => v.Value.Size);
            return sumOfFiles;
        }
    }
}