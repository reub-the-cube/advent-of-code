using AoC.Core;
using aoc2022.day08.domain;
using System.ComponentModel.Design;

namespace aoc2022.day08
{
    public class Parser : IParser<Forest>
    {
        public Forest ParseInput(string[] input)
        {
            var treeHeights = new int[input[0].Length, input.Length];
            for (int rowIndex = 0; rowIndex < input.Length; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < input[0].Length; columnIndex++)
                {
                    treeHeights[rowIndex, columnIndex] = int.Parse(new[] { input[rowIndex][columnIndex] });
                }
            }

            var trees = new Tree[input[0].Length, input.Length];
            for (int rowIndex = 0; rowIndex < input[0].Length; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < input.Length; columnIndex++)
                {
                    var treesInColumn = Enumerable.Range(0, treeHeights.GetLength(0)).Select(x => treeHeights[x, columnIndex]).ToArray();
                    var treesInRow = Enumerable.Range(0, treeHeights.GetLength(1)).Select(x => treeHeights[rowIndex, x]).ToArray();
                    var heightsToTheNorth = rowIndex == 0 ? Array.Empty<int>() : treesInColumn[..rowIndex];
                    var heightsToTheEast = columnIndex == input.Length - 1 ? Array.Empty<int>() : treesInRow[(columnIndex + 1)..];
                    var heightsToTheSouth = rowIndex == input[0].Length - 1 ? Array.Empty<int>() : treesInColumn[(rowIndex + 1)..];
                    var heightsToTheWest = columnIndex == 0 ? Array.Empty<int>() : treesInRow[..columnIndex];
                    trees[rowIndex, columnIndex] = new Tree(treeHeights[rowIndex, columnIndex], heightsToTheNorth, heightsToTheEast, heightsToTheSouth, heightsToTheWest);
                }
            }

            return new Forest(trees);
        }
    }
}