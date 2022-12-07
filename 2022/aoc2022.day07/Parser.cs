using AoC.Core;
using aoc2022.day07.domain;

namespace aoc2022.day07
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var parsedInput = new Input();
            var directoryStack = new Stack<string>();
            var workingDirectory = "/";
            
            // Add root
            parsedInput.AddTreeItem("/", string.Empty, new TreeDirectoryItem());

            foreach (var inputRow in input.Skip(1).Where(i => i != "$ ls"))
            {
                if (inputRow[..4] == "$ cd")
                {
                    workingDirectory = GetWorkingDirectory(inputRow[5..], directoryStack);
                }
                else
                {
                    var (Name, Item) = ParseLine(inputRow);
                    parsedInput.AddTreeItem(Name, workingDirectory, Item);
                }
            }

            return parsedInput;
        }

        private static string GetWorkingDirectory(string newDirectory, Stack<string> directoryStack)
        {
            switch (newDirectory)
            {
                case "..":
                    directoryStack.Pop();
                    break;
                default:
                    directoryStack.Push(newDirectory);
                    break;
            }

            return directoryStack.Count switch
            {
                0 => "/",
                _ => $"/{string.Join('/', directoryStack.Reverse())}/"
            };
        }
        
        private static (string Name, TreeItem Item) ParseLine(string inputRow)
        {
            if (inputRow[..3] == "dir")
            {
                return (inputRow[4..], new TreeDirectoryItem());
            }

            var splitRow = inputRow.Split(" ");
            return (splitRow[1], new TreeFileItem(int.Parse(splitRow[0])));
        }
    }
}