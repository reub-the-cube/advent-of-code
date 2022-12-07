using AoC.Core;
using aoc2022.day07.domain;

namespace aoc2022.day07
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            var parsedInput = new Input();
            var workingDirectory = "/";
            parsedInput.AddTreeItem("/", string.Empty, new TreeDirectoryItem());

            foreach (var inputRow in input.Skip(1))
            {
                if (workingDirectory.First() != '/') workingDirectory = $"/{workingDirectory}";
                
                switch (inputRow)
                {
                    case "$ ls":
                        break;
                    case "$ cd ..":
                        workingDirectory = $"{string.Join('/', workingDirectory.Split('/', StringSplitOptions.RemoveEmptyEntries).SkipLast(1))}/";
                        break;
                    default:
                    {
                        if (inputRow[..4] == "$ cd")
                        {
                            workingDirectory = $"{workingDirectory}{inputRow[5..]}/";
                        }
                        else
                        {
                            var (Name, Item) = ParseLine(inputRow);
                            parsedInput.AddTreeItem(Name, workingDirectory, Item);
                        }

                        break;
                    }
                }
            }

            return parsedInput;
        }

        private static (string Name, TreeItem Item) ParseLine(string inputRow)
        {
            if (inputRow[..3] == "dir")
            {
                return (inputRow[4..], new TreeDirectoryItem());
            }
            else
            {
                var splitRow = inputRow.Split(" ");
                return (splitRow[1], new TreeFileItem(int.Parse(splitRow[0])));
            }
        }
    }
}

