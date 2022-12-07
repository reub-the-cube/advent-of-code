using AoC.Core;
using aoc2022.day07.domain;

namespace aoc2022.day07
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var parsedInput = new Input();
            var workingDirectory = @".\";

            foreach (var inputRow in input)
            {
                if (inputRow == "$ ls")
                {

                }
                else if (inputRow == "$ cd ..")
                {
                    workingDirectory = $@"{string.Join('\\', workingDirectory.Split('\\', StringSplitOptions.RemoveEmptyEntries).SkipLast(1))}\";
                }
                else if (inputRow[..4] == "$ cd")
                {
                    workingDirectory = @$"{workingDirectory}{inputRow[5..]}\";
                }
                else
                {
                    var (Name, Item) = ParseLine(inputRow);
                    parsedInput.AddTreeItem(Name, workingDirectory, Item);
                }
            }

            return parsedInput;
        }

        public static (string Name, TreeItem Item) ParseLine(string inputRow)
        {
            if (inputRow[..3] == "dir")
            {
                return (inputRow[4..], new TreeItem(Enums.TreeItemType.Directory, 0));
            }
            else
            {
                var splitRow = inputRow.Split(" ");
                return (splitRow[1], new TreeItem(Enums.TreeItemType.File, int.Parse(splitRow[0])));
            }
        }
    }
}
