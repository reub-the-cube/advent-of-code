using System;

namespace aoc2022.day07.domain
{
    public class Input
    {
        public Dictionary<(string Name, string PathToParent), TreeItem> Tree { get; init; }

        public Input()
        {
            Tree = new Dictionary<(string Name, string PathToParent), TreeItem>();
        }

        public void AddTreeItem(string name, string pathToParent, TreeItem value)
        {
            Tree.Add((name, pathToParent), value);
        }
    }
}