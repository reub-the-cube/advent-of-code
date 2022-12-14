using AoC.Core;
using aoc2022.day14.domain;

namespace aoc2022.day14
{
    public class Parser : IParser<Input>
    {
        public Input ParseInput(string[] input)
        {
            // x represents distance to the right and y represents distance down

            var allIndexes = input
                .SelectMany(s => s.Split(" -> "))   // all coordinates
                .Select(s => s.Split(','))          // array of all coordinates
                .ToList();

            var xPositions = allIndexes.Select(s => Convert.ToInt32(s[0])).ToList();
            var yPositions = allIndexes.Select(s => Convert.ToInt32(s[1])).ToList();

            var columnOffset = xPositions.Min();
            var numberOfFilledColumns = xPositions.Max() - columnOffset + 1;
            var numberOfFilledRows = yPositions.Max() + 1;

            var tiles = new Tile[numberOfFilledRows, numberOfFilledColumns];

            for (var i = 0; i < numberOfFilledRows; i++)
            {
                for (var j = 0; j < numberOfFilledColumns; j++)
                {
                    tiles[i, j] = new Tile(new Position(i, j), TileState.Air);
                }
            }

            var cave = new CaveSlice(tiles);
            foreach (var inputRow in input)
            {
                cave = cave.AddLineOfRocks(inputRow, columnOffset);
            }

            return new Input(cave, columnOffset);
        }
    }
}
