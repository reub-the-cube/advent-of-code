using AoC.Core;
using aoc.day04.models;
using aoc.day04.Models;
using System.Xml;
using System.Text.RegularExpressions;

namespace aoc.day04
{
    public class Parser : IParser<Input>
    {
        private const int numberOfRows = 5;
        private const int numberOfColumns = 5;

        public Input ParseInput(string[] input)
        {
            var filteredInput = input.Where(i => !string.IsNullOrWhiteSpace(i)).AsEnumerable();
            var numbersToBeCalled = filteredInput.First().Split(",").Select(int.Parse).ToArray();
            var boards = GetBoards(filteredInput.Skip(1));
            return new Input(numbersToBeCalled, boards);
        }

        private static Board[] GetBoards(IEnumerable<string> boardInput)
        {
            var whitespaceFinder = new Regex("\\s+");
            var boards = boardInput.Chunk(numberOfRows); // Length of this is how many boards we have
            var flattenedBoards = boards.Select(s => string.Join(" ", s)).Select(s => whitespaceFinder.Split(s).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray());
            return flattenedBoards.Select(b => new Board().Fill(numberOfColumns, b)).ToArray();
        }
    }
}
